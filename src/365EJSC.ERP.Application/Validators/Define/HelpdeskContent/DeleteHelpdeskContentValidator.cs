using _365EJSC.ERP.Application.Requests.Define.HelpdeskContent;
using _365EJSC.ERP.Contract.DependencyInjection.Extensions;
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Validators;
using _365EJSC.ERP.Domain.Constants.Define;

namespace _365EJSC.ERP.Application.Validators.Define.HelpdeskContent
{
    /// <summary>
    /// Validator for <see cref="DeleteHelpdeskContentRequest"/>
    /// </summary>
    public class DeleteHelpdeskContentValidator : Validator<DeleteHelpdeskContentRequest>
    {
    /// <summary>
    /// Constructor of <see cref="DeleteHelpdeskContentValidator"/>, register validator rules for <see cref="DeleteHelpdeskContentRequest"/>
    /// </summary>
         public DeleteHelpdeskContentValidator()
          {
               WithValidator(MsgCode.ERR_DEFINE_HELPDESK_CONTENT_INVALID);
               RuleFor(x => x.Id).NotNull().GreaterThan(0);
          }
    }
}
