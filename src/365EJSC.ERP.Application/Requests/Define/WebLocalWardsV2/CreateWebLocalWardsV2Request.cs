using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Contract.Abstractions;
using System.Text.Json.Serialization;

namespace _365EJSC.ERP.Application.Requests.Define.WebLocalWardsV2
{
    /// <summary>
    /// Request for Create <see cref="WebLocalWardsV2"/>
    /// </summary>
    public class CreateWebLocalWardsV2Request : ICommand
    {
        public string? Name { get; set; }
        public string? NameEn { get; set; }
        public string? FullName { get; set; }
        public string? FullNameEn { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public int? WardPid { get; set; }
        public string? KeyLocalization { get; set; }

        // Danh sách ward con
        public List<CreateWebLocalWardsV2Request>? ChildWards { get; set; }
    }

}
