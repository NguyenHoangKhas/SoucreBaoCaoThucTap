using _365EJSC.ERP.Contract.Abstractions;
using _365EJSC.ERP.Domain.DTOs.HRM;

namespace _365EJSC.ERP.Application.Requests.HRM.Employee
{
    public class EmployeeLoginRequest : ICommand<EmployeeLoginDTOs>
    {
        public string EmpCode { get; set; }
        public string Password { get; set; }
    }
}
