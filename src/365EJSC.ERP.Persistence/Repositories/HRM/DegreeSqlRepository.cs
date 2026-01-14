using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.HRM;
using _365EJSC.ERP.Domain.Entities.HRM;
using _365EJSC.ERP.Persistence.Repositories.Base;

namespace _365EJSC.ERP.Persistence.Repositories.HRM
{
    public class DegreeSqlRepository(ApplicationDbContext context) : GenericSqlRepository<Degree, int>(context), IDegreeSqlRepository
    {
    }
}
