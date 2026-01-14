using _365EJSC.ERP.Domain.Constants;
using _365EJSC.ERP.Domain.Constants.HRM;
using _365EJSC.ERP.Domain.Entities.HRM;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _365EJSC.ERP.Persistence.Configurations.HRM
{
    public class ContractTypeConfig : IEntityTypeConfiguration<DefineContractTypes>
    {
        public void Configure(EntityTypeBuilder<DefineContractTypes> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName(ContractTypeConst.FIELD_ID);
            builder.Property(x => x.ContractTypeCode).HasColumnName(ContractTypeConst.FIELD_CODE).HasMaxLength(ContractTypeConst.CODE_MAX_LENGTH);
            builder.Property(x => x.ContractTypeName).HasColumnName(ContractTypeConst.FIELD_NAME).HasMaxLength(ContractTypeConst.NAME_MAX_LENGTH);

            builder.ToTable(TableConst.TABLE_HRM_DEFINE_CONTRACT_TYPE);
        }
    }
}
