using _365EJSC.ERP.Contract.Validators;
using _365EJSC.ERP.Application.Requests.HRM.EmployeeCompany;
using _365EJSC.ERP.Contract.DependencyInjection.Extensions;
using _365EJSC.ERP.Contract.Enumerations;

namespace _365EJSC.ERP.Application.Validators.HRM.EmployeeCompany
{
    public class GetDetailEmployeeCompanyValidator : Validator<GetDetailEmployeeCompanyRequest>
    {
        public GetDetailEmployeeCompanyValidator()
        {
            WithValidator(MsgCode.ERR_EMPLOYEE_COMPANY_INVALID);
            RuleFor(x => x.Id).NotNull().GreaterThan(0);
        }
    }
}
