using _365EJSC.ERP.Contract.Abstractions;
using Entity = _365EJSC.ERP.Domain.Entities.Define.WebLocalWardsV2;

namespace _365EJSC.ERP.Application.Requests.Define.WebLocalWardsV2
{
    /// <summary>
    /// Request for GetAll <see cref="Entity"/>
    /// </summary>
    public class GetAllWebLocalWardsV2Request : IQuery<IQueryable<Entity>>
    {
    }
}
