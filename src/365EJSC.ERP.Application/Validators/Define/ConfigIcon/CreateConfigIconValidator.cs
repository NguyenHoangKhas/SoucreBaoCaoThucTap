using _365EJSC.ERP.Application.Requests.Define.ConfigIcon;
using _365EJSC.ERP.Contract.DependencyInjection.Extensions;
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Validators;
using _365EJSC.ERP.Domain.Constants.Define;

namespace _365EJSC.ERP.Application.Validators.Define.ConfigIcon
{
    /// <summary>
    /// Validator for <see cref="CreateConfigIconRequest"/>
    /// </summary>
    public class CreateConfigIconValidator : Validator<CreateConfigIconRequest>
    {
        /// <summary>
        /// Constructor of <see cref="CreateConfigIconRequest"/>, register validator rules for <see cref="CreateConfigIconRequest"/>
        /// </summary>
        public CreateConfigIconValidator()
        {
            WithValidator(MsgCode.ERR_CONFIG_ICON_INVALID);
            RuleFor(x => x.Id).NotNull().NotEmpty().IsConstantCase().MaxLength(ConfigIconConst.IDX_KEY_MAX_LENGTH);
            RuleFor(x => x.IconDescription).NotNull().NotEmpty().MaxLength(ConfigIconConst.DESCRIPTION_MAX_LENGTH);
            RuleFor(x => x.IconUrlBase64).NotNull().NotEmpty();
        }
    }
}
