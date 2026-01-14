using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Exceptions;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql;
using _365EJSC.ERP.Domain.Constants.HRM;
using _365EJSC.ERP.Domain.Entities.HRM;
using _365EJSC.ERP.Persistence.Repositories.Base;
using Microsoft.IdentityModel.Tokens;

namespace _365EJSC.ERP.Persistence.Repositories.HRM
{
    /// <summary>
    /// Implementation of <see cref="IHrmAttendanceHisSqlRepository"/>
    /// </summary>
    public class AttendanceHisSqlRepository : GenericSqlRepository<AttendanceHis, int>, IHrmAttendanceHisSqlRepository
    {
        /// <summary>
        /// Initialize new instance of <see cref="AttendanceHisSqlRepository"/>
        /// </summary>
        public AttendanceHisSqlRepository(ApplicationDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Validate attendance history record before saving or updating.
        /// </summary>
        /// <param name="attendanceId">Reference to attendance record</param>
        /// <param name="actionType">Type of action (CheckIn, CheckOut...)</param>
        /// <param name="actionTime">Epoch time of the action</param>
        /// <param name="actionBy">User who performed the action</param>
        /// <exception cref="CustomException"></exception>
        public async Task ValidateAttendanceHistoryAsync(int? attendanceId, string? actionType, string? actionBy)
        {
            // Validate attendance reference
            if (attendanceId != null)
            {
                bool exists = await context.CheckExistsAsync<Attendance, int>((int)attendanceId);
                if (!exists)
                {
                    CustomException.ThrowNotFoundException(
                        typeof(Attendance),
                        MsgCode.ERR_ATTENDANCE_ID_NOT_FOUND,
                        AttendanceHisConst.MSG_ATTENDANCE_ID_NOT_FOUND
                    );
                }
            }

            // Validate action type
            if (actionType.IsNullOrEmpty())
            {
                CustomException.ThrowValidationException(
                    MsgCode.ERR_INVALID,
                    $"{AttendanceHisConst.FIELD_ACTION_TYPE} is required."
                );
            }

            // Validate action by
            if (actionBy.IsNullOrEmpty())
            {
                CustomException.ThrowValidationException(
                    MsgCode.ERR_INVALID,
                    $"{AttendanceHisConst.FIELD_ACTION_BY} is required."
                );
            }
        }

    }
}
