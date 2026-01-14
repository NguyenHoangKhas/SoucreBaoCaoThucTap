using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Exceptions;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql;
using _365EJSC.ERP.Domain.Constants.HRM;
using _365EJSC.ERP.Domain.Entities.Define;
using _365EJSC.ERP.Domain.Entities.HRM;
using _365EJSC.ERP.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace _365EJSC.ERP.Persistence.Repositories.HRM
{
    /// <summary>
    /// Implementation of IHrmAttendanceSqlRepository
    /// </summary>
    public class AttendanceSqlRepository : GenericSqlRepository<Attendance, int>, IHrmAttendanceSqlRepository
    {
        /// <summary>
        /// Constructor for HrmAttendanceSqlRepository
        /// </summary>
        public AttendanceSqlRepository(ApplicationDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Validate attendance data for an employee on a specific date
        /// </summary>
        public async Task ValidateAttendanceAsync(int employeeId, int? workDate)
        {
            // Kiểm tra employee tồn tại
            var employeeExists = await context.CheckExistsAsync<Employee, int>(employeeId);
            if (!employeeExists)
            {
                CustomException.ThrowNotFoundException(
                    typeof(Employee),
                    MsgCode.ERR_EMPLOYEE_ID_NOT_FOUND,
                    AttendanceConst.MSG_EMPLOYEE_ID_NOT_FOUND
                );
            }

            // Kiểm tra trùng ngày chấm công
            if (workDate != null)
            {
                var exists = await context.Set<Attendance>()
                    .AnyAsync(x => x.EmployeeId == employeeId && x.WorkDate == workDate);

                if (exists)
                {
                    CustomException.ThrowConflictException(
                        MsgCode.ERR_ATTENDANCE_ALREADY_EXISTS,
                        AttendanceConst.MSG_ATTENDANCE_ALREADY_EXISTS
                    );
                }
            }
        }

        /// <summary>
        /// Get attendance record by employee and date
        /// </summary>
        public async Task<Attendance?> GetByEmployeeAndDateAsync(int employeeId, int? workDate)
        {
            return await context.Set<Attendance>()
                .FirstOrDefaultAsync(x => x.EmployeeId == employeeId && x.WorkDate == workDate);
        }
    }
}
