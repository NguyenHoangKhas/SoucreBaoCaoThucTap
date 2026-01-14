using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql;
using _365EJSC.ERP.Domain.Entities.HRM;
using _365EJSC.ERP.Persistence.Repositories.Base;

namespace _365EJSC.ERP.Persistence.Repositories.HRM
{
    internal class EmployeeRoleSqlRepository : GenericSqlRepository<EmployeeRole, int>, IEmployeeRoleSqlRepository
    {
        public EmployeeRoleSqlRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
