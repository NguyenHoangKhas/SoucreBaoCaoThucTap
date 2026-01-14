using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Base;
using _365EJSC.ERP.Domain.Entities.HRM;

namespace _365EJSC.ERP.Domain.Abstractions.Repositories.Sql
{
    /// <summary>
    /// Provide repository for <see cref="AttendanceHis"/>, inherit from <see cref="IGenericSqlRepository{TEntity,TKey}"/>
    /// </summary>
    public interface IHrmAttendanceHisSqlRepository : IGenericSqlRepository<AttendanceHis, int>
    {
        /// <summary>
        /// Validate attendance history record before saving or updating.
        /// </summary>
        /// <param name="attendanceId">Attendance ID reference</param>
        /// <param name="actionType">Type of action (e.g., CheckIn, CheckOut, Update)</param>
        /// <param name="actionBy">User performing the action</param>
        /// <returns>A task representing the asynchronous validation operation.</returns>
        Task ValidateAttendanceHistoryAsync(int? attendanceId, string? actionType, string? actionBy);
    }
}
