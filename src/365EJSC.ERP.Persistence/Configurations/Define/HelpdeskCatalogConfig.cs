using _365EJSC.ERP.Domain.Constants;
using _365EJSC.ERP.Domain.Constants.Define;
using _365EJSC.ERP.Domain.Entities.Define;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _365EJSC.ERP.Persistence.Configurations
{
    public class HelpdeskCatalogConfiguration : IEntityTypeConfiguration<HelpdeskCatalog>
    {
        public void Configure(EntityTypeBuilder<HelpdeskCatalog> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName(HelpdeskCatalogConst.FIELD_ID);
            builder.Property(x => x.KeyCatalog).HasColumnName(HelpdeskCatalogConst.FIELD_KEY_CATALOG);
            builder.Property(x => x.NameVn).HasColumnName(HelpdeskCatalogConst.FIELD_NAME_VN);
            builder.Property(x => x.Url).HasColumnName(HelpdeskCatalogConst.FIELD_URL);
            builder.Property(x => x.IsActived).HasColumnName(HelpdeskCatalogConst.FIELD_IS_ACTIVED);
            builder.ToTable(TableConst.TABLE_HELPDESK_CATALOG);
        }
    }
}
