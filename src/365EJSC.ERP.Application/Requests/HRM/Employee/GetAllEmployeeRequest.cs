using _365EJSC.ERP.Contract.Abstractions;
using _365EJSC.ERP.Contract.Shared;

namespace _365EJSC.ERP.Application.Requests.HRM.Employee
{

    /// <summary>
    /// Request to get all existed <see cref="EmployeeDto"/> from database, can limit records or skip a number of records
    /// </summary>
    public class GetAllEmployeeRequest : PaginationOptionalQuery, IQuery<object>
    {
        /// <summary>
        /// Search by employee name
        /// </summary>
        public string? EmpName { get; set; }

        /// <summary>
        /// Search by employee code
        /// </summary>
        public string? EmpCode { get; set; }

        public int? DegreeId { get; set; }

        /// <summary>
        /// Request Training Major ID Reference
        /// </summary>
        public int? TraMajId { get; set; }

        /// <summary>
        /// Bank ID Reference
        /// </summary>
        public int? BankId { get; set; }

        /// <summary>
        /// Request Nation ID Reference
        /// </summary>
        public int? NationId { get; set; }

        /// <summary>
        /// Request Religion ID Reference
        /// </summary>
        public int? ReligionId { get; set; }

        /// <summary>
        /// Request Marital Status ID Reference
        /// </summary>
        public int? MaritalId { get; set; }

        /// <summary>
        /// Request Employee Role ID Reference
        /// </summary>
        public int? EmpRoleId { get; set; }

        /// <summary>
        /// Request Country ID
        /// </summary>
        public string? CountryId { get; set; }

        /// <summary>
        /// Request EmpPlaceOfBirth ID
        /// </summary>
        public int? EmpPlaceOfBirth { get; set; }
        /// <summary>
        /// Request empPlaceOfResidenceWard ID
        /// </summary>
        public int? EmpPlaceOfResidenceWardId { get; set; }

        public int? CompanyId { get; set; }

        /// <summary>
        /// Request IsActived
        /// </summary>
        public int? IsActived { get; set; }

    }
}
