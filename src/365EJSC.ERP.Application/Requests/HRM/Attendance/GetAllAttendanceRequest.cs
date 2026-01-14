using _365EJSC.ERP.Contract.Abstractions;
using _365EJSC.ERP.Contract.Shared;

namespace _365EJSC.ERP.Application.Requests.HRM.Attendance
{
    /// <summary>
    /// Request để lấy tất cả bản ghi <see cref="Attendance"/> từ database, 
    /// có thể giới hạn số lượng bản ghi hoặc bỏ qua một số bản ghi
    /// </summary>
    public class GetAllAttendanceRequest : PaginationOptionalQuery, IQuery<object>
    {
        /// <summary>
        /// Lọc theo EmployeeId
        /// </summary>
        public int? EmployeeId { get; set; }

        /// <summary>
        /// Lọc theo WorkDate (ví dụ: 20251120)
        /// </summary>
        public int? WorkDate { get; set; }

        /// <summary>
        /// Lọc theo AttendanceStatus (0: Absent, 1: Present, 2: Late)
        /// </summary>
        public int? AttendanceStatus { get; set; }

        /// <summary>
        /// Lọc theo số phút làm việc tối thiểu
        /// </summary>
        public int? MinWorkingMinutes { get; set; }

        /// <summary>
        /// Lọc theo số phút làm việc tối đa
        /// </summary>
        public int? MaxWorkingMinutes { get; set; }
    }
}
