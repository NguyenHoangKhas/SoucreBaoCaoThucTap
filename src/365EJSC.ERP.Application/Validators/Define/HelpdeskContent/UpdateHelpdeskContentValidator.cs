using _365EJSC.ERP.Application.Requests.Define.HelpdeskContent;
using _365EJSC.ERP.Contract.DependencyInjection.Extensions;
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Validators;
using _365EJSC.ERP.Domain.Constants.Define;

namespace _365EJSC.ERP.Application.Validators.Define.HelpdeskContent
{
    /// <summary>
    /// Validator for <see cref="UpdateHelpdeskContentRequest"/>
    /// </summary>
    public class UpdateHelpdeskContentValidator : Validator<UpdateHelpdeskContentRequest>
    {
    /// <summary>
    /// Constructor of <see cref="UpdateHelpdeskContentValidator"/>, register validator rules for <see cref="UpdateHelpdeskContentRequest"/>
    /// </summary>
         public UpdateHelpdeskContentValidator()
          {
               WithValidator(MsgCode.ERR_DEFINE_HELPDESK_CONTENT_INVALID);
               RuleFor(x => x.Id).NotNull().GreaterThan(0);
               RuleFor(x => x.ContentDetail);
               RuleFor(x => x.CatalogId).GreaterThan(0);
          }
    }
}
