using _365EJSC.ERP.Application.Requests.Define.WebLocalWardsV2;
using _365EJSC.ERP.Contract.DependencyInjection.Extensions;
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Validators;
using _365EJSC.ERP.Domain.Constants.Define;

namespace _365EJSC.ERP.Application.Validators.Define.WebLocalWardsV2
{
    /// <summary>
    /// Validator for <see cref="UpdateWebLocalWardsV2Request"/>
    /// </summary>
    public class UpdateWebLocalWardsV2Validator : Validator<UpdateWebLocalWardsV2Request>
    {
    /// <summary>
    /// Constructor of <see cref="UpdateWebLocalWardsV2Validator"/>, register validator rules for <see cref="UpdateWebLocalWardsV2Request"/>
    /// </summary>
         public UpdateWebLocalWardsV2Validator()
          {
               WithValidator(MsgCode.ERR_DEFINE_WEB_LOCAL_WARDS_V2_INVALID);
               RuleFor(x => x.Id).NotNull().GreaterThan(0);
               RuleFor(x => x.Name).MaxLength(WebLocalWardsV2Const.NAME_MAX_LENGTH);
               RuleFor(x => x.NameEn).MaxLength(WebLocalWardsV2Const.NAME_EN_MAX_LENGTH);
               RuleFor(x => x.FullName).MaxLength(WebLocalWardsV2Const.FULL_NAME_MAX_LENGTH);
               RuleFor(x => x.FullNameEn).MaxLength(WebLocalWardsV2Const.FULL_NAME_EN_MAX_LENGTH);
               RuleFor(x => x.Latitude);
               RuleFor(x => x.Longitude);
               RuleFor(x => x.WardPid).GreaterThan(0);
               RuleFor(x => x.KeyLocalization).MaxLength(WebLocalWardsV2Const.KEY_LOCALIZATION_MAX_LENGTH);
          }
    }
}
