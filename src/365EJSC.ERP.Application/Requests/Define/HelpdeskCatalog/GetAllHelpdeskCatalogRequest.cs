using _365EJSC.ERP.Contract.Abstractions;
using Entity = _365EJSC.ERP.Domain.Entities.Define.HelpdeskCatalog;

namespace _365EJSC.ERP.Application.Requests.Define.HelpdeskCatalog
{
    /// <summary>
    /// Request for GetAll <see cref="Entity"/>
    /// </summary>
    public class GetAllHelpdeskCatalogRequest : IQuery<IQueryable<Entity>>
    {
    }
}
