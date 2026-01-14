using _365EJSC.ERP.Application.Requests.Define.HelpdeskContent;
using _365EJSC.ERP.Contract.DependencyInjection.Extensions;
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Validators;

namespace _365EJSC.ERP.Application.Requests.Define.HelpdeskContent
{
    /// <summary>
    /// Validator for <see cref="GetDetailHelpdeskContentRequest"/>
    /// </summary>
    public class GetDetailHelpdeskContentValidator : Validator<GetDetailHelpdeskContentRequest>
    {
         public GetDetailHelpdeskContentValidator()
          {
               WithValidator(MsgCode.ERR_DEFINE_HELPDESK_CONTENT_INVALID);
               RuleFor(x => x.Id).NotNull().GreaterThan(0);
          }
    }
}
