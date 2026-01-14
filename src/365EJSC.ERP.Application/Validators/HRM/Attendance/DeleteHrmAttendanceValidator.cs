using _365EJSC.ERP.Application.Requests.HRM.Attendance;
using _365EJSC.ERP.Contract.DependencyInjection.Extensions;
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Validators;

namespace _365EJSC.ERP.Application.Validators.HRM.Attendance
{
    /// <summary>
    /// Validator for <see cref="DeleteHrmAttendanceRequest"/>
    /// </summary>
    public class DeleteHrmAttendanceValidator : Validator<DeleteHrmAttendanceRequest>
    {
        /// <summary>
        /// Constructor of <see cref="DeleteHrmAttendanceValidator"/>, register validator rules for <see cref="DeleteHrmAttendanceRequest"/>
        /// </summary>
        public DeleteHrmAttendanceValidator()
        {
            WithValidator(MsgCode.ERR_ATTENDANCE_INVALID);
            RuleFor(x => x.Id).NotNull().GreaterThan(0);
        }
    }
}
