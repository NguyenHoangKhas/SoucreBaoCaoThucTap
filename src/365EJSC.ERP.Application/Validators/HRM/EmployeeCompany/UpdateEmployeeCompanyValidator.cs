using _365EJSC.ERP.Contract.Validators;
using _365EJSC.ERP.Application.Requests.HRM.EmployeeCompany;
using _365EJSC.ERP.Contract.DependencyInjection.Extensions;
using _365EJSC.ERP.Contract.Enumerations;

namespace _365EJSC.ERP.Application.Validators.HRM.EmployeeCompany
{
    public class UpdateEmployeeCompanyValidator : Validator<UpdateEmployeeCompanyRequest>
    {
        public UpdateEmployeeCompanyValidator()
        {
            WithValidator(MsgCode.ERR_EMPLOYEE_COMPANY_INVALID);
            RuleFor(x => x.Id).NotNull().GreaterThan(0);
            RuleFor(x => x.EmployeeId).GreaterThan(0);
            RuleFor(x => x.CdId).GreaterThan(0);
        }
    }
}
