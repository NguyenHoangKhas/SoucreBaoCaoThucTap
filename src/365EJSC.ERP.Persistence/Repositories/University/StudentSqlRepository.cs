using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.University;
using _365EJSC.ERP.Domain.Entities.University;
using _365EJSC.ERP.Persistence.Repositories.Base;

namespace _365EJSC.ERP.Persistence.Repositories.University
{
    public class StudentSqlRepository
        : GenericSqlRepository<Student, int>, IStudentSqlRepository
    {
        public StudentSqlRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
