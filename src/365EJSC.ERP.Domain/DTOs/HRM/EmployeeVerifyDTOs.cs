using _365EJSC.ERP.Domain.Entities.HRM;

namespace _365EJSC.ERP.Domain.DTOs.HRM
{
    public class EmployeeVerifyDTOs:EmployeeVerify
    {
        public int EmployeeVerifyId { get; set; }

        public EmployeeDetailDTOs Employee { get; set; }
    }
}
