using _365EJSC.ERP.Application.Requests.Define.WebLocalWardsV2;
using _365EJSC.ERP.Contract.DependencyInjection.Extensions;
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Validators;
using _365EJSC.ERP.Domain.Constants.Define;

namespace _365EJSC.ERP.Application.Validators.Define.WebLocalWardsV2
{
    /// <summary>
    /// Validator for <see cref="CreateWebLocalWardsV2Request"/>
    /// </summary>
    public class CreateWebLocalWardsV2Validator : Validator<CreateWebLocalWardsV2Request>
    {
    /// <summary>
    /// Constructor of <see cref="CreateWebLocalWardsV2Validator"/>, register validator rules for <see cref="CreateWebLocalWardsV2Request"/>
    /// </summary>
         public CreateWebLocalWardsV2Validator()
          {
               WithValidator(MsgCode.ERR_DEFINE_WEB_LOCAL_WARDS_V2_INVALID);
               RuleFor(x => x.Name).NotNull().MaxLength(WebLocalWardsV2Const.NAME_MAX_LENGTH);
               RuleFor(x => x.NameEn).NotNull().MaxLength(WebLocalWardsV2Const.NAME_EN_MAX_LENGTH);
               RuleFor(x => x.FullName).NotNull().MaxLength(WebLocalWardsV2Const.FULL_NAME_MAX_LENGTH);
               RuleFor(x => x.FullNameEn).NotNull().MaxLength(WebLocalWardsV2Const.FULL_NAME_EN_MAX_LENGTH);
               RuleFor(x => x.Latitude).NotNull();
               RuleFor(x => x.Longitude).NotNull();
               RuleFor(x => x.WardPid).GreaterThan(0);
               RuleFor(x => x.KeyLocalization).MaxLength(WebLocalWardsV2Const.KEY_LOCALIZATION_MAX_LENGTH);
          }
    }
}
