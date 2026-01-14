using _365EJSC.ERP.Contract.Abstractions;
using _365EJSC.ERP.Domain.DTOs.HRM;

namespace _365EJSC.ERP.Application.Requests.HRM.Employee
{
    /// <summary>
    /// Request to get existed <see cref="Employee"/> by id from database
    /// </summary>
    public record GetDetailEmployeeRequest : IQuery<EmployeeDetailDTOs>
    {
        public int? Id { get; set; }
    }
}
