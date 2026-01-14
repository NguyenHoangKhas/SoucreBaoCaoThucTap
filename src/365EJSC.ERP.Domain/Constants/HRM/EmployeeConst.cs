using _365EJSC.ERP.Domain.Entities.HRM;

namespace _365EJSC.ERP.Domain.Constants.HRM
{
    public class EmployeeConst
    {
        #region Database defines

        public const string FIELD_ID = "employee_id";
        public const string FIELD_CITIZEN_IDENTITY = "emp_citizen_identity";
        public const string FIELD_TAX_CODE = "emp_tax_code";
        public const string FIELD_CODE = "emp_code";
        public const string FIELD_FIRST_NAME = "emp_first_name";
        public const string FIELD_LAST_NAME = "emp_last_name";
        public const string FIELD_GENDER = "emp_gender";
        public const string FIELD_BIRTHDAY = "emp_birthday";
        public const string FIELD_PLACE_OF_BIRTH = "emp_place_of_birth";
        public const string FIELD_IMAGE = "emp_image";
        public const string FIELD_TEL = "emp_tel";
        public const string FIELD_EMAIL = "emp_email";
        public const string FIELD_EDUCATION_LEVEL = "emp_education_level";
        public const string FIELD_JOINED_DATE = "emp_joined_date";
        public const string FIELD_PASSWORD = "emp_password";
        public const string FIELD_COMPANY_ID = "company_id";
        public const string FIELD_DEGREE_ID = "degree_id";
        public const string FIELD_TRA_MAJ_ID = "tra_maj_id";
        public const string FIELD_ACCOUNT_NUMBER = "emp_account_number";
        public const string FIELD_BANK_ID = "bank_id";
        public const string FIELD_NATION_ID = "nation_id";
        public const string FIELD_RELIGION_ID = "religion_id";
        public const string FIELD_MARITAL_ID = "marital_id";
        public const string FIELD_ROLE_ID = "emp_role_id";
        public const string FIELD_COUNTRY_ID = "country_id";
        public const string FIELD_PLACE_OF_RESIDENCE_ADDRESS = "emp_place_of_residence_address";
        public const string FIELD_PLACE_OF_RESIDENCE_WARD_ID = "emp_place_of_residence_ward_id";
        public const string FIELD_IS_ACTIVED = "is_actived";

        #endregion

        #region Max length defines

        public const int CITIZEN_IDENTITY_MAX_LENGTH = 24;
        public const int TAX_CODE_MAX_LENGTH = 24;
        public const int CODE_MAX_LENGTH = 24;
        public const int FIRST_NAME_MAX_LENGTH = 128;
        public const int LAST_NAME_MAX_LENGTH = 128;
        public const int IMAGE_MAX_LENGTH = 128;
        public const int TEL_MAX_LENGTH = 64;
        public const int EMAIL_MAX_LENGTH = 64;
        public const int EDUCATION_LEVEL_MAX_LENGTH = 12;
        public const int ACCOUNT_NUMBER_MAX_LENGTH = 24;
        public const int COUNTRY_ID_MAX_LENGTH = 32;
        public const int RESIDENCE_ADDRESS_MAX_LENGTH = 128;
        public const int PASSWORD_MAX_LENGTH = 256;

        #endregion

        #region Message defines
        public const string MSG_EMPLOYEE_ID_NOT_FOUND = $"{nameof(Employee)} with this id was not found";
        public const string MSG_DEGREE_ID_NOT_FOUND = "Degree with this id was not found";
        public const string MSG_COUNTRY_ID_NOT_FOUND = "Country with this id was not found";
        public const string MSG_NATION_ID_NOT_FOUND = "Nation with this id was not found";
        public const string MSG_RELIGION_ID_NOT_FOUND = "Religion with this id was not found";
        public const string MSG_MARITAL_ID_NOT_FOUND = "Marital status with this id was not found";
        public const string MSG_BANK_ID_NOT_FOUND = "Bank with this id was not found";
        public const string MSG_TRAINGINGMAJOR_ID_NOT_FOUND = "Training Major with this id was not found";
        public const string MSG_EMP_ROLE_ID_NOT_FOUND = "Employee Role with this id was not found";
        public const string MSG_WARD_ID_NOT_FOUND = "Ward Role with this id was not found";
        public const string MSG_PROVINCE_ID_NOT_FOUND = "Province Role with this id was not found";
        #endregion
    }
}
