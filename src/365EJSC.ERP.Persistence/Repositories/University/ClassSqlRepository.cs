using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.University;
using _365EJSC.ERP.Domain.Entities.University;
using _365EJSC.ERP.Persistence.Repositories.Base;

namespace _365EJSC.ERP.Persistence.Repositories.University
{
    public class ClassSqlRepository
        : GenericSqlRepository<Class, int>, IClassSqlRepository
    {
        public ClassSqlRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
