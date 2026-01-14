using _365EJSC.ERP.Application.Requests.Define.HelpdeskCatalog;
using _365EJSC.ERP.Contract.DependencyInjection.Extensions;
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Validators;
using _365EJSC.ERP.Domain.Constants.Define;

namespace _365EJSC.ERP.Application.Validators.Define.HelpdeskCatalog
{
    /// <summary>
    /// Validator for <see cref="UpdateHelpdeskCatalogRequest"/>
    /// </summary>
    public class UpdateHelpdeskCatalogValidator : Validator<UpdateHelpdeskCatalogRequest>
    {
    /// <summary>
    /// Constructor of <see cref="UpdateHelpdeskCatalogValidator"/>, register validator rules for <see cref="UpdateHelpdeskCatalogRequest"/>
    /// </summary>
         public UpdateHelpdeskCatalogValidator()
          {
               WithValidator(MsgCode.ERR_DEFINE_HELPDESK_CATALOG_INVALID);
               RuleFor(x => x.Id).NotNull().GreaterThan(0);
               RuleFor(x => x.KeyCatalog).MaxLength(HelpdeskCatalogConst.KEY_CATALOG_MAX_LENGTH);
               RuleFor(x => x.NameVn).MaxLength(HelpdeskCatalogConst.NAME_VN_MAX_LENGTH);
               RuleFor(x => x.Url).MaxLength(HelpdeskCatalogConst.URL_MAX_LENGTH);
               RuleFor(x => x.IsActived);
          }
    }
}
