using _365EJSC.ERP.Contract.Abstractions;

namespace _365EJSC.ERP.Application.Requests.Define.ConfigIcon
{
    public class GetDetailConfigIconRequest : IQuery<Domain.Entities.Define.ConfigIcon>
    {
        public string Id { get; set; }
    }
}
