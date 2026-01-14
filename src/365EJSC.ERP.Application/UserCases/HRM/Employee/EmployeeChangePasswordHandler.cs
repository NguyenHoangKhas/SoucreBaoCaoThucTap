using _365EJSC.ERP.Application.Requests.HRM.Employee;
using _365EJSC.ERP.Application.Validators.HRM.Employee;
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Exceptions;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Base;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Data;
using Entities = _365EJSC.ERP.Domain.Entities.HRM;
using _365EJSC.ERP.Contract.Abstractions;

namespace _365EJSC.ERP.Application.UserCases.HRM.Employee
{
    /// <summary>
    /// Handler for <see cref="EmployeeChangePasswordRequest"/>
    /// </summary>
    public class EmployeeChangePasswordHandler : IRequestHandler<EmployeeChangePasswordRequest, Result<object>>
    {
        /// <summary>
        /// Repository to handle data access of <see cref="Entities.Employee"/>
        /// </summary>
        private readonly IEmployeeSqlRepository employeeSqlRepository;

        /// <summary>
        /// Unit of work to handle transaction
        /// </summary>
        private readonly ISqlUnitOfWork sqlUnitOfWork;

        private readonly IPasswordHasher passwordHasher;

        /// <summary>
        /// Constructor of <see cref="EmployeeChangePasswordHandler"/>, inject needed dependency
        /// </summary>
        public EmployeeChangePasswordHandler(IEmployeeSqlRepository employeeSqlRepository, ISqlUnitOfWork sqlUnitOfWork, IPasswordHasher passwordHasher)
        {
            this.employeeSqlRepository = employeeSqlRepository;
            this.sqlUnitOfWork = sqlUnitOfWork;
            this.passwordHasher = passwordHasher;
        }

        /// <summary>
        /// Handle <see cref="EmployeeChangePasswordRequest"/>, update the password of an existing <see cref="Entities.Employee"/>
        /// based on data from <see cref="EmployeeChangePasswordRequest"/> and save to database
        /// </summary>
        /// <param name="request">Request to handle</param>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="Result{TModel}"/> with success status</returns>
        /// <exception cref="Exception"></exception>
        public async Task<Result<object>> Handle(EmployeeChangePasswordRequest request, CancellationToken cancellationToken)
        {
            // Create validator and validate request
            EmployeeChangePasswordValidator validator = new();
            validator.ValidateAndThrow(request);

            // Find existing employee by ID
            var employee = await employeeSqlRepository.FindByIdAsync(request.Id, true, cancellationToken);
            if (employee is null)
                CustomException.ThrowNotFoundException(typeof(Entities.Employee), MsgCode.ERR_EMPLOYEE_ID_NOT_FOUND);

            // Verify old password
            if (!passwordHasher.VerifyPassword(request.OldPassword, employee.Password))
                CustomException.ThrowException((int)StatusCodes.Status400BadRequest, MsgCode.ERR_EMPLOYEE_PASSWORD_INCORRECT);

            // Verify new password match confirmation
            if (request.NewPassword != request.ConfirmNewPassword)
                CustomException.ThrowException((int)StatusCodes.Status400BadRequest, MsgCode.ERR_EMPLOYEE_NEW_PASSWORD_NOT_MATCH);

            // Begin transaction
            using IDbTransaction transaction = await sqlUnitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                // Hash new password and update
                employee.Password = passwordHasher.HashPassword(request.NewPassword);
                employeeSqlRepository.Update(employee);

                // Save changes
                await sqlUnitOfWork.SaveChangesAsync(cancellationToken);
                transaction.Commit();

                return Result<object>.Ok();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }
    }

}
