namespace _365EJSC.ERP.Domain.Constants.Define
{
    public class HelpdeskCatalogConst
    {
        public const string TABLE_NAME = "helpdesk_catalog";

        #region Database defines

        public const string FIELD_ID = "catalog_id";
        public const string FIELD_KEY_CATALOG = "key_catalog";
        public const string FIELD_NAME_VN = "name_vn";
        public const string FIELD_URL = "url";
        public const string FIELD_IS_ACTIVED = "is_actived";

        #endregion

        #region Max length defines

        public const int KEY_CATALOG_MAX_LENGTH = 32;
        public const int NAME_VN_MAX_LENGTH = 64;
        public const int URL_MAX_LENGTH = 128;

        #endregion
    }
}
