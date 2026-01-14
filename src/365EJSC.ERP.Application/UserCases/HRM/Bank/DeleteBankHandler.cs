using _365EJSC.ERP.Application.Requests.HRM.Bank;
using _365EJSC.ERP.Application.Validators.HRM.Bank;
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Exceptions;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Base;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.HRM;
using _365EJSC.ERP.Domain.Constants.HRM;
using MediatR;
using System.Data;

namespace _365EJSC.ERP.Application.UserCases.HRM.Bank
{
    public class DeleteBankHandler : IRequestHandler<DeleteBankRequest, Result<object>>
    {
        /// <summary>
        /// Repo/// Repository handle data access of <see cref="Domain.Entities.HRM.Bank"/>>  /// </summary>
        private readonly IBankSqlRepository bankSqlRepository;
        //private readonly ICustomerCatalogSqlRepository customerCatalogSqlRepository;
        /// <summary>
        /// Unit of work to handle transaction
        /// </summary>
        private readonly ISqlUnitOfWork sqlUnitOfWork;

        public DeleteBankHandler(IBankSqlRepository bankSqlRepository, ISqlUnitOfWork sqlUnitOfWork
            //, ICustomerCatalogSqlRepository customerCatalogSqlRepository
            )
        {
            this.bankSqlRepository = bankSqlRepository;
            this.sqlUnitOfWork = sqlUnitOfWork;
            //this.customerCatalogSqlRepository = customerCatalogSqlRepository;
        }

        /// <summary>
        /// Constructor of <see cref="DeleteBankHandler"/>, inject needed dependency
        /// </summary>


        /// <summary>
        /// Handle <see cref="DeleteBankRequest"/>, find existing <see cref="Domain.Entities.HRM.Bank"/> base on id provided in <see cref="DeleteBankRequest"/>,
        /// delete founded <see cref="Domain.Entities.HRM.Bank"/> and save to database
        /// </summary>
        /// <param name="request">Request to handle</param>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="Result{TModel}"/> with success status</returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="CustomException"></exception>
        public async Task<Result<object>> Handle(DeleteBankRequest request, CancellationToken cancellationToken)
        {
            // Create validator and validate request
            DeleteBankValidator validator = new();
            validator.ValidateAndThrow(request);
            //bool isInUse = await customerCatalogSqlRepository.IsExistAsync(x => x.BankId == request.Id, cancellationToken);

            //if (isInUse) CustomException.ThrowConflictException(MsgCode.ERR_BANK_IN_USE, BankConst.MSG_BANK_ID_ID_IN_USE);

            // Find bank base on id provided from database, if bank was not found, throw not found exception.
            // Need tracking to delete bank.
            Domain.Entities.HRM.Bank? bank = await bankSqlRepository.FindByIdAsync((int)request.Id, true, cancellationToken);
            if (bank is null) CustomException.ThrowNotFoundException(typeof(Domain.Entities.HRM.Bank), MsgCode.ERR_BANK_ID_NOT_FOUND);
            // Begin transaction
            using IDbTransaction transaction = await sqlUnitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                // Marked sample as Deleted state
                bankSqlRepository.Remove(bank);

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
