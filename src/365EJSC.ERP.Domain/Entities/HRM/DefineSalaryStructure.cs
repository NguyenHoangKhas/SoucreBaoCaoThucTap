using _365EJSC.ERP.Domain.Abstractions.Aggregates;

namespace _365EJSC.ERP.Domain.Entities.HRM
{
    /// <summary>
    /// Domain entity with int key type
    /// </summary>
    public class DefineSalaryStructure : AggregateRoot<int>
    {
        public string? SalaryStructCode { get; set; }
        public string SalaryStructName { get; set; }
    }
}