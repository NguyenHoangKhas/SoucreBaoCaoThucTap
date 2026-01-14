using _365EJSC.ERP.Application.Requests.HRM.AttendanceHis;
using _365EJSC.ERP.Contract.DependencyInjection.Extensions;
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Validators;

namespace _365EJSC.ERP.Application.Validators.HRM.AttendanceHis
{
    /// <summary>
    /// Validator for <see cref="CreateHrmAttendanceHisRequest"/>
    /// </summary>
    public class CreateHrmAttendanceHisValidator : Validator<CreateHrmAttendanceHisRequest>
    {
        public CreateHrmAttendanceHisValidator()
        {
            WithValidator(MsgCode.ERR_ATTENDANCE_INVALID);

            RuleFor(x => x.AttendanceId).NotNull().GreaterThan(0);
            RuleFor(x => x.CheckInTime).NotNull();
            RuleFor(x => x.CheckOutTime).NotNull();
            RuleFor(x => x.NumLate).GreaterThanOrEqual(0);
            RuleFor(x => x.NumEarlyLeave).GreaterThanOrEqual(0);
            RuleFor(x => x.WorkingMinutes).GreaterThanOrEqual(0);
            RuleFor(x => x.IsActived).InRange(0, 1);
        }
    }

}
