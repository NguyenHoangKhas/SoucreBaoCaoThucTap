using _365EJSC.ERP.Contract.Abstractions;

namespace _365EJSC.ERP.Application.Requests.HRM.DefineContractTypes
{
    public record CreateContractTypeRequest : ICommand
    {
        public string? ContractTypeCode { get; set; }
        public string? ContractTypeName { get; set; }
    }
}
