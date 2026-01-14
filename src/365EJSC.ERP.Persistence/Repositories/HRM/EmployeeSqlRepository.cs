using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Exceptions;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql;
using _365EJSC.ERP.Domain.Constants.HRM;
using _365EJSC.ERP.Domain.Entities.Define;
using _365EJSC.ERP.Domain.Entities.HRM;
using _365EJSC.ERP.Persistence.Repositories.Base;
using Microsoft.IdentityModel.Tokens;

namespace _365EJSC.ERP.Persistence.Repositories.HRM
{
    /// <summary>
    /// Implementation of IEmployeeRepository
    /// </summary>
    public class EmployeeSqlRepository : GenericSqlRepository<Employee, int>, IEmployeeSqlRepository
    {
        /// <summary>
        /// Implementation of IEmployeeRepository
        /// </summary>
        public EmployeeSqlRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task ValidateEmployee(string? empCode, int? degreeId, string? countryId, int? maritalId, int? empRoleId, int? bankId, int? nationId, int? religionId, int? traMajId, int? empPlaceOfResidenceWardId, int? empPlaceOfBirth, int? companyId)
        {
            if (!string.IsNullOrEmpty(empCode) && context.Set<Employee>().Any(x => x.EmpCode.Equals(empCode)))
                CustomException.ThrowConflictException(MsgCode.ERR_EMPLOYEE_CODE_EXISTED);
            if (degreeId != null) { var degreeExists = await context.CheckExistsAsync<Degree, int>((int)degreeId); if (!degreeExists) { CustomException.ThrowNotFoundException(typeof(Degree), MsgCode.ERR_DEGREE_ID_NOT_FOUND, EmployeeConst.MSG_DEGREE_ID_NOT_FOUND); } }
            //if (!string.IsNullOrEmpty(countryId)) { var countryExists = await context.CheckExistsAsync<WebLocals, string>(countryId); if (!countryExists) { CustomException.ThrowNotFoundException(typeof(WebLocals), MsgCode.ERR_KEY_LOCAL_NOT_FOUND, EmployeeConst.MSG_COUNTRY_ID_NOT_FOUND); } }
            //if (maritalId != null) { var maritalExists = await context.CheckExistsAsync<Marital, int>((int)maritalId); if (!maritalExists) { CustomException.ThrowNotFoundException(typeof(Marital), MsgCode.ERR_MARITAL_ID_NOT_FOUND, EmployeeConst.MSG_MARITAL_ID_NOT_FOUND); } }
            if (empRoleId != null) { var employeeRoleExists = await context.CheckExistsAsync<EmployeeRole, int>((int)empRoleId); if (!employeeRoleExists) { CustomException.ThrowNotFoundException(typeof(EmployeeRole), MsgCode.ERR_EMPLOYEE_ROLE_ID_NOT_FOUND, EmployeeConst.MSG_EMP_ROLE_ID_NOT_FOUND); } }
            if (bankId != null) { var bankExists = await context.CheckExistsAsync<Bank, int>((int)bankId); if (!bankExists) { CustomException.ThrowNotFoundException(typeof(Bank), MsgCode.ERR_BANK_ID_NOT_FOUND, EmployeeConst.MSG_BANK_ID_NOT_FOUND); } }
            //if (nationId != null) { var nationExists = await context.CheckExistsAsync<Nation, int>((int)nationId); if (!nationExists) { CustomException.ThrowNotFoundException(typeof(Nation), MsgCode.ERR_NATION_ID_NOT_FOUND, EmployeeConst.MSG_NATION_ID_NOT_FOUND); } }
            //if (religionId != null) { var religionExists = await context.CheckExistsAsync<Religion, int>((int)religionId); if (!religionExists) { CustomException.ThrowNotFoundException(typeof(Religion), MsgCode.ERR_RELIGION_ID_NOT_FOUND, EmployeeConst.MSG_RELIGION_ID_NOT_FOUND); } }
            //if (traMajId != null) { var trainingMajorExists = await context.CheckExistsAsync<TrainingMajor, int>((int)traMajId); if (!trainingMajorExists) { CustomException.ThrowNotFoundException(typeof(TrainingMajor), MsgCode.ERR_TRAININGMAJOR_ID_NOT_FOUND, EmployeeConst.MSG_TRAINGINGMAJOR_ID_NOT_FOUND); } }
            //if (empPlaceOfResidenceWardId != null) { var wardExists = await context.CheckExistsAsync<WebLocalWard, int>((int)empPlaceOfResidenceWardId); if (!wardExists) { CustomException.ThrowNotFoundException(typeof(WebLocalWard), MsgCode.ERR_WARD_ID_NOT_FOUND, EmployeeConst.MSG_WARD_ID_NOT_FOUND); } }
            //if (empPlaceOfBirth != null) { var placeOfBirthExists = await context.CheckExistsAsync<WebLocalProvince, int>((int)empPlaceOfBirth); if (!placeOfBirthExists) { CustomException.ThrowNotFoundException(typeof(WebLocalProvince), MsgCode.ERR_PROVINCE_ID_NOT_FOUND, EmployeeConst.MSG_PROVINCE_ID_NOT_FOUND); } }
            //if (companyId != null && !await context.CheckExistsAsync<GeneralCompany, int>((int)companyId))
            //    CustomException.ThrowNotFoundException(typeof(GeneralCompany), MsgCode.ERR_COMPANY_ID_NOT_FOUND);
        }
    }
}