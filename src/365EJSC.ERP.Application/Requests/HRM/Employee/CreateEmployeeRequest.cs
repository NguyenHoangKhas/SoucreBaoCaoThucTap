using _365EJSC.ERP.Contract.Abstractions;

namespace _365EJSC.ERP.Application.Requests.HRM.Employee
{
    /// <summary>
    /// Request to create a TrainingMajor, contains name
    /// </summary>
    public record CreateEmployeeRequest : ICommand
    {
        /// <summary>
        /// Request Citizen Identity of Employee
        /// </summary>
        public string? EmpCitizenIdentity { get; set; }

        /// <summary>
        /// Request Tax Code of Employee
        /// </summary>
        public string? EmpTaxCode { get; set; }

        /// <summary>
        /// Request Employee Code
        /// </summary>
        public string? EmpCode { get; set; }

        /// <summary>
        /// Request First Name of Employee
        /// </summary>
        public string? EmpFirstName { get; set; }

        /// <summary>
        /// Request Last Name of Employee
        /// </summary>
        public string? EmpLastName { get; set; }

        /// <summary>
        /// Request Gender of Employee (false: Male, true: Female)
        /// </summary>
        public bool? EmpGender { get; set; } = false;

        /// <summary>
        /// Request Birthday of Employee
        /// </summary>
        public int? EmpBirthday { get; set; } = (int)DateTimeOffset.Now.ToUnixTimeSeconds();

        /// <summary>
        /// Request Image of Employee
        /// </summary>
        public string? EmpImageBase64 { get; set; }

        /// <summary>
        /// Request Place of Birth ID
        /// </summary>
        public int? EmpPlaceOfBirth { get; set; }

        /// <summary>
        /// Request Telephone Number
        /// </summary>
        public string? EmpTel { get; set; }

        /// <summary>
        /// Request Email Address
        /// </summary>
        public string? EmpEmail { get; set; }

        /// <summary>
        /// Request Education Level
        /// </summary>
        public string? EmpEducationLevel { get; set; }

        /// <summary>
        /// Request Joined Date (Epoch Time or Integer Representation)
        /// </summary>
        public int? EmpJoinedDate { get; set; } = (int)DateTimeOffset.Now.ToUnixTimeSeconds();

        /// <summary>
        /// Password
        /// </summary>
        public string? Password { get; set; }

        /// <summary>
        /// Company ID Reference
        /// </summary>
        public int? CompanyId { get; set; }

        /// <summary>
        /// Request Degree ID Reference
        /// </summary>
        public int? DegreeId { get; set; }

        /// <summary>
        /// Request Training Major ID Reference
        /// </summary>
        public int? TraMajId { get; set; }

        /// <summary>
        /// Request Bank Account Number
        /// </summary>
        public string? EmpAccountNumber { get; set; }

        /// <summary>
        /// Request Bank ID Reference
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
        /// Request Residence Address
        /// </summary>
        public string? EmpPlaceOfResidenceAddress { get; set; }

        /// <summary>
        /// Request Residence Ward ID Reference
        /// </summary>
        public int? EmpPlaceOfResidenceWardId { get; set; }

        /// <summary>
        /// Request Employee Active Status (0: Inactive, 1: Active)
        /// </summary>
        public int? IsActived { get; set; } = 0;

    }
}
