using _365EJSC.ERP.Domain.Abstractions.Aggregates;

namespace _365EJSC.ERP.Domain.Entities.HRM
{
    /// <summary>
    /// Domain entity for Marital with int key type
    /// </summary>
    public class EmployeeRole : AggregateRoot<int>
    {
        /// <summary>
        /// Code of the marital
        /// </summary>
        public string? EmpRoleCode { get; set; }
        /// <summary>
        /// Name of the marital
        /// </summary>
        public string EmpRoleName { get; set; }
    }
}
