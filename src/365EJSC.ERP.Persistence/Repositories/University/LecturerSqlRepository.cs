using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.University;
using _365EJSC.ERP.Domain.Entities.University;
using _365EJSC.ERP.Persistence.Repositories.Base;

namespace _365EJSC.ERP.Persistence.Repositories.University
{
    public class LecturerSqlRepository
        : GenericSqlRepository<Lecturer, int>, ILecturerSqlRepository
    {
        public LecturerSqlRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
