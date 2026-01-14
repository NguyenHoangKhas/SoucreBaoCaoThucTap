using _365EJSC.ERP.Contract.Abstractions;
using Entity = _365EJSC.ERP.Domain.Entities.Define.HelpdeskCatalog;

namespace _365EJSC.ERP.Application.Requests.Define.HelpdeskCatalog
{
    /// <summary>
    /// Request for GetDetail <see cref="Entity"/>
    /// </summary>
    public class GetDetailHelpdeskCatalogRequest : IQuery<Entity>
    {
        public int? Id {get; set;}
    }
}
