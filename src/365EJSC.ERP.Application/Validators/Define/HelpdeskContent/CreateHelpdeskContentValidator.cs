using _365EJSC.ERP.Application.Requests.Define.HelpdeskContent;
using _365EJSC.ERP.Contract.DependencyInjection.Extensions;
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Validators;
using _365EJSC.ERP.Domain.Constants.Define;

namespace _365EJSC.ERP.Application.Validators.Define.HelpdeskContent
{
    /// <summary>
    /// Validator for <see cref="CreateHelpdeskContentRequest"/>
    /// </summary>
    public class CreateHelpdeskContentValidator : Validator<CreateHelpdeskContentRequest>
    {
    /// <summary>
    /// Constructor of <see cref="CreateHelpdeskContentValidator"/>, register validator rules for <see cref="CreateHelpdeskContentRequest"/>
    /// </summary>
         public CreateHelpdeskContentValidator()
          {
               WithValidator(MsgCode.ERR_DEFINE_HELPDESK_CONTENT_INVALID);
               RuleFor(x => x.ContentDetail).NotNull();
               RuleFor(x => x.CatalogId).NotNull().GreaterThan(0);
          }
    }
}
