using _365EJSC.ERP.Application.Requests.HRM.Employee;
using _365EJSC.ERP.Application.Validators.HRM.Employee;
using _365EJSC.ERP.Contract.Abstractions;
using _365EJSC.ERP.Contract.Constants;
using _365EJSC.ERP.Contract.DependencyInjection.Extensions;
using _365EJSC.ERP.Contract.DTOs;
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Base;
using MediatR;
using System.Data;
using Entities = _365EJSC.ERP.Domain.Entities.HRM;

namespace _365EJSC.ERP.Application.UserCases.HRM.Employee
{
    /// <summary>
    /// Handler for <see cref="CreateEmployeeRequest"/>
    /// </summary>
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeRequest, Result<object>>
    {
        /// <summary>
        /// Repository handle data access of <see cref="Employee"/>
        /// </summary>
        private readonly IEmployeeSqlRepository employeeSqlRepository;
        private readonly IFileService fileService;
        private readonly IPasswordHasher passwordHasher;

        /// <summary>
        /// Unit of work to handle transaction
        /// </summary>
        private readonly ISqlUnitOfWork sqlUnitOfWork;

        /// <summary>
        /// Constructor of <see cref="CreateEmployeeHandler"/>, inject needed dependency
        /// </summary>
        public CreateEmployeeHandler(IEmployeeSqlRepository employeeSqlRepository,
                                     ISqlUnitOfWork sqlUnitOfWork,
                                     IFileService fileService,
                                     IPasswordHasher passwordHasher)
        {
            this.employeeSqlRepository = employeeSqlRepository;
            this.sqlUnitOfWork = sqlUnitOfWork;
            this.fileService = fileService;
            this.passwordHasher = passwordHasher;
        }

        /// <summary>
        /// Handle <see cref="CreateEmployeeRequest"/>, create new <see cref="Employee"/> based on data <see cref="CreateEmployeeRequest"/>
        /// and save to database
        /// </summary>
        /// <param name="request">Request to handle</param>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="Result{TModel}"/> with success status</returns> 
        /// <exception cref="Exception"></exception>
        public async Task<Result<object>> Handle(CreateEmployeeRequest request, CancellationToken cancellationToken)
        {
            // Create validator and validate request
            CreateEmployeeValidator validator = new();
            validator.ValidateAndThrow(request);

            // Check exist
            await employeeSqlRepository.ValidateEmployee(request.EmpCode, request.DegreeId, request.CountryId, request.MaritalId, request.EmpRoleId, request.BankId, request.NationId, request.ReligionId, request.TraMajId, request.EmpPlaceOfResidenceWardId, request.EmpPlaceOfBirth, request.CompanyId);

            // Create new Employee from request
            Entities.Employee? employee = request.MapTo<Entities.Employee>();
            employee.EmpImage = string.Empty;

            // Hash password
            employee.Password = passwordHasher.HashPassword(request.Password);
            // Begin transaction
            using IDbTransaction transaction = await sqlUnitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                // Marked Employee as Created state
                employeeSqlRepository.Add(employee);

                // Save data to database
                await sqlUnitOfWork.SaveChangesAsync(cancellationToken);

                // Upload Image file employee
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

                // Save changes to persist the updates.
                await sqlUnitOfWork.SaveChangesAsync(cancellationToken);

                // Commit transaction
                transaction.Commit();

                // Return success result
                return Result<object>.Ok();
            }
            catch (Exception)
            {
                // Rollback transaction if any exception happened, then throw exception
                transaction.Rollback();
                throw;
            }
        }
    }
}
