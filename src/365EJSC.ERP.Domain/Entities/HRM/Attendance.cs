using _365EJSC.ERP.Domain.Abstractions.Aggregates;
using System.Text.Json.Serialization;

namespace _365EJSC.ERP.Domain.Entities.HRM
{
    public class Attendance : AggregateRoot<int>
    {
        /// <summary>
        /// Employee ID reference (unique, one-to-one)
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// Check-in timestamp (epoch or int representation)
        /// </summary>
        public int? CheckInTime { get; set; }

        /// <summary>
        /// Check-out timestamp (epoch or int representation)
        /// </summary>
        public int? CheckOutTime { get; set; }

        /// <summary>
        /// Working day (e.g. 20251111)
        /// </summary>
        public int? WorkDate { get; set; }

        /// <summary>
        /// Total working hours (in minutes)
        /// </summary>
        public int? TotalWorkingMinutes { get; set; }

        /// <summary>
        /// Status (0: Absent, 1: Present, 2: Late, etc.)
        /// </summary>
        public int? AttendanceStatus { get; set; }

        /// <summary>
        /// Navigation to Employee (1–1)
        /// </summary>
        [JsonIgnore]
        public virtual Employee? Employee { get; set; }
    }
}

