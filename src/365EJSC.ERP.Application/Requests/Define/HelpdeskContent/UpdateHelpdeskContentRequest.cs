using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Contract.Abstractions;
using System.Text.Json.Serialization;

namespace _365EJSC.ERP.Application.Requests.Define.HelpdeskContent
{
    /// <summary>
    /// Request for Update <see cref="HelpdeskContent"/>
    /// </summary>
    public class UpdateHelpdeskContentRequest : ICommand
    {
        [JsonIgnore]
        public int? Id { get; set; }
        public string? ContentDetail { get; set; }
        public int? CatalogId { get; set; }
    }
}
