using _365EJSC.ERP.Contract.Abstractions;
using System.Text.Json.Serialization;

namespace _365EJSC.ERP.Application.Requests.HRM.EmployeeRole
{
    public record UpdateEmployeeRoleRequest : ICommand
    {
        [JsonIgnore]
        public int? Id { get; set; }
        public string? EmpRoleName { get; set; }
        public string? EmpRoleCode { get; set; }
    }
}
