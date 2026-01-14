using _365EJSC.ERP.Contract.Abstractions;
using System.Text.Json.Serialization;

namespace _365EJSC.ERP.Application.Requests.HRM.DefineContractTypes
{
    public record UpdateContractTypeRequest : ICommand
    {
        [JsonIgnore]
        public int? Id { get; set; }
        public string? ContractTypeCode { get; set; }
        public string? ContractTypeName { get; set; }
    }
}
