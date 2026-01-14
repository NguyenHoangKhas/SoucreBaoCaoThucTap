using _365EJSC.ERP.Application.Requests.HRM.EmployeeVerify;
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Validators;

namespace _365EJSC.ERP.Application.Validators.HRM.EmployeeVerify
{
    public class UpdateEmployeeVerifyValidator : Validator<UpdateEmployeeVerifyRequest>
    {
        /// <summary>
        /// Constructor of <see cref="UpdateEmployeeVerifyValidator"/>, register validator rules for <see cref="UpdateEmployeeVerifyRequest"/>
        /// </summary>
        public UpdateEmployeeVerifyValidator()
        {
            WithValidator(MsgCode.ERR_EMPLOYEE_VERIFY_INVALID);
            //RuleFor(x => x.VerImage).NotEmpty().MaxLength(EmployeeVerifyConst.VER_IMAGE_MAX_LENGTH);
        }
    }
}
