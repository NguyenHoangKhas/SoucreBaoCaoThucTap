using _365EJSC.ERP.Domain.Abstractions.Aggregates;

namespace _365EJSC.ERP.Domain.Entities.HRM
{
    public class EmployeeCompany : AggregateRoot<int>
    {
        /// <summary>
        /// ID of the employee associated with this record.
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// ID of the company department or designation.
        /// </summary>
        public int CdId { get; set; }

        public virtual Employee? Employee { get; set; }
    }
}
