using _365EJSC.ERP.Domain.Entities.University;

namespace _365EJSC.ERP.Domain.Constants.University
{
    public class LecturerConst
    {
        #region Database defines

        public const string FIELD_LECTURER_ID = "lecturer_id";
        public const string FIELD_LECTURER_CODE = "lecturer_code";
        public const string FIELD_FULL_NAME = "full_name";
        public const string FIELD_EMAIL = "email";
        public const string FIELD_DEGREE = "degree";
        public const string FIELD_USER_ID = "user_id";

        #endregion

        #region Max length defines

        public const int LECTURER_CODE_MAX_LENGTH = 50;
        public const int FULL_NAME_MAX_LENGTH = 256;
        public const int EMAIL_MAX_LENGTH = 256;
        public const int DEGREE_MAX_LENGTH = 128;

        #endregion

        #region Message defines

        public const string MSG_LECTURER_ID_NOT_FOUND =
            $"{nameof(Lecturer)} with this lecturer id was not found";

        public const string MSG_LECTURER_ID_EXISTED =
            $"{nameof(Lecturer)} with this lecturer id has existed in database";

        public const string MSG_LECTURER_CODE_EXISTED =
            $"{nameof(Lecturer)} with this lecturer code has existed in database";

        #endregion
    }
}
