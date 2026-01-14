using _365EJSC.ERP.Domain.Entities.HRM;

namespace _365EJSC.ERP.Domain.Constants.HRM
{
    public class AttendanceHisConst
    {
        #region Database defines

        public const string FIELD_ID = "att_his_id";
        public const string FIELD_ATTENDANCE_ID = "attendance_id";
        public const string FIELD_ACTION_TYPE = "action_type";
        public const string FIELD_ACTION_BY = "action_by";
        public const string FIELD_OLD_CHECKIN_TIME = "old_checkin_time";
        public const string FIELD_OLD_CHECKOUT_TIME = "old_checkout_time";
        public const string FIELD_NEW_CHECKIN_TIME = "new_checkin_time";
        public const string FIELD_NEW_CHECKOUT_TIME = "new_checkout_time";
        public const string FIELD_NOTE = "note";
        public const string FIELD_CREATED_DATE = "created_date";
        public const string FIELD_IS_ACTIVED = "is_actived";

        #endregion

        #region Max length defines

        public const int ACTION_TYPE_MAX_LENGTH = 64;
        public const int ACTION_BY_MAX_LENGTH = 128;
        public const int NOTE_MAX_LENGTH = 512;

        #endregion

        #region Message defines

        public const string MSG_ATTENDANCE_HIS_ID_NOT_FOUND = $"{nameof(AttendanceHis)} with this id was not found";
        public const string MSG_ATTENDANCE_ID_NOT_FOUND = "Attendance record with this id was not found";
        public const string MSG_ACTION_TYPE_REQUIRED = "Action type is required";

        #endregion
    }
}
