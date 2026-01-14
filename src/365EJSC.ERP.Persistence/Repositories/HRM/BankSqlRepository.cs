using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.HRM;
using _365EJSC.ERP.Domain.Entities.HRM;
using _365EJSC.ERP.Persistence.Repositories.Base;

namespace _365EJSC.ERP.Persistence.Repositories.HRM
{
    /// <summary>
    /// Implementation of IBankSqlRepository
    /// </summary>
    public class BankSqlRepository : GenericSqlRepository<Bank, int>, IBankSqlRepository
    {
        public BankSqlRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
