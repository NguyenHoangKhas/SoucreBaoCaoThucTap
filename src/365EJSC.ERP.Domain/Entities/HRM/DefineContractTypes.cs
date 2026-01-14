using _365EJSC.ERP.Domain.Abstractions.Aggregates;

namespace _365EJSC.ERP.Domain.Entities.HRM
{
    public class DefineContractTypes : AggregateRoot<int>
    {
        public string? ContractTypeCode { get; set; }
        public string ContractTypeName { get; set; }
    }
}
