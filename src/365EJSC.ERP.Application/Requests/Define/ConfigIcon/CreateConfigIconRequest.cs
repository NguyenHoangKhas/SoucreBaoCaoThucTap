using _365EJSC.ERP.Contract.Abstractions;

namespace _365EJSC.ERP.Application.Requests.Define.ConfigIcon
{
    public class CreateConfigIconRequest : ICommand
    {
        public string Id { get; set; }
        public string IconDescription { get; set; }
        public string IconUrlBase64 { get; set; }
    }
}
