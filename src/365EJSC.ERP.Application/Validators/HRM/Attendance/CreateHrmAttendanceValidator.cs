using _365EJSC.ERP.Application.Requests.HRM.Attendance;
using _365EJSC.ERP.Contract.DependencyInjection.Extensions;
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Validators;
using _365EJSC.ERP.Domain.Constants.HRM;

namespace _365EJSC.ERP.Application.Validators.HRM.Attendance
{
    /// <summary>
    /// Validator for <see cref="CreateHrmAttendanceRequest"/>
    /// </summary>
    public class CreateHrmAttendanceValidator : Validator<CreateHrmAttendanceRequest>
    {
        /// <summary>
        /// Constructor of <see cref="CreateHrmAttendanceValidator"/>, register validator rules for <see cref="CreateHrmAttendanceRequest"/>
        /// </summary>
        public CreateHrmAttendanceValidator()
        {
            // --- Tổng validator ---
            WithValidator(MsgCode.ERR_ATTENDANCE_INVALID);

            // --- Validation rules ---
            RuleFor(x => x.EmployeeId)
                .NotNull()
                .GreaterThan(0);

            RuleFor(x => x.WorkDate)
                .NotNull()
                .GreaterThan(0);

            // Use InRange for nullable int; the nullable overload checks HasValue internally
            RuleFor(x => x.AttendanceStatus)
                .InRange(0, 2);

            // Use GreaterThanOrEqual for nullable int; the nullable overload checks HasValue internally
            RuleFor(x => x.TotalWorkingMinutes)
                .GreaterThanOrEqual(0);
        }
    }
}