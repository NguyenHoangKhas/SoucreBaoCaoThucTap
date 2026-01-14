using _365EJSC.ERP.Domain.Constants;
using _365EJSC.ERP.Domain.Constants.Define;
using _365EJSC.ERP.Domain.Entities.Define;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _365EJSC.ERP.Persistence.Configurations.Define
{
    public class WebLocalWardsV2Configuration : IEntityTypeConfiguration<WebLocalWardsV2>
    {
        public void Configure(EntityTypeBuilder<WebLocalWardsV2> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName(WebLocalWardsV2Const.FIELD_ID);
            builder.Property(x => x.Name).HasColumnName(WebLocalWardsV2Const.FIELD_NAME);
            builder.Property(x => x.NameEn).HasColumnName(WebLocalWardsV2Const.FIELD_NAME_EN);
            builder.Property(x => x.FullName).HasColumnName(WebLocalWardsV2Const.FIELD_FULL_NAME);
            builder.Property(x => x.FullNameEn).HasColumnName(WebLocalWardsV2Const.FIELD_FULL_NAME_EN);
            builder.Property(x => x.Latitude).HasColumnName(WebLocalWardsV2Const.FIELD_LATITUDE);
            builder.Property(x => x.Longitude).HasColumnName(WebLocalWardsV2Const.FIELD_LONGITUDE);
            builder.Property(x => x.WardPid).HasColumnName(WebLocalWardsV2Const.FIELD_WARD_PID);
            builder.Property(x => x.KeyLocalization).HasColumnName(WebLocalWardsV2Const.FIELD_KEY_LOCALIZATION);
            builder.ToTable(TableConst.TABLE_WEBSITE_LOCALIZATION_WARD_V2);

            builder.HasMany(w => w.ChildWards).WithOne().HasForeignKey(w => w.WardPid);


        }
    }
}
