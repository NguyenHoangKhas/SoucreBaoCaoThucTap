using _365EJSC.ERP.Application.Requests.HRM.Employee;
using _365EJSC.ERP.Contract.DependencyInjection.Extensions;
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Validators;

namespace _365EJSC.ERP.Application.Validators.HRM.Employee
{
    public class EmployeeLoginValidator : Validator<EmployeeLoginRequest>
    {
        public EmployeeLoginValidator()
        {
            WithValidator(MsgCode.ERR_EMPLOYEE_INVALID);
            RuleFor(x => x.EmpCode).NotNull().NotEmpty();
            RuleFor(x => x.Password).NotNull().NotEmpty();
        }
    }
}
