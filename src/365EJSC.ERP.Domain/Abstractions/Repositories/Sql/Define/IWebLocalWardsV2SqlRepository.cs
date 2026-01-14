using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Base;
using _365EJSC.ERP.Domain.Entities.Define;

namespace _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Define
{
    /// <summary>
    /// Provide repository for <see cref="WebLocalWardsV2"/>, inherit from <see cref="IGenericSqlRepository{TEntity,TKey}"/>
    /// </summary>
    public interface IWebLocalWardsV2SqlRepository : IGenericSqlRepository<WebLocalWardsV2, int>
    {
    }
}
