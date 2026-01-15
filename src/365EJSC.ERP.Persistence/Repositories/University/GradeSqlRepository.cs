using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.University;
using _365EJSC.ERP.Domain.Entities.University;
using _365EJSC.ERP.Persistence.Repositories.Base;

namespace _365EJSC.ERP.Persistence.Repositories.University
{
    public class GradeSqlRepository
        : GenericSqlRepository<Grade, int>, IGradeSqlRepository
    {
        public GradeSqlRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
