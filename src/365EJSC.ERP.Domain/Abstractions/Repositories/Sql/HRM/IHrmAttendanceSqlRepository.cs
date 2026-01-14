using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Base;
using _365EJSC.ERP.Domain.Entities.HRM;

namespace _365EJSC.ERP.Domain.Abstractions.Repositories.Sql
{
    /// <summary>
    /// Provide repository for <see cref="Attendance"/>, inherit from <see cref="IGenericSqlRepository{TEntity,TKey}"/>
    /// </summary>
    public interface IHrmAttendanceSqlRepository : IGenericSqlRepository<Attendance, int>
    {
        /// <summary>
        /// Validate attendance data for a specific employee
        /// </summary>
        /// <param name="employeeId">Employee ID</param>
        /// <param name="workDate">Work date (e.g., 20251111)</param>
        /// <returns>Task representing the validation operation</returns>
        Task ValidateAttendanceAsync(int employeeId, int? workDate);

        /// <summary>
        /// Get the attendance record of an employee for a specific day
        /// </summary>
        /// <param name="employeeId">Employee ID</param>
        /// <param name="workDate">Work date</param>
        /// <returns>Attendance record if found</returns>
        Task<Attendance?> GetByEmployeeAndDateAsync(int employeeId, int? workDate);
    }
}
