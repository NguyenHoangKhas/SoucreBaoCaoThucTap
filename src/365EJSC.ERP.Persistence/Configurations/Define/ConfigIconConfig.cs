using _365EJSC.ERP.Domain.Constants.Define;
using _365EJSC.ERP.Domain.Entities.Define;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _365EJSC.ERP.Persistence.Configurations.Define
{
    /// <summary>
    /// EF core configuration for <see cref="ConfigIcon"/>
    /// </summary>
    public class ConfigIconConfig : IEntityTypeConfiguration<ConfigIcon>
    {
        public void Configure(EntityTypeBuilder<ConfigIcon> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName(ConfigIconConst.FIELD_KEY_CONFIG_ICON).HasMaxLength(ConfigIconConst.IDX_KEY_MAX_LENGTH);
            builder.Property(x => x.IconDescription).HasColumnName(ConfigIconConst.FIELD_DESCRIPTION).HasMaxLength(ConfigIconConst.DESCRIPTION_MAX_LENGTH);
            builder.Property(x => x.IconUrl).HasColumnName(ConfigIconConst.FIELD_URL).HasMaxLength(ConfigIconConst.URL_MAX_LENGTH);

            builder.ToTable(ConfigIconConst.TABLE_NAME);
        }
    }
}
