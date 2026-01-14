using _365EJSC.ERP.Domain.Constants;
using _365EJSC.ERP.Domain.Constants.Define;
using _365EJSC.ERP.Domain.Entities.Define;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _365EJSC.ERP.Persistence.Configurations
{
    public class HelpdeskContentConfiguration : IEntityTypeConfiguration<HelpdeskContent>
    {
        public void Configure(EntityTypeBuilder<HelpdeskContent> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName(HelpdeskContentConst.FIELD_ID);
            builder.Property(x => x.ContentDetail).HasColumnName(HelpdeskContentConst.FIELD_CONTENT_DETAIL);
            builder.Property(x => x.CatalogId).HasColumnName(HelpdeskContentConst.FIELD_CATALOG_ID);
            builder.ToTable(TableConst.TABLE_HELPDESK_CONTENT);
            builder.HasOne(x => x.Catalog)          // HelpdeskContent có 1 Catalog
       .WithMany(c => c.Contents)       // Catalog có nhi?u Content
       .HasForeignKey(x => x.CatalogId); // FK tr? v? CatalogId


        }
    }
}
