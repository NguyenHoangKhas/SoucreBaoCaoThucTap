using _365EJSC.ERP.Domain.Entities.HRM;

namespace _365EJSC.ERP.Domain.Constants.HRM
{
    public class EmployeeVerifyConst
    {
        #region Database defines

        public const string FIELD_VERIFY_ID = "verify_id";
        public const string FIELD_EMPLOYEE_ID = "employee_id";
        public const string FIELD_VER_IMAGE = "ver_image";
        public const string FIELD_USER_ID_VERIFY = "user_id_verify";
        public const string FIELD_VER_CREATED_DATE = "ver_created_date";
        public const string FIELD_IS_ACTIVED = "is_actived";

        #endregion

        #region Max length defines

        public const int VER_IMAGE_MAX_LENGTH = 64;

        #endregion

        #region Message defines

        public const string MSG_VERIFY_ID_NOT_FOUND = $"{nameof(Employee)} with this employee id was not found";     
        #endregion
    }
}
