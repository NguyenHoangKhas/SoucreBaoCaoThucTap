using _365EJSC.ERP.Domain.Abstractions.Aggregates;
using _365EJSC.ERP.Domain.Entities.Define;
using System.Text.Json.Serialization;

namespace _365EJSC.ERP.Domain.Entities.HRM
{
    public class Employee : AggregateRoot<int>
    {
        /// <summary>
        /// Citizen Identity of Employee
        /// </summary>
        public string? EmpCitizenIdentity { get; set; }

        /// <summary>
        /// Tax Code of Employee
        /// </summary>
        public string? EmpTaxCode { get; set; }

        /// <summary>
        /// Employee Code
        /// </summary>
        public string? EmpCode { get; set; }

        /// <summary>
        /// First Name of Employee
        /// </summary>
        public string? EmpFirstName { get; set; }

        /// <summary>
        /// Last Name of Employee
        /// </summary>
        public string? EmpLastName { get; set; }

        /// <summary>
        /// Gender of Employee (false: Male, true: Female)
        /// </summary>
        public bool? EmpGender { get; set; }

        /// <summary>
        /// Birthday of Employee
        /// </summary>
        public int? EmpBirthday { get; set; }

        /// <summary>
        /// Place of Birth (ID Reference)
        /// </summary>
        public int? EmpPlaceOfBirth { get; set; }

        /// <summary>
        /// Profile Image
        /// </summary>
        public string? EmpImage { get; set; }

        /// <summary>
        /// Telephone Number
        /// </summary>
        public string? EmpTel { get; set; }

        /// <summary>
        /// Email Address
        /// </summary>
        public string EmpEmail { get; set; }

        /// <summary>
        /// Education Level
        /// </summary>
        public string? EmpEducationLevel { get; set; }

        /// <summary>
        /// Joined Date (Epoch Time or Integer Representation)
        /// </summary>
        public int? EmpJoinedDate { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        [JsonIgnore]
        public string? Password { get; set; }

        /// <summary>
        /// Company ID Reference
        /// </summary>
        public int? CompanyId { get; set; }

        /// <summary>
        /// Degree ID Reference
        /// </summary>
        public int? DegreeId { get; set; }

        /// <summary>
        /// Training Major ID Reference
        /// </summary>
        public int? TraMajId { get; set; }

        /// <summary>
        /// Bank Account Number
        /// </summary>
        public string? EmpAccountNumber { get; set; }

        /// <summary>
        /// Bank ID Reference
        /// </summary>
        public int? BankId { get; set; }

        /// <summary>
        /// Nation ID Reference
        /// </summary>
        public int? NationId { get; set; }

        /// <summary>
        /// Religion ID Reference
        /// </summary>
        public int? ReligionId { get; set; }

        /// <summary>
        /// Marital Status ID Reference
        /// </summary>
        public int? MaritalId { get; set; }

        /// <summary>
        /// Employee Role ID Reference
        /// </summary>
        public int? EmpRoleId { get; set; }

        /// <summary>
        /// Country ID
        /// </summary>
        public string? CountryId { get; set; }

        /// <summary>
        /// Residence Address
        /// </summary>
        public string? EmpPlaceOfResidenceAddress { get; set; }

        /// <summary>
        /// Residence Ward ID Reference
        /// </summary>
        public int? EmpPlaceOfResidenceWardId { get; set; }

        /// <summary>
        /// Employee Active Status (0: Inactive, 1: Active)
        /// </summary>
        public int? IsActived { get; set; }

        //[JsonIgnore]
        //public GeneralCompany CompanyInfo { get; set; }

        [JsonIgnore]
        public Degree? DegreeInfo { get; set; }
        //[JsonIgnore]
        //public Religion? ReligionInfo { get; set; }
        //[JsonIgnore]
        //public TrainingMajor? TraMajInfo { get; set; }
        [JsonIgnore]
        public Bank? BankInfo { get; set; }
        //[JsonIgnore]
        //public Nation? NationInfo { get; set; }
        //[JsonIgnore]
        //public Marital? MaritalInfo { get; set; }
        [JsonIgnore]
        public EmployeeRole? EmpRoleInfo { get; set; }
        //[JsonIgnore]
        //public WebLocals? CountryInfo { get; set; }
        //[JsonIgnore]
        //public WebLocalProvince? EmpPlaceOfBirthInfo { get; set; }
        //[JsonIgnore]
        //public WebLocalWard? EmpPlaceOfResidenceWardIdInfo { get; set; }
        [JsonIgnore]
        public List<EmployeeVerify>? EmployeeVerifies { get; set; }
    }
}
