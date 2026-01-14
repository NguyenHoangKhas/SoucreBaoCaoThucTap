using _365EJSC.ERP.Domain.Constants;
using _365EJSC.ERP.Domain.Constants.HRM;
using _365EJSC.ERP.Domain.Entities.HRM;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _365EJSC.ERP.Persistence.Configurations.HRM
{
    /// <summary>
    /// EF Core configuration for <see cref="Bank"/>
    /// </summary>
    public class BankConfig : IEntityTypeConfiguration<Bank>
    {
        public void Configure(EntityTypeBuilder<Bank> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName(BankConst.FIELD_ID);
            builder.Property(x => x.BankName).HasColumnName(BankConst.FIELD_NAME);

            builder.ToTable(TableConst.TABLE_HRM_BANK);
        }
    }
}
