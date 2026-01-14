using _365EJSC.ERP.Domain.Entities.Define;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Define;
using _365EJSC.ERP.Persistence.Repositories.Base;

namespace _365EJSC.ERP.Persistence.Repositories.Define
{
    /// <summary>
    /// Implementation of IHelpdeskCatalogSqlRepository
    /// </summary>
    public class HelpdeskCatalogSqlRepository(ApplicationDbContext context) : GenericSqlRepository<HelpdeskCatalog, int>(context), IHelpdeskCatalogSqlRepository
    {
    }
}
