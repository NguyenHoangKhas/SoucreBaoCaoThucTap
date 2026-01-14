using _365EJSC.ERP.Application.Requests.HRM.Employee;
using _365EJSC.ERP.Contract.DependencyInjection.Extensions;
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Validators;

namespace _365EJSC.ERP.Application.Validators.HRM.Employee
{
    /// <summary>
    /// Validator for <see cref="DeleteEmployeeRequest"/>
    /// </summary>
    public class DeleteEmployeeValidator : Validator<DeleteEmployeeRequest>
    {
        /// <summary>
        /// Constructor of <see cref="DeleteWebLocalWardValidator"/>, register validator rules for <see cref="DeleteEmployeeRequest"/>
        /// </summary>
        public DeleteEmployeeValidator()
        {
            WithValidator(MsgCode.ERR_EMPLOYEE_INVALID);
            RuleFor(x => x.Id).NotNull().GreaterThan(0);
        }
    }
}
