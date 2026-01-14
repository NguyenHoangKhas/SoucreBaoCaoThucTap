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
    public class UpdateEmployeeVerifyHandler : IRequestHandler<UpdateEmployeeVerifyRequest, Result<object>>
    {
        private readonly IEmployeeVerifySqlRepository employeeVerifySqlRepository;
        private readonly IEmployeeSqlRepository employeeSqlRepository;
        private readonly ISqlUnitOfWork sqlUnitOfWork;
        private readonly IFileService fileService;

        public UpdateEmployeeVerifyHandler(IEmployeeVerifySqlRepository employeeVerifySqlRepository, 
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
        /// Handle <see cref="UpdateEmployeeVerifyRequest"/>, find existing <see cref="HrmMaritals"/> base on id provided in <see cref="UpdateEmployeeVerifyRequest"/>,
        /// update founded <see cref="HrmMaritals"/> base on data provided in <see cref="UpdateEmployeeVerifyRequest"/> and save to database
        /// </summary>
        /// <param name="request">Request to handle</param>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="Result{TModel}"/> with success status</returns>
        /// <exception cref="Exception"></exception>
        /// <exc/// <exception cref="CustomException"></exception>
        public async Task<Result<object>> Handle(UpdateEmployeeVerifyRequest request, CancellationToken cancellationToken)
        {
            // Create validator and validate request
            UpdateEmployeeVerifyValidator validator = new();
            validator.ValidateAndThrow(request);

            if (request.EmployeeId != null) { var degreeExists = await employeeSqlRepository.IsExistAsync(x => x.Id == request.EmployeeId); if (!degreeExists) { CustomException.ThrowNotFoundException(typeof(Entities.Degree), MsgCode.ERR_EMPLOYEE_ID_NOT_FOUND, EmployeeVerifyConst.MSG_VERIFY_ID_NOT_FOUND); } }

            // Find marital base on id provided from database, if marital was not found, throw not found exception.
            // Need tracking to update Local.
            Entities.EmployeeVerify? employeeVerify = await employeeVerifySqlRepository.FindByIdAsync(request.Id.Value, true, cancellationToken);
            if (employeeVerify is null) CustomException.ThrowNotFoundException(typeof(Entities.EmployeeVerify), MsgCode.ERR_EMPLOYEE_ID_NOT_FOUND);

            // Update marital base on data provided in UpdateHrmMaritalRequest.
            // Keep marital original data if request fields is null
            request.MapTo(employeeVerify, true);

            // Begin transaction
            using IDbTransaction transaction = await sqlUnitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
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

                // Mark marital as Updated state
                employeeVerifySqlRepository.Update(employeeVerify!);

                // Save marital to database
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
