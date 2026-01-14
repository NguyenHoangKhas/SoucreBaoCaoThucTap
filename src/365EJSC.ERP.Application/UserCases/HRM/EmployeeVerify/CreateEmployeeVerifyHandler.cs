using _365EJSC.ERP.Application.Requests.HRM.EmployeeVerify;
using _365EJSC.ERP.Application.Validators.HRM.EmployeeVerify;
using _365EJSC.ERP.Contract.Abstractions;
using _365EJSC.ERP.Contract.Constants;
using _365EJSC.ERP.Contract.DependencyInjection.Extensions;
using _365EJSC.ERP.Contract.DTOs;
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Exceptions;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Base;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.HRM;
using _365EJSC.ERP.Domain.Constants.HRM;
using MediatR;
using System.Data;
using Entities = _365EJSC.ERP.Domain.Entities.HRM;

namespace _365EJSC.ERP.Application.UserCases.HRM.EmployeeVerify
{
    public class CreateEmployeeVerifyHandler : IRequestHandler<CreateEmployeeVerifyRequest, Result<object>>
    {
        private readonly IEmployeeVerifySqlRepository employeeVerifySqlRepository;
        private readonly IEmployeeSqlRepository employeeSqlRepository;
        private readonly ISqlUnitOfWork sqlUnitOfWork;
        private readonly IFileService fileService;

        public CreateEmployeeVerifyHandler(IEmployeeVerifySqlRepository employeeVerifySqlRepository,
                                           ISqlUnitOfWork sqlUnitOfWork,
                                           IEmployeeSqlRepository employeeSqlRepository,
                                           IFileService fileService)
        {
            this.employeeVerifySqlRepository = employeeVerifySqlRepository;
            this.sqlUnitOfWork = sqlUnitOfWork;
            this.employeeSqlRepository = employeeSqlRepository;
            this.fileService = fileService;
        }

        /// <summary>
        /// Handle <see cref="CreateEmployeeVerifyHandler"/>, find existing <see cref="HrmMaritals"/> base on id provided in <see cref="CreateEmployeeVerifyHandler"/>,
        /// update founded <see cref="HrmMaritals"/> base on data provided in <see cref="CreateEmployeeVerifyHandler"/> and save to database
        /// </summary>
        /// <param name="request">Request to handle</param>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="Result{TModel}"/> with success status</returns>
        /// <exception cref="Exception"></exception>
        /// <exc/// <exception cref="CustomException"></exception>
        public async Task<Result<object>> Handle(CreateEmployeeVerifyRequest request, CancellationToken cancellationToken)
        {
            // Create validator and validate request
            CreateEmployeeVerifyValidator validator = new();
            validator.ValidateAndThrow(request);

            if (request.EmployeeId != null) { var degreeExists = await employeeSqlRepository.IsExistAsync(x => x.Id == request.EmployeeId); if (!degreeExists) { CustomException.ThrowNotFoundException(typeof(Entities.Degree), MsgCode.ERR_EMPLOYEE_ID_NOT_FOUND, EmployeeVerifyConst.MSG_VERIFY_ID_NOT_FOUND); } }

            // Create new employee from request
            Entities.EmployeeVerify? employeeVerify = request.MapTo<Entities.EmployeeVerify>();

            // Begin transaction
            using IDbTransaction transaction = await sqlUnitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                // Marked employee as Created state
                employeeVerifySqlRepository.Add(employeeVerify);

                // Save data to database
                await sqlUnitOfWork.SaveChangesAsync(cancellationToken);

                // Upload Image file employee verify
                if (!string.IsNullOrEmpty(request.VerImageBase64))
                {
                    UploadFileRequest uploadFileRequest = new UploadFileRequest()
                    {
                        Content = request.VerImageBase64,
                        FileName = string.Format(Const.FILENAME_EMPLOYEE_VERIFY, employeeVerify.EmployeeId, employeeVerify.Id),
                        enumOptionPath = EnumOptionPath.EmployeeVerify,
                    };
                    employeeVerify.VerImage = await fileService.UploadFileAsync(uploadFileRequest);
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
