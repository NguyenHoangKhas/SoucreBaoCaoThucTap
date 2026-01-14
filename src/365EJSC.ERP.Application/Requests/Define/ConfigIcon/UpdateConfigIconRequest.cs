using _365EJSC.ERP.Contract.Abstractions;

namespace _365EJSC.ERP.Application.Requests.Define.ConfigIcon
{
    public class UpdateConfigIconRequest : ICommand
    {
        public string Id { get; private set; }
        public string? IconDescription { get; set; }
        public string? IconUrlBase64 { get; set; }

        public void SetId(string id)
        {
            this.Id = id;
        }
    }
}
