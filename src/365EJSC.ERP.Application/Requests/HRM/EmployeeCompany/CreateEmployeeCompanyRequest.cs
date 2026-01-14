using _365EJSC.ERP.Contract.Abstractions;

namespace _365EJSC.ERP.Application.Requests.HRM.EmployeeCompany
{
    public record CreateEmployeeCompanyRequest : ICommand
    {
        /// <summary>
        /// ID of the employee to associate with the company/department.
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// ID of the company department or designation.
        /// </summary>
        public int CdId { get; set; }
    }
}
