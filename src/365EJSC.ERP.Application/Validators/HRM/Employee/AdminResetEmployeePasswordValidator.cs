using _365EJSC.ERP.Contract.Validators;
using _365EJSC.ERP.Application.Requests.HRM.Employee;
using _365EJSC.ERP.Contract.Enumerations;

namespace _365EJSC.ERP.Application.Validators.HRM.Employee
{
    public class AdminResetEmployeePasswordValidator : Validator<AdminResetEmployeePasswordRequest>
    {
        public AdminResetEmployeePasswordValidator()
        {
            WithValidator(MsgCode.ERR_EMPLOYEE_INVALID);
            RuleFor(x => x.Id).NotNull();
        }
    }
}
