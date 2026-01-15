using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.University;
using _365EJSC.ERP.Domain.Entities.University;
using _365EJSC.ERP.Persistence.Repositories.Base;

namespace _365EJSC.ERP.Persistence.Repositories.University
{
    public class UserSqlRepository
        : GenericSqlRepository<User, int>, IUserSqlRepository
    {
        public UserSqlRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
