using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Contract.Abstractions;
using System.Text.Json.Serialization;

namespace _365EJSC.ERP.Application.Requests.Define.HelpdeskContent
{
    /// <summary>
    /// Request for Delete <see cref="HelpdeskContent"/>
    /// </summary>
    public class DeleteHelpdeskContentRequest : ICommand
    {
        public int? Id { get; set; }
    }
}
