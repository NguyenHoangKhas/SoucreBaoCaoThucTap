using _365EJSC.ERP.Contract.Abstractions;
using _365EJSC.ERP.Domain.Entities.HRM;

namespace _365EJSC.ERP.Application.Requests.HRM.EmployeeRole
{
    public record GetDetailEmployeeRoleRequest : IQuery<Domain.Entities.HRM.EmployeeRole>
    {
        public int? Id { get; set; }
    }
}
