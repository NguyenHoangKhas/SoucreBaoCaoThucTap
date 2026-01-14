using _365EJSC.ERP.Domain.Entities.HRM;

namespace _365EJSC.ERP.Domain.Constants.HRM
{
    public class EmployeeCompanyConst
    {
        #region Database defines
        public const string FIELD_ID = "ec_id";
        public const string FIELD_EMPLOYEE_ID = "employee_id";
        public const string FIELD_CD_ID = "cd_id";
        #endregion

        #region Message defines
        public const string MSG_NOT_FOUND = $"{nameof(EmployeeCompany)} with this id was not found";
        #endregion
    }
}
