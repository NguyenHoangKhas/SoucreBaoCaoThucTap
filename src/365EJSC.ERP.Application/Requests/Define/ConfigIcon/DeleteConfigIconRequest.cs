using _365EJSC.ERP.Contract.Abstractions;

namespace _365EJSC.ERP.Application.Requests.Define.ConfigIcon
{
    public class DeleteConfigIconRequest : ICommand
    {
        public string Id { get; set; }
    }
}
