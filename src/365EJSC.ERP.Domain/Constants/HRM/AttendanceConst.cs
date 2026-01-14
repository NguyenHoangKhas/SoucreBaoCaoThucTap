using _365EJSC.ERP.Domain.Entities.HRM;

namespace _365EJSC.ERP.Domain.Constants.HRM
{
    public class AttendanceConst
    {
        #region Database defines

        public const string FIELD_ID = "attendance_id";
        public const string FIELD_EMPLOYEE_ID = "employee_id";
        public const string FIELD_CHECKIN_TIME = "checkin_time";
        public const string FIELD_CHECKOUT_TIME = "checkout_time";
        public const string FIELD_WORK_DATE = "work_date";
        public const string FIELD_TOTAL_WORKING_MINUTES = "total_working_minutes";
        public const string FIELD_ATTENDANCE_STATUS = "attendance_status";

        #endregion

        #region Max length defines
        // Vì bảng này chủ yếu là số, nên không cần độ dài tối đa.
        // Nếu có thêm các cột kiểu string (ví dụ location, note) thì thêm ở đây sau.
        #endregion

        #region Message defines

        public const string MSG_ATTENDANCE_ID_NOT_FOUND = $"{nameof(Attendance)} with this id was not found";
        public const string MSG_EMPLOYEE_ID_NOT_FOUND = "Employee with this id was not found";
        public const string MSG_DUPLICATE_ATTENDANCE = "Attendance record for this employee and date already exists";
        public const string MSG_INVALID_CHECKIN_CHECKOUT = "Check-in or Check-out time is invalid";
        public const string MSG_WORKDATE_REQUIRED = "Work date is required to record attendance";
        public const string MSG_ATTENDANCE_ALREADY_EXISTS ="Attendance record for this employee and date already exists";

        #endregion
    }
}
