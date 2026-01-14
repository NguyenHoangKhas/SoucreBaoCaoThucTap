using _365EJSC.ERP.Domain.Entities.University;


namespace _365EJSC.ERP.Domain.Constants.University
{
    public static class StudentConst
    {
        #region Database defines

        public const string FIELD_ID = "id";
        public const string FIELD_STUDENT_CODE = "student_code";
        public const string FIELD_FULL_NAME = "full_name";
        public const string FIELD_EMAIL = "email";
        public const string FIELD_PHONE_NUMBER = "phone_number";
        public const string FIELD_USER_ID = "user_id";
        public const string FIELD_CLASS_ID = "class_id";

        #endregion

        #region Max length defines

        public const int STUDENT_CODE_MAX_LENGTH = 50;     // VARCHAR(50)
        public const int FULL_NAME_MAX_LENGTH = 150;        // NVARCHAR(150)
        public const int EMAIL_MAX_LENGTH = 150;            // VARCHAR(150)
        public const int PHONE_NUMBER_MAX_LENGTH = 20;      // VARCHAR(20)

        #endregion

        #region Message defines

        public const string MSG_STUDENT_ID_NOT_FOUND = $"{nameof(Student)} with this id was not found";
        public const string MSG_STUDENT_CODE_ALREADY_EXISTS = "Student code already exists";
        public const string MSG_STUDENT_EMAIL_ALREADY_EXISTS = "Student email already exists";
        public const string MSG_USER_ID_NOT_FOUND = "User with this id was not found";
        public const string MSG_CLASS_ID_NOT_FOUND = "Class with this id was not found";

        #endregion
    }
}
