using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Contract.Abstractions;
using System.Text.Json.Serialization;

namespace _365EJSC.ERP.Application.Requests.Define.HelpdeskContent
{
    /// <summary>
    /// Request for Create <see cref="HelpdeskContent"/>
    /// </summary>
    public class CreateHelpdeskContentRequest : ICommand
    {
        public string? ContentDetail { get; set; }
        public int? CatalogId { get; set; }
    }
}
