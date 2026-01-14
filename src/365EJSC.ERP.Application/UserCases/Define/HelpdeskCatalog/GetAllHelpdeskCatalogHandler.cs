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
    /// Handler for <see cref="GetAllHelpdeskCatalogRequest"/>/ 
    /// </summary>
    public class GetAllHelpdeskCatalogHandler : IRequestHandler<GetAllHelpdeskCatalogRequest, Result<IQueryable<Entity>>>
    {
        // Repository handle data access of <see cref="Entity"/>>
        private readonly IHelpdeskCatalogSqlRepository helpdeskCatalogRepo;

        /// <summary>
        /// Constructor of <see cref="GetAllHelpdeskCatalogHandler"/>, inject needed dependency
        /// </summary>
        public GetAllHelpdeskCatalogHandler(IHelpdeskCatalogSqlRepository helpdeskCatalogRepo)
        {
           this.helpdeskCatalogRepo = helpdeskCatalogRepo;
        }

        /// <summary>
        /// Handle <see cref="GetAllHelpdeskCatalogRequest"/>, GetAll the <see cref="Entity"/> from database
        /// </summary>
        /// <param name="request">Request to handle</param>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="Result{TModel}"/> with founded <see cref="Entity"/></returns>
        public async Task<Result<IQueryable<Entity>>> Handle(GetAllHelpdeskCatalogRequest request, CancellationToken cancellationToken)
        {
            // Find HelpdeskCatalog from database and return
            var data = helpdeskCatalogRepo.FindAll().AsQueryable();
            return Result<IQueryable<Entity>>.Ok(data);
        }
    }
}
