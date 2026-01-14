using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Contract.Abstractions;
using System.Text.Json.Serialization;

namespace _365EJSC.ERP.Application.Requests.Define.HelpdeskCatalog
{
    /// <summary>
    /// Request for Update <see cref="HelpdeskCatalog"/>
    /// </summary>
    public class UpdateHelpdeskCatalogRequest : ICommand
    {
        [JsonIgnore]
        public int? Id { get; set; }
        public string? KeyCatalog { get; set; }
        public string? NameVn { get; set; }
        public string? Url { get; set; }
        public bool? IsActived { get; set; }
    }
}
