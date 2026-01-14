using _365EJSC.ERP.Contract.Abstractions;
using System.Text.Json.Serialization;

namespace _365EJSC.ERP.Application.Requests.HRM.Attendance
{
    /// <summary>
    /// Request to delete an existing attendance record
    /// </summary>
    public record DeleteHrmAttendanceRequest : ICommand
    {
        /// <summary>
        /// ID of the Attendance to be deleted
        /// </summary>
        [JsonIgnore]
        public int? Id { get; set; }
    }
}
