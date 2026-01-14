using _365EJSC.ERP.Application.Validators.Define.WebLocalWardsV2;
using _365EJSC.ERP.Contract.DependencyInjection.Extensions;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Base;
using _365EJSC.ERP.Contract.Abstractions;
using _365EJSC.ERP.Contract.Exceptions;
using _365EJSC.ERP.Contract.Enumerations;
using MediatR;
using Entity = _365EJSC.ERP.Domain.Entities.Define.WebLocalWardsV2;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Define;
using _365EJSC.ERP.Application.Requests.Define.WebLocalWardsV2;

namespace _365EJSC.ERP.Application.UserCases.Define.WebLocalWardsV2
{
    /// <summary>
    /// Handler for <see cref="DeleteWebLocalWardsV2Request"/> 
    /// </summary>
    public class DeleteWebLocalWardsV2Handler : IRequestHandler<DeleteWebLocalWardsV2Request, Result<object>>
    {
        // Repository handle data access of <see cref="Entity"/>>
        private readonly IWebLocalWardsV2SqlRepository webLocalWardsV2Repo;
        // Unit of work to handle transaction
        private readonly ISqlUnitOfWork unitOfWork;

        /// <summary>
        /// Constructor of <see cref="DeleteWebLocalWardsV2Handler"/>, inject needed dependency
        /// </summary>
        public DeleteWebLocalWardsV2Handler(IWebLocalWardsV2SqlRepository webLocalWardsV2Repo, ISqlUnitOfWork unitOfWork)
        {
           this.webLocalWardsV2Repo = webLocalWardsV2Repo;
           this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Handle <see cref="DeleteWebLocalWardsV2Request"/>, Delete the <see cref="Entity"/> base on data <see cref="DeleteWebLocalWardsV2Request"/>
        /// and save to database
        /// </summary>
        /// <param name="request">Request to handle</param>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="Result{TModel}"/> with success status</returns>
        /// <exception cref="Exception"></exception>
        public async Task<Result<object>> Handle(DeleteWebLocalWardsV2Request request, CancellationToken cancellationToken)
        {
            // Create validator and validate request
            var validator = new DeleteWebLocalWardsV2Validator();
            validator.ValidateAndThrow(request);

            // Find WebLocalWardsV2 from database, throw NotFoundException when not found
            var webLocalWardsV2 = await webLocalWardsV2Repo.FindByIdAsync((int)request.Id, true, cancellationToken);
            if(webLocalWardsV2 == null)
                CustomException.ThrowNotFoundException(typeof(Entity), MsgCode.ERR_DEFINE_WEB_LOCAL_WARDS_V2_ID_NOT_FOUND);

            // Begin transaction
            using var transaction = await unitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                // Marked WebLocalWardsV2 as Delete state
                webLocalWardsV2Repo.Remove(webLocalWardsV2);
                // Save data to database
                await unitOfWork.SaveChangesAsync(cancellationToken);

                 // Commit transaction
                 transaction.Commit();
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
