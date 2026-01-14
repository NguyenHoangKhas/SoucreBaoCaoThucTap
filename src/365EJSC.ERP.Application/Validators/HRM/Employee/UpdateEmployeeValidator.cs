using _365EJSC.ERP.Application.Requests.HRM.Employee;
using _365EJSC.ERP.Contract.DependencyInjection.Extensions;
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Validators;
using _365EJSC.ERP.Domain.Constants.HRM;

namespace _365EJSC.ERP.Application.Validators.HRM.Employee
{
    /// <summary>
    /// Validator for <see cref="UpdateEmployeeRequest"/>
    /// </summary>
    public class UpdateEmployeeValidator : Validator<UpdateEmployeeRequest>
    {
        /// <summary>
        /// Constructor of <see cref="UpdateEmployeeValidator"/>, register validator rules for <see cref="UpdateEmployeeRequest"/>
        /// </summary>
        public UpdateEmployeeValidator()
        {
            WithValidator(MsgCode.ERR_EMPLOYEE_INVALID);
            RuleFor(x => x.Id).NotNull().GreaterThan(0);
            RuleFor(x => x.EmpCitizenIdentity).MaxLength(EmployeeConst.CITIZEN_IDENTITY_MAX_LENGTH);
            RuleFor(x => x.EmpTaxCode).MaxLength(EmployeeConst.TAX_CODE_MAX_LENGTH);
            RuleFor(x => x.EmpCode).NotEmpty().MaxLength(EmployeeConst.CODE_MAX_LENGTH);
            RuleFor(x => x.EmpFirstName)!.NotEmpty().MaxLength(EmployeeConst.FIRST_NAME_MAX_LENGTH);
            RuleFor(x => x.EmpLastName)!.NotEmpty().MaxLength(EmployeeConst.LAST_NAME_MAX_LENGTH);
            RuleFor(x => x.EmpTel).NotEmpty().MaxLength(EmployeeConst.TEL_MAX_LENGTH);
            RuleFor(x => x.EmpEmail).MaxLength(EmployeeConst.EMAIL_MAX_LENGTH);
            RuleFor(x => x.EmpEducationLevel).MaxLength(EmployeeConst.EDUCATION_LEVEL_MAX_LENGTH);
            RuleFor(x => x.EmpAccountNumber).MaxLength(EmployeeConst.ACCOUNT_NUMBER_MAX_LENGTH);
            RuleFor(x => x.EmpPlaceOfResidenceAddress).MaxLength(EmployeeConst.RESIDENCE_ADDRESS_MAX_LENGTH);
        }
    }
}
