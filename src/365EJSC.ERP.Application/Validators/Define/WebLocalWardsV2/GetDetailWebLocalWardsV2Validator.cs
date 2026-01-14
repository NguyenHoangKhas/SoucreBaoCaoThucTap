using _365EJSC.ERP.Application.Requests.Define.WebLocalWardsV2;
using _365EJSC.ERP.Contract.DependencyInjection.Extensions;
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Validators;

namespace _365EJSC.ERP.Application.Validators.Define.WebLocalWardsV2
{
    /// <summary>
    /// Validator for <see cref="GetDetailWebLocalWardsV2Request"/>
    /// </summary>
    public class GetDetailWebLocalWardsV2Validator : Validator<GetDetailWebLocalWardsV2Request>
    {
         public GetDetailWebLocalWardsV2Validator()
          {
               WithValidator(MsgCode.ERR_DEFINE_WEB_LOCAL_WARDS_V2_INVALID);
               RuleFor(x => x.Id).NotNull().GreaterThan(0);
          }
    }
}
