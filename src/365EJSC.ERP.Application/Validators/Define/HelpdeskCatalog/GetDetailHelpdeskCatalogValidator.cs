using _365EJSC.ERP.Application.Requests.Define.HelpdeskCatalog;
using _365EJSC.ERP.Contract.DependencyInjection.Extensions;
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Validators;

namespace _365EJSC.ERP.Application.Requests.Define.HelpdeskCatalog
{
    /// <summary>
    /// Validator for <see cref="GetDetailHelpdeskCatalogRequest"/>
    /// </summary>
    public class GetDetailHelpdeskCatalogValidator : Validator<GetDetailHelpdeskCatalogRequest>
    {
         public GetDetailHelpdeskCatalogValidator()
          {
               WithValidator(MsgCode.ERR_DEFINE_HELPDESK_CATALOG_INVALID);
               RuleFor(x => x.Id).NotNull().GreaterThan(0);
          }
    }
}
