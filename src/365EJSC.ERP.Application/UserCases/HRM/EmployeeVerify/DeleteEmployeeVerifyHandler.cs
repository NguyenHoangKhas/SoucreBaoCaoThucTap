using _365EJSC.ERP.Application.Requests.HRM.EmployeeVerify;
using _365EJSC.ERP.Application.Validators.HRM.EmployeeVerify;
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Exceptions;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Base;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.HRM;
using MediatR;
using System.Data;
using Entities = _365EJSC.ERP.Domain.Entities.HRM;

namespace _365EJSC.ERP.Application.UserCases.HRM.EmployeeVerify
{
    public class DeleteEmployeeVerifyHandler : IRequestHandler<DeleteEmployeeVerifyRequest, Result<object>>
    {
        /// <summary>
        /// Repo/// Repository handle data access of <see cref="HrmEmployee"/>>  /// </summary>
        private readonly IEmployeeVerifySqlRepository EmployeeVerifySqlRepository;

        /// <summary>
        /// Unit of work to handle transaction
        /// </summary>
        private readonly ISqlUnitOfWork sqlUnitOfWork;

        public DeleteEmployeeVerifyHandler(IEmployeeVerifySqlRepository EmployeeVerifySqlRepository, ISqlUnitOfWork sqlUnitOfWork)
        {
            this.EmployeeVerifySqlRepository = EmployeeVerifySqlRepository;
            this.sqlUnitOfWork = sqlUnitOfWork;
        }
        /// <summary>
        /// Handle <see cref="DeleteWebLocalRequests"/>, find existing <see cref="Marital"/> base on id provided in <see cref="DeleteWebLocalRequests"/>,
        /// delete founded <see cref="Marital"/> and save to database
        /// </summary>
        /// <param name="request">Request to handle</param>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="Result{TModel}"/> with success status</returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="CustomException"></exception>
        public async Task<Result<object>> Handle(DeleteEmployeeVerifyRequest request, CancellationToken cancellationToken)
        {
            // Create validator and validate request
            DeleteEmployeeVerifyValidator validator = new();
            validator.ValidateAndThrow(request);

            // Find sample base on id provided from database, if sample was not found, throw not found exception.
            // Need tracking to delete sample.
            Entities.EmployeeVerify? employeeverify = await EmployeeVerifySqlRepository.FindByIdAsync((int)request.Id, true, cancellationToken);
            if (employeeverify is null) CustomException.ThrowNotFoundException(typeof(Entities.EmployeeVerify), MsgCode.ERR_EMPLOYEE_VERIFY_ID_NOT_FOUND);
           
            // Begin transaction
            using IDbTransaction transaction = await sqlUnitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                // Marked sample as Deleted state
                employeeverify.IsActived = 2;
                EmployeeVerifySqlRepository.Update(employeeverify);

                // Save changes to database
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
