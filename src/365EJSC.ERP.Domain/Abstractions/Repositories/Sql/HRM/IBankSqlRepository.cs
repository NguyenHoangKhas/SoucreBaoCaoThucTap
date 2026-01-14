using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Base;
using _365EJSC.ERP.Domain.Entities.HRM;

namespace _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.HRM
{
    /// <summary>
    /// Provide repository for <see cref="Bank"/>, inherit from <see cref="IGenericSqlRepository{TEntity,TKey}"/>
    /// </summary>
    public interface IBankSqlRepository : IGenericSqlRepository<Bank, int>
    {
    }
}
