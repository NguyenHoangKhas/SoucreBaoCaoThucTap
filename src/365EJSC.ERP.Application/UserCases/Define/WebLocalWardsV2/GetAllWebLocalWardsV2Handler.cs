using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Exceptions;
using _365EJSC.ERP.Contract.Shared;
using MediatR;
using Entity = _365EJSC.ERP.Domain.Entities.Define.WebLocalWardsV2;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Define;
using _365EJSC.ERP.Application.Requests.Define.WebLocalWardsV2;

namespace _365EJSC.ERP.Application.UserCases.Define.WebLocalWardsV2
{
    /// <summary>
    /// Handler for <see cref="GetAllWebLocalWardsV2Request"/>/ 
    /// </summary>
    public class GetAllWebLocalWardsV2Handler : IRequestHandler<GetAllWebLocalWardsV2Request, Result<IQueryable<Entity>>>
    {
        // Repository handle data access of <see cref="Entity"/>>
        private readonly IWebLocalWardsV2SqlRepository webLocalWardsV2Repo;

        /// <summary>
        /// Constructor of <see cref="GetAllWebLocalWardsV2Handler"/>, inject needed dependency
        /// </summary>
        public GetAllWebLocalWardsV2Handler(IWebLocalWardsV2SqlRepository webLocalWardsV2Repo)
        {
           this.webLocalWardsV2Repo = webLocalWardsV2Repo;
        }

        /// <summary>
        /// Handle <see cref="GetAllWebLocalWardsV2Request"/>, GetAll the <see cref="Entity"/> from database
        /// </summary>
        /// <param name="request">Request to handle</param>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="Result{TModel}"/> with founded <see cref="Entity"/></returns>
        public async Task<Result<IQueryable<Entity>>> Handle(GetAllWebLocalWardsV2Request request, CancellationToken cancellationToken)
        {
            // Find WebLocalWardsV2 from database and return
            var data = webLocalWardsV2Repo.FindAll().AsQueryable();
            return Result<IQueryable<Entity>>.Ok(data);
        }
    }
}
