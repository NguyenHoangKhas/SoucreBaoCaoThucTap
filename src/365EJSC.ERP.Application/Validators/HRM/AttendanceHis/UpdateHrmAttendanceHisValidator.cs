using _365EJSC.ERP.Application.Requests.HRM.AttendanceHis;
using _365EJSC.ERP.Contract.DependencyInjection.Extensions;
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Validators;

namespace _365EJSC.ERP.Application.Validators.HRM.AttendanceHis
{
    /// <summary>
    /// Validator for <see cref="UpdateHrmAttendanceHisRequest"/>
    /// </summary>
    public class UpdateHrmAttendanceHisValidator : Validator<UpdateHrmAttendanceHisRequest>
    {
        /// <summary>
        /// Constructor, register rules
        /// </summary>
        public UpdateHrmAttendanceHisValidator()
        {
            WithValidator(MsgCode.ERR_ATTENDANCE_INVALID);

            RuleFor(x => x.Id).NotNull().GreaterThan(0);
            RuleFor(x => x.AttendanceId).GreaterThan(0);
            RuleFor(x => x.NumLate).GreaterThanOrEqual(0);
            RuleFor(x => x.NumEarlyLeave).GreaterThanOrEqual(0);
            RuleFor(x => x.WorkingMinutes).GreaterThanOrEqual(0);
            RuleFor(x => x.IsActived).InRange(0, 1);

        }
    }
}
