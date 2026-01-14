using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Contract.Abstractions;
using System.Text.Json.Serialization;

namespace _365EJSC.ERP.Application.Requests.Define.WebLocalWardsV2
{
    /// <summary>
    /// Request for Delete <see cref="WebLocalWardsV2"/>
    /// </summary>
    public class DeleteWebLocalWardsV2Request : ICommand
    {
        public int? Id { get; set; }
    }
}
