using _365EJSC.ERP.Contract.Abstractions;
using System.Text.Json.Serialization;

namespace _365EJSC.ERP.Application.Requests.HRM.EmployeeCompany
{
    public class UpdateEmployeeCompanyRequest : ICommand
    {
        [JsonIgnore]
        public int Id { get; set; }
        /// <summary>
        /// ID of the employee to associate with the company/department.
        /// </summary>
        public int? EmployeeId { get; set; }

        /// <summary>
        /// ID of the company department or designation.
        /// </summary>
        public int? CdId { get; set; }
    }
}
