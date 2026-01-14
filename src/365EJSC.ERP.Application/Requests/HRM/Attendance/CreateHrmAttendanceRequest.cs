using _365EJSC.ERP.Contract.Abstractions;

namespace _365EJSC.ERP.Application.Requests.HRM.Attendance
{
    public record CreateHrmAttendanceRequest : ICommand
    {
        /// <summary>
        /// Employee ID Reference
        /// </summary>
        public int? EmployeeId { get; set; }

        /// <summary>
        /// Work Date (e.g., 20251111)
        /// </summary>
        public int? WorkDate { get; set; }

        /// <summary>
        /// Check-in timestamp (epoch time)
        /// </summary>
        public int? CheckInTime { get; set; } = (int)DateTimeOffset.Now.ToUnixTimeSeconds();

        /// <summary>
        /// Check-out timestamp (epoch time)
        /// </summary>
        public int? CheckOutTime { get; set; }

        /// <summary>
        /// Total working minutes
        /// </summary>
        public int? TotalWorkingMinutes { get; set; }

        /// <summary>
        /// Attendance status (0: Absent, 1: Present, 2: Late, etc.)
        /// </summary>
        public int? AttendanceStatus { get; set; } = 1;
    }

}
