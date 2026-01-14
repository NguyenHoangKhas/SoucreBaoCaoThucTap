using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Contract.Abstractions;
using System.Text.Json.Serialization;

namespace _365EJSC.ERP.Application.Requests.Define.HelpdeskCatalog
{
    /// <summary>
    /// Request for Delete <see cref="HelpdeskCatalog"/>
    /// </summary>
    public class DeleteHelpdeskCatalogRequest : ICommand
    {
        public int? Id { get; set; }
    }
}
