using _365EJSC.ERP.Domain.Entities.University;


namespace _365EJSC.ERP.Domain.Constants.University
{
    public static class UserConst
    {
        #region Database defines

        public const string FIELD_ID = "id";
        public const string FIELD_USERNAME = "username";
        public const string FIELD_PASSWORD_HASH = "password_hash";
        public const string FIELD_FULL_NAME = "full_name";
        public const string FIELD_EMAIL = "email";
        public const string FIELD_ROLE = "role";

        #endregion

        #region Max length defines

        public const int USERNAME_MAX_LENGTH = 100;      // VARCHAR(100)
        public const int PASSWORD_HASH_MAX_LENGTH = 255; // VARCHAR(255)
        public const int FULL_NAME_MAX_LENGTH = 150;     // NVARCHAR(150)
        public const int EMAIL_MAX_LENGTH = 150;         // VARCHAR(150)
        public const int ROLE_MAX_LENGTH = 50;           // VARCHAR(50)

        #endregion

        #region Message defines

        public const string MSG_USER_ID_NOT_FOUND = $"{nameof(User)} with this id was not found";
        public const string MSG_USERNAME_ALREADY_EXISTS = "Username already exists";
        public const string MSG_EMAIL_ALREADY_EXISTS = "Email already exists";

        #endregion
    }
}
