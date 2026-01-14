using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Define;
using _365EJSC.ERP.Application.Requests.Define.HelpdeskContent;
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Exceptions;
using _365EJSC.ERP.Contract.Shared;
using MediatR;
using Entity = _365EJSC.ERP.Domain.Entities.Define.HelpdeskContent;

namespace _365EJSC.ERP.Application.UserCases.Define.HelpdeskContent
{
    /// <summary>
    /// Handler for <see cref="GetAllHelpdeskContentRequest"/>/ 
    /// </summary>
    public class GetAllHelpdeskContentHandler : IRequestHandler<GetAllHelpdeskContentRequest, Result<IQueryable<Entity>>>
    {
        // Repository handle data access of <see cref="Entity"/>>
        private readonly IHelpdeskContentSqlRepository helpdeskContentRepo;

        /// <summary>
        /// Constructor of <see cref="GetAllHelpdeskContentHandler"/>, inject needed dependency
        /// </summary>
        public GetAllHelpdeskContentHandler(IHelpdeskContentSqlRepository helpdeskContentRepo)
        {
           this.helpdeskContentRepo = helpdeskContentRepo;
        }

        /// <summary>
        /// Handle <see cref="GetAllHelpdeskContentRequest"/>, GetAll the <see cref="Entity"/> from database
        /// </summary>
        /// <param name="request">Request to handle</param>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="Result{TModel}"/> with founded <see cref="Entity"/></returns>
        public async Task<Result<IQueryable<Entity>>> Handle(GetAllHelpdeskContentRequest request, CancellationToken cancellationToken)
        {
            // Find HelpdeskContent from database and return
            var data = helpdeskContentRepo.FindAll().AsQueryable();
            return Result<IQueryable<Entity>>.Ok(data);
        }
    }
}
