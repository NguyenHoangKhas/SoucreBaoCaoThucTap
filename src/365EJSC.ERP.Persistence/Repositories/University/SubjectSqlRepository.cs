using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.University;
using _365EJSC.ERP.Domain.Entities.University;
using _365EJSC.ERP.Persistence.Repositories.Base;

namespace _365EJSC.ERP.Persistence.Repositories.University
{
    public class SubjectSqlRepository
        : GenericSqlRepository<Subject, int>, ISubjectSqlRepository
    {
        public SubjectSqlRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
