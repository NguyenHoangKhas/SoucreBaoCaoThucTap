using _365EJSC.ERP.Application.Requests.Define.ConfigIcon;
using _365EJSC.ERP.Application.Validators.Define.ConfigIcon;
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Exceptions;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Base;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Define;
using _365EJSC.ERP.Domain.Constants.Define;
using MediatR;
using System.Data;
using Entities = _365EJSC.ERP.Domain.Entities.Define;

namespace _365EJSC.ERP.Application.UserCases.Define.ConfigIcon
{
    /// <summary>
    ///  Handler for <see cref="DeleteConfigIconRequest"/>
    /// </summary>
    public class DeleteConfigIconHandler : IRequestHandler<DeleteConfigIconRequest, Result<object>>
    {
        private readonly IConfigIconSqlRepository configIconSqlRepository;
        private readonly ISqlUnitOfWork sqlUnitOfWork;

        public DeleteConfigIconHandler(IConfigIconSqlRepository configIconSqlRepository, ISqlUnitOfWork sqlUnitOfWork)
        {
            this.configIconSqlRepository = configIconSqlRepository;
            this.sqlUnitOfWork = sqlUnitOfWork;
        }

        /// <summary>
        /// Handle <see cref="DeleteConfigIconRequest"/>, delete <see cref="Entities.ConfigIcon"/> base on data <see cref="DeleteConfigIconRequest"/>
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Result<object>> Handle(DeleteConfigIconRequest request, CancellationToken cancellationToken)
        {
            // Create validator and validate request
            DeleteConfigIconValidator validator = new();
            validator.ValidateAndThrow(request);

            // Find sample base on id provided from database, if sample was not found, throw not found exception.
            // Need tracking to delete ConfigIcon.
            var configIcon = await configIconSqlRepository.FindByIdAsync(request.Id, true, cancellationToken);
            if (configIcon is null)
                CustomException.ThrowNotFoundException(typeof(Entities.ConfigIcon), MsgCode.ERR_KEY_CONFIG_ICON_NOT_FOUND, ConfigIconConst.MSG_KEY_CONFIG_ICON_NOT_FOUND);

            // Begin transaction
            using IDbTransaction transaction = await sqlUnitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                // Marked sample as Deleted state
                configIconSqlRepository.Remove(configIcon!);

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
