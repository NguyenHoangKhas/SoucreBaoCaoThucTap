using _365EJSC.ERP.Contract.Abstractions;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.HRM;
using _365EJSC.ERP.Domain.Entities.HRM;
using _365EJSC.ERP.Persistence.Repositories.Base;

namespace _365EJSC.ERP.Persistence.Repositories.HRM
{
    /// <summary>
    /// Implementation of IEmployeeRepository
    /// </summary>
    public class EmployeeVerifySqlRepository : GenericSqlRepository<EmployeeVerify, int>, IEmployeeVerifySqlRepository
    {
        /// <summary>
        /// Implementation of IEmployeeRepository
        /// </summary>
        public EmployeeVerifySqlRepository(ApplicationDbContext context, IFileService fileService) : base(context)
        {
        }
    }
}
