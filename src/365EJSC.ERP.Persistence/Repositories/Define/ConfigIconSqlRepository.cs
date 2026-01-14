using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Define;
using _365EJSC.ERP.Domain.Entities.Define;
using _365EJSC.ERP.Persistence.Repositories.Base;

namespace _365EJSC.ERP.Persistence.Repositories.Define
{
    /// <summary>
    /// Implementation of IConfigIconRepository
    /// </summary>
    public class ConfigIconSqlRepository : GenericSqlRepository<ConfigIcon, string>, IConfigIconSqlRepository
    {
        /// <summary>
        /// Implementation of IConfigIconRepository
        /// </summary>
        public ConfigIconSqlRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
