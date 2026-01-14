using _365EJSC.ERP.Domain.Entities.University;

namespace _365EJSC.ERP.Domain.Constants.University
{
    public class ClassConst
    {
        #region Database defines

        public const string FIELD_CLASS_ID = "class_id";
        public const string FIELD_CLASS_CODE = "class_code";
        public const string FIELD_CLASS_NAME = "class_name";
        public const string FIELD_ACADEMIC_YEAR = "academic_year";
        public const string FIELD_DEPARTMENT = "department";
        public const string FIELD_ADVISOR_ID = "advisor_id";

        #endregion

        #region Max length defines

        public const int CLASS_CODE_MAX_LENGTH = 64;
        public const int CLASS_NAME_MAX_LENGTH = 256;
        public const int ACADEMIC_YEAR_MAX_LENGTH = 32;
        public const int DEPARTMENT_MAX_LENGTH = 256;

        #endregion

        #region Message defines

        public const string MSG_CLASS_ID_NOT_FOUND =
            $"{nameof(Class)} with this id was not found";

        public const string MSG_CLASS_ID_EXISTED =
            $"{nameof(Class)} with this id has existed in database";

        public const string MSG_CLASS_CODE_EXISTED =
            $"{nameof(Class)} with this class code has existed in database";

        public const string MSG_ADVISOR_ID_NOT_FOUND =
            $"Advisor lecturer with this id was not found";

        #endregion
    }
}
