using _365EJSC.ERP.Application.Requests.HRM.EmployeeVerify;
using _365EJSC.ERP.Contract.DependencyInjection.Extensions;
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Validators;

namespace _365EJSC.ERP.Application.Validators.HRM.EmployeeVerify
{
    public class DeleteEmployeeVerifyValidator : Validator<DeleteEmployeeVerifyRequest>
    {
        /// <summary>
        /// Constructor of <see cref="DeleteEmployeeVerifyValidator"/>, register validator rules for <see cref="DeleteEmployeeVerifyRequest"/>
        /// </summary>
        public DeleteEmployeeVerifyValidator()
        {
            WithValidator(MsgCode.ERR_EMPLOYEE_VERIFY_INVALID);
            RuleFor(x => x.Id).NotNull().GreaterThan(0);
        }
    }
}
