using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Define;
using _365EJSC.ERP.Application.Requests.Define.HelpdeskCatalog;
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Exceptions;
using _365EJSC.ERP.Contract.Shared;
using MediatR;
using Entity = _365EJSC.ERP.Domain.Entities.Define.HelpdeskCatalog;

namespace _365EJSC.ERP.Application.UserCases.Define.HelpdeskCatalog
{
    /// <summary>
    /// Handler for <see cref="GetDetailHelpdeskCatalogRequest"/>/ 
    /// </summary>
    public class GetDetailHelpdeskCatalogHandler : IRequestHandler<GetDetailHelpdeskCatalogRequest, Result<Entity>>
    {
        // Repository handle data access of <see cref="Entity"/>>
        private readonly IHelpdeskCatalogSqlRepository helpdeskCatalogRepo;

        /// <summary>
        /// Constructor of <see cref="GetDetailHelpdeskCatalogHandler"/>, inject needed dependency
        /// </summary>
        public GetDetailHelpdeskCatalogHandler(IHelpdeskCatalogSqlRepository helpdeskCatalogRepo)
        {
           this.helpdeskCatalogRepo = helpdeskCatalogRepo;
        }

        /// <summary>
        /// Handle <see cref="GetDetailHelpdeskCatalogRequest"/>, GetDetail the <see cref="Entity"/> from database
        /// </summary>
        /// <param name="request">Request to handle</param>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="Result{TModel}"/> with founded <see cref="Entity"/></returns>
        public async Task<Result<Entity>> Handle(GetDetailHelpdeskCatalogRequest request, CancellationToken cancellationToken)
        {
            // Create validator and validate request
            var validator = new GetDetailHelpdeskCatalogValidator();
            validator.ValidateAndThrow(request);

            // Find HelpdeskCatalog from database, throw NotFoundException when not found
            var helpdeskCatalog = helpdeskCatalogRepo.FindAll(x => x.Id.Equals(request.Id)).FirstOrDefault();
            if(helpdeskCatalog == null)
            {
                CustomException.ThrowNotFoundException(typeof(Entity), MsgCode.ERR_DEFINE_HELPDESK_CATALOG_ID_NOT_FOUND);
            }
            return helpdeskCatalog;
        }
    }
}
