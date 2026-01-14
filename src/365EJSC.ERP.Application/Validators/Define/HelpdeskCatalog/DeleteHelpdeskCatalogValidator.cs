using _365EJSC.ERP.Application.Requests.Define.HelpdeskCatalog;
using _365EJSC.ERP.Contract.DependencyInjection.Extensions;
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Validators;
using _365EJSC.ERP.Domain.Constants.Define;

namespace _365EJSC.ERP.Application.Validators.Define.HelpdeskCatalog
{
    /// <summary>
    /// Validator for <see cref="DeleteHelpdeskCatalogRequest"/>
    /// </summary>
    public class DeleteHelpdeskCatalogValidator : Validator<DeleteHelpdeskCatalogRequest>
    {
    /// <summary>
    /// Constructor of <see cref="DeleteHelpdeskCatalogValidator"/>, register validator rules for <see cref="DeleteHelpdeskCatalogRequest"/>
    /// </summary>
         public DeleteHelpdeskCatalogValidator()
          {
               WithValidator(MsgCode.ERR_DEFINE_HELPDESK_CATALOG_INVALID);
               RuleFor(x => x.Id).NotNull().GreaterThan(0);
          }
    }
}
