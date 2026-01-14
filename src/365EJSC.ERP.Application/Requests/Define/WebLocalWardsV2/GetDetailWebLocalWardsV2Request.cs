using _365EJSC.ERP.Contract.Abstractions;
using Entity = _365EJSC.ERP.Domain.Entities.Define.WebLocalWardsV2;

namespace _365EJSC.ERP.Application.Requests.Define.WebLocalWardsV2
{
    /// <summary>
    /// Request for GetDetail <see cref="Entity"/>
    /// </summary>
    public class GetDetailWebLocalWardsV2Request : IQuery<Entity>
    {
        public int? Id {get; set;}
    }
}
