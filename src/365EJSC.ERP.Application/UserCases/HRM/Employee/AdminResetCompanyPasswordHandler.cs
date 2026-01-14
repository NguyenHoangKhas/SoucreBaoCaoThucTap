using _365EJSC.ERP.Application.Requests.HRM.Employee;
using _365EJSC.ERP.Application.Validators.HRM.Employee;
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Exceptions;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Base;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql;
using MediatR;
using System.Data;
using Entities = _365EJSC.ERP.Domain.Entities.HRM;
using _365EJSC.ERP.Contract.DTOs;
using Microsoft.Extensions.Options;
using _365EJSC.ERP.Contract.Abstractions;

namespace _365EJSC.ERP.Application.UserCases.HRM.Employee
{
    /// <summary>
    /// Handler for <see cref="AdminResetEmployeePasswordRequest"/>
    /// </summary>
    public class AdminResetEmployeePasswordHandler : IRequestHandler<AdminResetEmployeePasswordRequest, Result<object>>
    {
        /// <summary>
        /// Repository to handle data access of <see cref="Entities.Employee"/>
        /// </summary>
        private readonly IEmployeeSqlRepository employeeSqlRepository;

        /// <summary>
        /// Unit of work to handle transaction
        /// </summary>
        private readonly ISqlUnitOfWork sqlUnitOfWork;

        /// <summary>
        /// Default password to get default password for reset
        /// </summary>
        private readonly string defaultPassword;

        private readonly IPasswordHasher passwordHasher;

        /// <summary>
        /// Constructor of <see cref="AdminResetEmployeePasswordHandler"/>, inject needed dependency
        /// </summary>
        public AdminResetEmployeePasswordHandler(IEmployeeSqlRepository employeeSqlRepository, ISqlUnitOfWork sqlUnitOfWork, IOptions<DomainHostsDTOs> defaultPasswordDTOs, IPasswordHasher passwordHasher)
        {
            this.employeeSqlRepository = employeeSqlRepository;
            this.sqlUnitOfWork = sqlUnitOfWork;
            this.defaultPassword = defaultPasswordDTOs.Value.DefaultPassword;
            this.passwordHasher = passwordHasher;
        }

        /// <summary>
        /// Handle <see cref="AdminResetEmployeePasswordRequest"/>, reset the password of an existing <see cref="EntitiesDefine.GeneralEmployee"/>
        /// based on the provided ID and save to database
        /// </summary>
        /// <param name="request">Request to handle</param>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="Result{TModel}"/> with success status</returns>
        /// <exception cref="Exception"></exception>
        public async Task<Result<object>> Handle(AdminResetEmployeePasswordRequest request, CancellationToken cancellationToken)
        {
            // Create validator and validate request
            AdminResetEmployeePasswordValidator validator = new();
            validator.ValidateAndThrow(request);

            // Find existing employee by ID
            var employee = await employeeSqlRepository.FindByIdAsync(request.Id, true, cancellationToken);
            if (employee is null)
                CustomException.ThrowNotFoundException(typeof(Entities.Employee), MsgCode.ERR_EMPLOYEE_ID_NOT_FOUND);

            // Generate new default password
            var newPassword = defaultPassword;

            // Begin transaction
            using IDbTransaction transaction = await sqlUnitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                // Hash and update password
                employee!.Password = passwordHasher.HashPassword(newPassword);
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
