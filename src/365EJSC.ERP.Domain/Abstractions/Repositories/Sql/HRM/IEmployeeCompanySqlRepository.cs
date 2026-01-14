using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Base;
using _365EJSC.ERP.Domain.Entities.HRM;

namespace _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.HRM
{
    public interface IEmployeeCompanySqlRepository : IGenericSqlRepository<EmployeeCompany, int>
    {
        Task ValidateEmployeeCompany(int? employeeId, int? companyDepartmentId);
    }
}
