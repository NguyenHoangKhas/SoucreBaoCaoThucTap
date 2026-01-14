using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Auth;
using _365EJSC.ERP.Domain.Entities.HRM;
using _365EJSC.ERP.Persistence.Repositories.Base;

namespace _365EJSC.ERP.Persistence.Repositories.Auth
{
    public class AuthenticationSqlRepository : GenericSqlRepository<Employee, int>, IAuthenticationSqlRepository
    {
        /// <summary>
        /// Database context to interact with database
        /// </summary>
        private readonly ApplicationDbContext context;

        /// <summary>
        /// Constructor of <see cref="AuthenticationSqlRepository"/>,  inject needed dependency
        /// </summary>
        /// <param name="context"></param>
        public AuthenticationSqlRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<bool> ValidateUserAsync(int id, string type)
        {
            bool isValid = await (type switch
            {
                nameof(UserLoginType.EMPLOYEE) => context.CheckExistsAsync<Employee, int>(id),
                //nameof(UserLoginType.COMPANY) => context.CheckExistsAsync<GeneralCompany, int>(id),
                nameof(UserLoginType.USER_ADMIN) => Task.FromResult(true),
                _ => Task.FromResult(false)
            });
            return isValid;
        }
    }
}
