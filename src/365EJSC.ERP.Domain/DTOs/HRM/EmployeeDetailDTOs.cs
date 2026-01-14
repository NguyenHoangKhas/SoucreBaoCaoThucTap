using _365EJSC.ERP.Domain.Entities.HRM;

namespace _365EJSC.ERP.Domain.DTOs.HRM
{
    public class EmployeeDetailDTOs : Employee
    {
        public int EmployeeId { get; set; }
        //public WebLocalProvince? EmpPlaceOfBirthName { get; set; }
        public int? IsActived { get; set; }
        public string? BankName { get; set; }
        public string? DegreeName { get; set; }
        public string? MaritalStatusName { get; set; }
        public string? NationName { get; set; }
        public string? ReligionName { get; set; }
        public string? EmpRoleName { get; set; }
        public string? TraMajName { get; set; }
        public string? CountryName { get; set; }

        public EmployeeCompanyDTOs? EmployeeCompany { get; set; }

        //public WardDTOs Ward { get; set; }
        public IEnumerable<EmployeeVerify> EmployeeVerifies { get; set; }
    }
}
