using _365EJSC.ERP.Application.Requests.HRM.EmployeeVerify;
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Validators;

namespace _365EJSC.ERP.Application.Validators.HRM.EmployeeVerify
{
    public class CreateEmployeeVerifyValidator : Validator<CreateEmployeeVerifyRequest>
    {
        /// <summary>
        /// Constructor of <see cref="CreateEmployeeVerifyValidator"/>, register validator rules for <see cref="CreateEmployeeVerifyRequest"/>
        /// </summary>
        public CreateEmployeeVerifyValidator()
        {
            WithValidator(MsgCode.ERR_EMPLOYEE_VERIFY_INVALID);
            RuleFor(x => x.EmployeeId).NotNull();
            //RuleFor(x => x.VerImage).NotEmpty().MaxLength(EmployeeVerifyConst.VER_IMAGE_MAX_LENGTH);
            RuleFor(x => x.UserIdVerify).NotNull();
            RuleFor(x => x.IsActived).NotNull();

        }
    }
}
