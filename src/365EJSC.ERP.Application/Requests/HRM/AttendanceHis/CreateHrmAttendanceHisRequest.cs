using _365EJSC.ERP.Contract.Abstractions;

namespace _365EJSC.ERP.Application.Requests.HRM.AttendanceHis
{
    /// <summary>
    /// Request to create a historical attendance record
    /// </summary>
    public record CreateHrmAttendanceHisRequest : ICommand
    {
        /// <summary>
        /// Attendance reference ID
        /// </summary>
        public int? AttendanceId { get; set; }

        /// <summary>
        /// Check-in time (DATETIME)
        /// </summary>
        public DateTime? CheckInTime { get; set; }

        /// <summary>
        /// Check-out time (DATETIME)
        /// </summary>
        public DateTime? CheckOutTime { get; set; }

        /// <summary>
        /// Minutes late
        /// </summary>
        public int? NumLate { get; set; }

        /// <summary>
        /// Minutes left early
        /// </summary>
        public int? NumEarlyLeave { get; set; }

        /// <summary>
        /// Total working minutes
        /// </summary>
        public int? WorkingMinutes { get; set; }

        /// <summary>
        /// Active status (0: Inactive, 1: Active)
        /// </summary>
        public int? IsActived { get; set; } = 1;
    }
}
