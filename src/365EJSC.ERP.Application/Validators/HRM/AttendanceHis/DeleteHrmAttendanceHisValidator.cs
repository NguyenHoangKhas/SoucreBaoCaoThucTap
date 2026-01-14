using _365EJSC.ERP.Contract.DependencyInjection.Extensions;
using _365EJSC.ERP.Application.Requests.HRM.AttendanceHis;  
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Validators;

namespace _365EJSC.ERP.Application.Validators.HRM.AttendanceHis
{
    public class DeleteHrmAttendanceHisValidator : Validator<DeleteHrmAttendanceHisRequest>
    {
        public DeleteHrmAttendanceHisValidator()
        {
            WithValidator(MsgCode.ERR_ATTENDANCE_INVALID);
            RuleFor(x => x.Id).NotNull().GreaterThan(0);
        }
    }
}
