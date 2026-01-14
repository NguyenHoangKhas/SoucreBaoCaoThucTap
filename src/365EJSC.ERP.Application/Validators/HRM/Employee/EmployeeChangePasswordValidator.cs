using _365EJSC.ERP.Contract.Validators;
using _365EJSC.ERP.Application.Requests.HRM.Employee;
using _365EJSC.ERP.Contract.DependencyInjection.Extensions;
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Domain.Constants.Define;

namespace _365EJSC.ERP.Application.Validators.HRM.Employee
{
    public class EmployeeChangePasswordValidator : Validator<EmployeeChangePasswordRequest>
    {
        public EmployeeChangePasswordValidator()
        {
            WithValidator(MsgCode.ERR_EMPLOYEE_INVALID);
            RuleFor(x => x.Id).NotNull();
            //RuleFor(x => x.OldPassword).NotNull().NotEmpty().MaxLength(GeneralCompanyConst.PASSWORD_MAX_LENGTH);
            //RuleFor(x => x.NewPassword).NotNull().NotEmpty().MaxLength(GeneralCompanyConst.PASSWORD_MAX_LENGTH);
            //RuleFor(x => x.ConfirmNewPassword).NotNull().NotEmpty().MaxLength(GeneralCompanyConst.PASSWORD_MAX_LENGTH);
        }
    }
}
