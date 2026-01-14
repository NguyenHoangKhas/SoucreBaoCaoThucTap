using _365EJSC.ERP.Domain.Constants;
using _365EJSC.ERP.Domain.Constants.HRM;
using _365EJSC.ERP.Domain.Entities.HRM;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _365EJSC.ERP.Persistence.Configurations.HRM
{
    /// <summary>
    /// EF Core configuration for <see cref="EmployeeRole"/>
    /// </summary>
    public class EmployeeRoleConfig : IEntityTypeConfiguration<EmployeeRole>
    {
        public void Configure(EntityTypeBuilder<EmployeeRole> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName(EmployeeRoleConst.FIELD_ID);
            builder.Property(x => x.EmpRoleName).HasColumnName(EmployeeRoleConst.FIELD_NAME);
            builder.Property(x => x.EmpRoleCode).HasColumnName(EmployeeRoleConst.FIELD_CODE);

            builder.ToTable(TableConst.TABLE_HRM_EMPLOYEE_ROLE);
        }
    }
}
