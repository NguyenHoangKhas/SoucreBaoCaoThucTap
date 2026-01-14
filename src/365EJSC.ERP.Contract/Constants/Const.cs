namespace _365EJSC.ERP.Contract.Constants
{
    /// <summary>
    /// Contain all constant for application
    /// </summary>
    public static class Const
    {
        #region Connection

        public const string CONN_CONFIG_SQL = "DbSqlServer";
        public const string CONN_CONFIG_MONGO = "DbMongo:ConnectionString";
        public const string DB_MONGO = "DbMongo:Database";

        #endregion

        #region rabbitMQ

        public const string BROKER_CONFIG = "MessageBroker";
        public const string BROKER_HOST = "Host";
        public const string BROKER_USERNAME = "Username";
        public const string BROKER_PASSWORD = "Password";

        #endregion

        #region FileUpload
        public const string UPLOADED_SETTINGS = "UploadedSettings";
        public const string DOMAIN_HOSTS = "DomainHosts";
        public const string OUTPUTFILE_UPLOADED = "assets/images/uploaded";


        public const string FILENAME_COMPANY = "img-{0}";
        public const string FILENAME_CEO_COMPANY = "img-ceo-{0}";

        public const string FILENAME_CUSTOMER = "img-customer-{0}";

        public const string FILENAME_EMPLOYEE = "img-employee-{0}";
        public const string FILENAME_EMPLOYEE_VERIFY = "img-emp-verify-{0}-{1}";

        public const string FILENAME_PRO_SUPPLIER = "img-supplier-{0}";
        public const string FILENAME_PRO_SUPPLIER_VERIFY = "img-sup-verify-{0}-{1}";

        public const string FILENAME_CONFIG_ICON = "img-icon-{0}";

        public const string FILENAME_BEAUTY_DEFINE = "beauty-define-icon-{0}";
        public const string FILENAME_BEAUTY_PRICING = "beauty-pricing-icon-{0}";
        public const string FILENAME_BEAUTY_SERVICE = "beauty-service-icon-{0}";
        public const string FILENAME_AI_FACE_PHOTO_SOURCE = "beauty-ai-face-photo-source-{0}";
        public const string FILENAME_AI_FACE_EYEBROW_FINISHED = "beauty-ai-face-eyebrow-finished-{0}";
        public const string FILENAME_AI_ANALYZER_EYEBROW_DOUBLE = "eyebrow_double-{0}";
        public const string FILENAME_AI_ANALYZER_EYEBROW_SINGLE = "eyebrow_single-{0}";
        public const string FILENAME_BEAUTY_WEB_SHOW = "web_show-{0}";

        public const string FILENAME_BRAND_CATALOG = "brand-catalog-{0}";
        public const string FILENAME_MANUFACTURER_CATALOG = "manufacturer-catalog-{0}";

        #endregion

        #region Time zone

        /// <summary>
        /// UTC +7 = 3600 x (+7)
        /// </summary>
        public static int TIME_ZONE_UTC_7 = 25200;

        /// <summary>
        /// Seconds In A Day
        /// </summary>
        public const int SECONDS_IN_ADAY = 86400;

        #endregion

        public const string BEAUTY_EMPLOYEE_ACCESS_ADMIN = "BEAUTY_EMPLOYEE_ACCESS_ADMIN";
    }
}