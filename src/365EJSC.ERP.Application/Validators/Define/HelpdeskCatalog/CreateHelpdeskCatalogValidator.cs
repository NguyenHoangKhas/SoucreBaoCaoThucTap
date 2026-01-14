using _365EJSC.ERP.Application.Requests.Define.HelpdeskCatalog;
using _365EJSC.ERP.Contract.DependencyInjection.Extensions;
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Validators;
using _365EJSC.ERP.Domain.Constants.Define;

namespace _365EJSC.ERP.Application.Validators.Define.HelpdeskCatalog
{
    /// <summary>
    /// Validator for <see cref="CreateHelpdeskCatalogRequest"/>
    /// </summary>
    public class CreateHelpdeskCatalogValidator : Validator<CreateHelpdeskCatalogRequest>
    {
    /// <summary>
    /// Constructor of <see cref="CreateHelpdeskCatalogValidator"/>, register validator rules for <see cref="CreateHelpdeskCatalogRequest"/>
    /// </summary>
         public CreateHelpdeskCatalogValidator()
          {
               WithValidator(MsgCode.ERR_DEFINE_HELPDESK_CATALOG_INVALID);
               RuleFor(x => x.KeyCatalog).NotNull().MaxLength(HelpdeskCatalogConst.KEY_CATALOG_MAX_LENGTH);
               RuleFor(x => x.NameVn).NotNull().MaxLength(HelpdeskCatalogConst.NAME_VN_MAX_LENGTH);
               RuleFor(x => x.Url).MaxLength(HelpdeskCatalogConst.URL_MAX_LENGTH);
               RuleFor(x => x.IsActived).NotNull();
          }
    }
}
