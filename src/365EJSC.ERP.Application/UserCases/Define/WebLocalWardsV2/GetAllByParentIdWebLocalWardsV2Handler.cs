using MediatR;
using _365EJSC.ERP.Contract.Shared;
using Entity = _365EJSC.ERP.Domain.Entities.Define.WebLocalWardsV2;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Define;
using _365EJSC.ERP.Application.Requests.Define.WebLocalWardsV2;

namespace _365EJSC.ERP.Application.UserCases.Define.WebLocalWardsV2
{
    public class GetAllByParentIdWebLocalWardsV2Handler : IRequestHandler<GetAllByParentIdWebLocalWardsV2Request, Result<IQueryable<Entity>>>
    {
        private readonly IWebLocalWardsV2SqlRepository webLocalWardsV2Repo;

        public GetAllByParentIdWebLocalWardsV2Handler(IWebLocalWardsV2SqlRepository webLocalWardsV2Repo)
        {
            this.webLocalWardsV2Repo = webLocalWardsV2Repo;
        }

        public async Task<Result<IQueryable<Entity>>> Handle(GetAllByParentIdWebLocalWardsV2Request request, CancellationToken cancellationToken)
        {
            var wards = webLocalWardsV2Repo.FindAll(w => w.WardPid == request.WardPid).AsQueryable();

            return Result<IQueryable<Entity>>.Ok(wards);
        }
    }
}
