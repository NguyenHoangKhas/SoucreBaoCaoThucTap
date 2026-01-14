using _365EJSC.ERP.Domain.Entities.Define;

namespace _365EJSC.ERP.Domain.Constants.Define
{
    public class ConfigIconConst
    {
        #region Database defines 
        public const string TABLE_NAME = "config_icon";
        public const string FIELD_KEY_CONFIG_ICON = "idx_key";
        public const string FIELD_DESCRIPTION = "description";
        public const string FIELD_URL = "url";
        #endregion

        #region Max length defines

        public const int IDX_KEY_MAX_LENGTH = 128;
        public const int DESCRIPTION_MAX_LENGTH = 255;
        public const int URL_MAX_LENGTH = 255;

        #endregion

        #region Message defines

        public const string MSG_KEY_CONFIG_ICON_NOT_FOUND = $"{nameof(ConfigIcon)} with this key was not found";
        public const string MSG_KEY_CONFIG_ICON_EXISTED = $"{nameof(ConfigIcon)} with this key has existed in database";

        #endregion
    }
}
