namespace _365EJSC.ERP.Domain.Constants.Define
{
    public class WebLocalWardsV2Const
    {
        public const string TABLE_NAME = "website_localization_ward_v2";

        #region Database defines

        public const string FIELD_ID = "ward_id";
        public const string FIELD_NAME = "name";
        public const string FIELD_NAME_EN = "name_en";
        public const string FIELD_FULL_NAME = "full_name";
        public const string FIELD_FULL_NAME_EN = "full_name_en";
        public const string FIELD_LATITUDE = "latitude";
        public const string FIELD_LONGITUDE = "longitude";
        public const string FIELD_WARD_PID = "ward_pid";
        public const string FIELD_KEY_LOCALIZATION = "key_localization";

        #endregion

        #region Max length defines

        public const int NAME_MAX_LENGTH = 64;
        public const int NAME_EN_MAX_LENGTH = 64;
        public const int FULL_NAME_MAX_LENGTH = 96;
        public const int FULL_NAME_EN_MAX_LENGTH = 96;
        public const int KEY_LOCALIZATION_MAX_LENGTH = 32;

        #endregion
    }
}
