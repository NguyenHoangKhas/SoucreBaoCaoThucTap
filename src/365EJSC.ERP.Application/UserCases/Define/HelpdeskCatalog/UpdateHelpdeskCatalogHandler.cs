using _365EJSC.ERP.Application.Requests.Define.HelpdeskCatalog;
using _365EJSC.ERP.Application.Validators.Define.HelpdeskCatalog;
using _365EJSC.ERP.Contract.DependencyInjection.Extensions;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Base;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Define;
using _365EJSC.ERP.Contract.Abstractions;
using _365EJSC.ERP.Contract.Exceptions;
using _365EJSC.ERP.Contract.Enumerations;
using MediatR;
using Entity = _365EJSC.ERP.Domain.Entities.Define.HelpdeskCatalog;

namespace _365EJSC.ERP.Application.UserCases.Define.HelpdeskCatalog
{
    /// <summary>
    /// Handler for <see cref="UpdateHelpdeskCatalogRequest"/> 
    /// </summary>
    public class UpdateHelpdeskCatalogHandler : IRequestHandler<UpdateHelpdeskCatalogRequest, Result<object>>
    {
        // Repository handle data access of <see cref="Entity"/>>
        private readonly IHelpdeskCatalogSqlRepository helpdeskCatalogRepo;
        // Unit of work to handle transaction
        private readonly ISqlUnitOfWork unitOfWork;

        /// <summary>
        /// Constructor of <see cref="UpdateHelpdeskCatalogHandler"/>, inject needed dependency
        /// </summary>
        public UpdateHelpdeskCatalogHandler(IHelpdeskCatalogSqlRepository helpdeskCatalogRepo, ISqlUnitOfWork unitOfWork)
        {
           this.helpdeskCatalogRepo = helpdeskCatalogRepo;
           this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Handle <see cref="UpdateHelpdeskCatalogRequest"/>, Update the <see cref="Entity"/> base on data <see cref="UpdateHelpdeskCatalogRequest"/>
        /// and save to database
        /// </summary>
        /// <param name="request">Request to handle</param>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="Result{TModel}"/> with success status</returns>
        /// <exception cref="Exception"></exception>
        public async Task<Result<object>> Handle(UpdateHelpdeskCatalogRequest request, CancellationToken cancellationToken)
        {
            // Create validator and validate request
            var validator = new UpdateHelpdeskCatalogValidator();
            validator.ValidateAndThrow(request);

            // Find HelpdeskCatalog from database, throw NotFoundException when not found
            var helpdeskCatalog = await helpdeskCatalogRepo.FindByIdAsync((int)request.Id, true, cancellationToken);
            if(helpdeskCatalog == null)
                CustomException.ThrowNotFoundException(typeof(Entity), MsgCode.ERR_DEFINE_HELPDESK_CATALOG_ID_NOT_FOUND);
            request.MapTo(helpdeskCatalog, true);

            // Begin transaction
            using var transaction = await unitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                // Marked HelpdeskCatalog as Update state
                helpdeskCatalogRepo.Update(helpdeskCatalog);
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
