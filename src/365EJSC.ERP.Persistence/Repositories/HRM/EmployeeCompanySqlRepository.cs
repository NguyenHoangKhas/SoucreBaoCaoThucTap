using _365EJSC.ERP.Contract.Exceptions;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.HRM;
using _365EJSC.ERP.Domain.Entities.Define;
using _365EJSC.ERP.Domain.Entities.HRM;
using _365EJSC.ERP.Persistence.Repositories.Base;

namespace _365EJSC.ERP.Persistence.Repositories.HRM
{
    public class EmployeeCompanySqlRepository : GenericSqlRepository<EmployeeCompany, int>, IEmployeeCompanySqlRepository
    {
        public EmployeeCompanySqlRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task ValidateEmployeeCompany(int? employeeId, int? companyDepartmentId) 
        { 
            if (employeeId != null && !await context.CheckExistsAsync<Employee, int>((int)employeeId))
                CustomException.ThrowNotFoundException(typeof(Employee), Contract.Enumerations.MsgCode.ERR_EMPLOYEE_ID_NOT_FOUND);
            
            //if (companyDepartmentId != null && !await context.CheckExistsAsync<GeneralCompanyDepartment, int>((int)companyDepartmentId))
            //    CustomException.ThrowNotFoundException(typeof(GeneralCompanyDepartment), Contract.Enumerations.MsgCode.ERR_COMPANY_DEPARTMENT_ID_NOT_FOUND);
        }
    }
}
