using _365EJSC.ERP.Contract.Abstractions;
using Entity = _365EJSC.ERP.Domain.Entities.Define.HelpdeskContent;

namespace _365EJSC.ERP.Application.Requests.Define.HelpdeskContent
{
    /// <summary>
    /// Request for GetDetail <see cref="Entity"/>
    /// </summary>
    public class GetDetailHelpdeskContentRequest : IQuery<Entity>
    {
        public int? Id {get; set;}
    }
}
