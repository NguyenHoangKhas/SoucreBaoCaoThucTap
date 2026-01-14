using _365EJSC.ERP.Application.Requests.HRM.Attendance;
using _365EJSC.ERP.Contract.DependencyInjection.Extensions;
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Validators;
using _365EJSC.ERP.Domain.Constants.HRM;

namespace _365EJSC.ERP.Application.Validators.HRM.Attendance
{
    /// <summary>
    /// Validator for <see cref="UpdateHrmAttendanceRequest"/>
    /// </summary>
    public class UpdateHrmAttendanceValidator : Validator<UpdateHrmAttendanceRequest>
    {
        /// <summary>
        /// Constructor of <see cref="UpdateHrmAttendanceValidator"/>, register validator rules for <see cref="UpdateHrmAttendanceRequest"/>
        /// </summary>
        public UpdateHrmAttendanceValidator()
        {
            WithValidator(MsgCode.ERR_ATTENDANCE_INVALID);

            RuleFor(x => x.Id).NotNull().GreaterThan(0);
            RuleFor(x => x.EmployeeId).NotNull().GreaterThan(0);
            RuleFor(x => x.WorkDate).NotNull().GreaterThan(0);
            RuleFor(x => x.CheckInTime).GreaterThanOrEqual(0);
            RuleFor(x => x.CheckOutTime).GreaterThanOrEqual(0);
            RuleFor(x => x.TotalWorkingMinutes).GreaterThanOrEqual(0);
            RuleFor(x => x.AttendanceStatus).InRange(0, 5);
        }
    }
}
