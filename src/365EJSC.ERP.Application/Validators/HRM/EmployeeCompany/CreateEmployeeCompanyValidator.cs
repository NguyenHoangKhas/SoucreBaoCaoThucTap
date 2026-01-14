using _365EJSC.ERP.Application.Requests.HRM.EmployeeCompany;
using _365EJSC.ERP.Contract.DependencyInjection.Extensions;
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Validators;

namespace _365EJSC.ERP.Application.Validators.HRM.EmployeeCompany
{
    public class CreateEmployeeCompanyValidator : Validator<CreateEmployeeCompanyRequest>
    {
        public CreateEmployeeCompanyValidator()
        {
            WithValidator(MsgCode.ERR_EMPLOYEE_COMPANY_INVALID);
            RuleFor(x => x.EmployeeId).NotNull().GreaterThan(0);
            RuleFor(x => x.CdId).NotNull().GreaterThan(0);
        }
    }
}
