using _365EJSC.ERP.Domain.Abstractions.Aggregates;

namespace _365EJSC.ERP.Domain.Entities.HRM
{
    public class Bank : AggregateRoot<int>
    {
        public string BankName { get; set; }
    }
}
