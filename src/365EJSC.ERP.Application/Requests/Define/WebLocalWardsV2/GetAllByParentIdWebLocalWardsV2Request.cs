using MediatR;
using _365EJSC.ERP.Contract.Shared;

namespace _365EJSC.ERP.Application.Requests.Define.WebLocalWardsV2
{
    public class GetAllByParentIdWebLocalWardsV2Request : IRequest<Result<IQueryable<Domain.Entities.Define.WebLocalWardsV2>>>
    {
        public int WardPid { get; set; }
    }
}
