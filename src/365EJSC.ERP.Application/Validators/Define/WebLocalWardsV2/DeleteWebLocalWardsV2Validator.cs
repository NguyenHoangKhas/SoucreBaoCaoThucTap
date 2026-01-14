using _365EJSC.ERP.Application.Requests.Define.WebLocalWardsV2;
using _365EJSC.ERP.Contract.DependencyInjection.Extensions;
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Validators;
using _365EJSC.ERP.Domain.Constants.Define;

namespace _365EJSC.ERP.Application.Validators.Define.WebLocalWardsV2
{
    /// <summary>
    /// Validator for <see cref="DeleteWebLocalWardsV2Request"/>
    /// </summary>
    public class DeleteWebLocalWardsV2Validator : Validator<DeleteWebLocalWardsV2Request>
    {
    /// <summary>
    /// Constructor of <see cref="DeleteWebLocalWardsV2Validator"/>, register validator rules for <see cref="DeleteWebLocalWardsV2Request"/>
    /// </summary>
         public DeleteWebLocalWardsV2Validator()
          {
               WithValidator(MsgCode.ERR_DEFINE_WEB_LOCAL_WARDS_V2_INVALID);
               RuleFor(x => x.Id).NotNull().GreaterThan(0);
          }
    }
}
