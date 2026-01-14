using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Base;
using _365EJSC.ERP.Domain.Entities.HRM;

namespace _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.HRM
{
    /// <summary>
    /// Provide repository for <see cref="EmployeeVerify"/>, inherit from <see cref="IGenericSqlRepository{TEntity,TKey}"/>
    /// </summary>
    public interface IEmployeeVerifySqlRepository : IGenericSqlRepository<EmployeeVerify, int>
    {
    }
}
