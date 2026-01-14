using _365EJSC.ERP.Contract.Abstractions;

namespace _365EJSC.ERP.Application.Requests.HRM.EmployeeRole
{
    public record CreateEmployeeRoleRequest : ICommand
    {
        public string? EmpRoleName { get; set; }
        public string? EmpRoleCode { get; set; }
    }
}
