using _365EJSC.ERP.Application.Requests.HRM.Employee;
using _365EJSC.ERP.Application.Validators.HRM.Employee;
using _365EJSC.ERP.Contract.Abstractions;
using _365EJSC.ERP.Contract.Constants;
using _365EJSC.ERP.Contract.DependencyInjection.Extensions;
using _365EJSC.ERP.Contract.DTOs;
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Exceptions;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Base;
using MediatR;
using System.Data;
using Entities = _365EJSC.ERP.Domain.Entities.HRM;

namespace _365EJSC.ERP.Application.UserCases.HRM.Employee
{
    /// <summary>
    /// Handler for <see cref="UpdateEmployeeRequest"/>
    /// </summary>
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeRequest, Result<object>>
    {
        /// <summary>
        /// Repository handle data access of <see cref="Employee"/>
        /// </summary>
        private readonly IEmployeeSqlRepository employeeSqlRepository;
        private readonly IFileService fileService;

        /// <summary>
        /// Unit of work to handle transaction
        /// </summary>
        private readonly ISqlUnitOfWork sqlUnitOfWork;


        /// <summary>
        /// Constructor of <see cref="UpdateEmployeeHandler"/>, inject needed dependency
        /// </summary>
        public UpdateEmployeeHandler(IEmployeeSqlRepository employeeSqlRepository,
                                     ISqlUnitOfWork sqlUnitOfWork,
                                     IFileService fileService)
        {
            this.employeeSqlRepository = employeeSqlRepository;
            this.sqlUnitOfWork = sqlUnitOfWork;
            this.fileService = fileService;
        }

        /// <summary>
        /// Handle <see cref="UpdateEmployeeRequest"/>, find existing <see cref="Employee"/> based on id provided in <see cref="UpdateEmployeeRequest"/>,
        /// update the found <see cref="Employee"/> based on data provided in <see cref="UpdateEmployeeRequest"/> and save to the database.
        /// </summary>
        /// <param name="request">Request to handle</param>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="Result{TModel}"/> with success status</returns>
        /// <exception cref="Exception"></exception>
        public async Task<Result<object>> Handle(UpdateEmployeeRequest request, CancellationToken cancellationToken)
        {
            // Create validator and validate request
            UpdateEmployeeValidator validator = new();
            validator.ValidateAndThrow(request);

            // Find Employee based on id provided from the database, if Training Major is not found, throw not found exception.
            // Need tracking to update the Employee.
            Entities.Employee? employee = await employeeSqlRepository.FindByIdAsync((int)request.Id, true, cancellationToken);
            if (employee is null) CustomException.ThrowNotFoundException(typeof(Entities.Employee), MsgCode.ERR_EMPLOYEE_ID_NOT_FOUND);

            // Check exist
            await employeeSqlRepository.ValidateEmployee(request.EmpCode != employee!.EmpCode ? request.EmpCode : null, request.DegreeId, request.CountryId, request.MaritalId, request.EmpRoleId, request.BankId, request.NationId, request.ReligionId, request.TraMajId, request.EmpPlaceOfResidenceWardId, request.EmpPlaceOfBirth, request.CompanyId);

            // Update Employee based on data provided in UpdateEmployeeRequest request.
            // Keep Employee original data if request fields are null
            request.MapTo(employee, true);

            // Begin transaction
            using IDbTransaction transaction = await sqlUnitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                // Upload Image file company
                if (!string.IsNullOrEmpty(request.EmpImageBase64))
                {
                    UploadFileRequest uploadFileRequest = new UploadFileRequest()
                    {
                        Content = request.EmpImageBase64,
                        FileName = string.Format(Const.FILENAME_EMPLOYEE, employee.Id),
                        enumOptionPath = EnumOptionPath.Employee,
                    };
                    employee.EmpImage = await fileService.UploadFileAsync(uploadFileRequest);
                }

                // Mark Employee as Updated state
                employeeSqlRepository.Update(employee);

                // Save Employee to database
                await sqlUnitOfWork.SaveChangesAsync(cancellationToken);

                // Commit transaction
                transaction.Commit();

                // Return success result
                return Result<object>.Ok();
            }
            catch (Exception)
            {
                // Rollback transaction if any exception happens, then throw exception
                transaction.Rollback();
                throw;
            }
        }
    }
}
