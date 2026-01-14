using _365EJSC.ERP.Domain.Constants;
using _365EJSC.ERP.Domain.Constants.HRM;
using _365EJSC.ERP.Domain.Entities.HRM;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _365EJSC.ERP.Persistence.Configurations.HRM
{
    public class EmployeeCompanyConfig : IEntityTypeConfiguration<EmployeeCompany>
    {
        public void Configure(EntityTypeBuilder<EmployeeCompany> builder)
        {
            builder.ToTable(TableConst.TABLE_HRM_EMPLOYEE_COMPANY);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName(EmployeeCompanyConst.FIELD_ID);

            builder.Property(x => x.EmployeeId)
                .HasColumnName(EmployeeCompanyConst.FIELD_EMPLOYEE_ID);

            builder.Property(x => x.CdId)
                .HasColumnName(EmployeeCompanyConst.FIELD_CD_ID);
            builder.HasOne(x => x.Employee).WithMany().HasForeignKey(x => x.EmployeeId);
        }
    }
}
