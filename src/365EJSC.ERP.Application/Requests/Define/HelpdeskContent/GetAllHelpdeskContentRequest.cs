using _365EJSC.ERP.Contract.Abstractions;
using Entity = _365EJSC.ERP.Domain.Entities.Define.HelpdeskContent;

namespace _365EJSC.ERP.Application.Requests.Define.HelpdeskContent
{
    /// <summary>
    /// Request for GetAll <see cref="Entity"/>
    /// </summary>
    public class GetAllHelpdeskContentRequest : IQuery<IQueryable<Entity>>
    {
    }
}
