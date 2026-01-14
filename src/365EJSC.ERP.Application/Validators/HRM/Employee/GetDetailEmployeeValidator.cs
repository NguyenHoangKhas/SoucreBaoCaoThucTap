using _365EJSC.ERP.Application.Requests.HRM.Employee;
using _365EJSC.ERP.Contract.DependencyInjection.Extensions;
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Validators;

namespace _365EJSC.ERP.Application.Validators.HRM.Employee
{
    /// <summary>
    /// Validator for <see cref="GetDetailEmployeeRequest"/>
    /// </summary>
    public class GetDetailEmployeeValidator : Validator<GetDetailEmployeeRequest>
    {
        /// <summary>
        /// Constructor of <see cref="GetDetailWebLocalWardValidator"/>, register validator rules for <see cref="GetDetailEmployeeRequest"/>
        /// </summary>
        public GetDetailEmployeeValidator()
        {
            WithValidator(MsgCode.ERR_EMPLOYEE_INVALID);
            RuleFor(x => x.Id).NotNull().GreaterThan(0);
        }
    }
}
