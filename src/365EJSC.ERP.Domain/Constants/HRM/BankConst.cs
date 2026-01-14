using _365EJSC.ERP.Domain.Entities.HRM;

namespace _365EJSC.ERP.Domain.Constants.HRM
{
    public class BankConst
    {
        #region Database defines
        public const string FIELD_ID = "bank_id";
        public const string FIELD_NAME = "bnk_name";
        #endregion
        #region Max length defines
        public const int NAME_MAX_LENGTH = 24;
        #endregion
        #region Message defines
        public const string MSG_BANK_ID_NOT_FOUND = $"{nameof(Bank)} with this id was not found";
        public const string MSG_BANK_ID_ID_IN_USE = "The Bank ID is currently in use";
        #endregion
    }
}
