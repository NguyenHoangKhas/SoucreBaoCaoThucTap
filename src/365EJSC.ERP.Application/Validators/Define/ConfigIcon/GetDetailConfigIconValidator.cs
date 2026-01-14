using _365EJSC.ERP.Application.Requests.Define.ConfigIcon;
using _365EJSC.ERP.Contract.DependencyInjection.Extensions;
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Validators;
using _365EJSC.ERP.Domain.Constants.Define;

namespace _365EJSC.ERP.Application.Validators.Define.ConfigIcon
{
    /// <summary>
    /// Validator for <see cref="GetDetailConfigIconRequest"/>
    /// </summary>
    public class GetDetailConfigIconValidator : Validator<GetDetailConfigIconRequest>
    {
        /// <summary>
        /// Constructor of <see cref="GetDetailConfigIconRequest"/>, register validator rules for <see cref="GetDetailConfigIconRequest"/>
        /// </summary>
        public GetDetailConfigIconValidator()
        {
            WithValidator(MsgCode.ERR_CONFIG_ICON_INVALID);
            RuleFor(x => x.Id).NotNull().NotEmpty().IsConstantCase().MaxLength(ConfigIconConst.IDX_KEY_MAX_LENGTH);
        }
    }
}
