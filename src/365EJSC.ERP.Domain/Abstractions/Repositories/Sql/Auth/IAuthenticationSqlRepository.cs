using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Base;
using _365EJSC.ERP.Domain.Entities.HRM;

namespace _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Auth
{
    public interface IAuthenticationSqlRepository : IGenericSqlRepository<Employee, int>
    {
        Task<bool> ValidateUserAsync(int id, string type);
    }
}
