using _365EJSC.ERP.Domain.Abstractions.Aggregates;
using System;

namespace _365EJSC.ERP.Domain.Entities.HRM
{
    /// <summary>
    /// Historical attendance record (logs changes of attendance)
    /// </summary>
    public class AttendanceHis : AggregateRoot<int>
    {
        /// <summary>
        /// Foreign key reference to HrmAttendance
        /// </summary>
        public int AttendanceId { get; set; }

        /// <summary>
        /// Check-in time stored as DATETIME in DB
        /// </summary>
        public DateTime? CheckInTime { get; set; }

        /// <summary>
        /// Check-out time stored as DATETIME in DB
        /// </summary>
        public DateTime? CheckOutTime { get; set; }

        /// <summary>
        /// Number of minutes the employee was late
        /// </summary>
        public int? NumLate { get; set; }

        /// <summary>
        /// Number of minutes the employee left early
        /// </summary>
        public int? NumEarlyLeave { get; set; }

        /// <summary>
        /// Total number of working minutes
        /// </summary>
        public int? WorkingMinutes { get; set; }

        /// <summary>
        /// 0: inactive, 1: active
        /// </summary>
        public int IsActived { get; set; } = 0;

        /// <summary>
        /// Navigation property to main attendance record
        /// </summary>
        public Attendance? AttendanceInfo { get; set; }
    }
}
