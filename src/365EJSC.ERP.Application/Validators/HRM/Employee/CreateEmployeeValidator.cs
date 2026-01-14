using _365EJSC.ERP.Application.Requests.HRM.Employee;
using _365EJSC.ERP.Contract.DependencyInjection.Extensions;
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Validators;
using _365EJSC.ERP.Domain.Constants.HRM;

namespace _365EJSC.ERP.Application.Validators.HRM.Employee
{
    /// <summary>
    /// Validator for <see cref="CreateEmployeeRequest"/>
    /// </summary>
    public class CreateEmployeeValidator : Validator<CreateEmployeeRequest>
    {
        /// <summary>
        /// Constructor of <see cref="CreateEmployeeValidator"/>, register validator rules for <see cref="CreateEmployeeRequest"/>
        /// </summary>
        public CreateEmployeeValidator()
        {
            WithValidator(MsgCode.ERR_EMPLOYEE_INVALID);

            RuleFor(x => x.EmpCitizenIdentity).MaxLength(EmployeeConst.CITIZEN_IDENTITY_MAX_LENGTH);
            RuleFor(x => x.EmpTaxCode).MaxLength(EmployeeConst.TAX_CODE_MAX_LENGTH);
            RuleFor(x => x.EmpCode).NotNull()!.NotEmpty().MaxLength(EmployeeConst.CODE_MAX_LENGTH);
            RuleFor(x => x.EmpFirstName).NotNull()!.NotEmpty().MaxLength(EmployeeConst.FIRST_NAME_MAX_LENGTH);
            RuleFor(x => x.EmpLastName).NotNull()!.NotEmpty().MaxLength(EmployeeConst.LAST_NAME_MAX_LENGTH);
            RuleFor(x => x.EmpTel).NotNull()!.NotEmpty().MaxLength(EmployeeConst.TEL_MAX_LENGTH);
            RuleFor(x => x.EmpEmail).NotNull().NotEmpty().MaxLength(EmployeeConst.EMAIL_MAX_LENGTH);
            RuleFor(x => x.EmpEducationLevel).MaxLength(EmployeeConst.EDUCATION_LEVEL_MAX_LENGTH);
            RuleFor(x => x.Password).NotNull().NotEmpty().MaxLength(EmployeeConst.PASSWORD_MAX_LENGTH);
            RuleFor(x => x.CompanyId).NotNull().GreaterThan(0);
            RuleFor(x => x.DegreeId).GreaterThan(0);
            RuleFor(x => x.TraMajId).GreaterThan(0);
            RuleFor(x => x.EmpAccountNumber).MaxLength(EmployeeConst.ACCOUNT_NUMBER_MAX_LENGTH);
            RuleFor(x => x.NationId).GreaterThan(0);
            RuleFor(x => x.ReligionId).GreaterThan(0);
            RuleFor(x => x.MaritalId).GreaterThan(0);
            RuleFor(x => x.EmpPlaceOfResidenceAddress).MaxLength(EmployeeConst.RESIDENCE_ADDRESS_MAX_LENGTH);
        }
    }
}
