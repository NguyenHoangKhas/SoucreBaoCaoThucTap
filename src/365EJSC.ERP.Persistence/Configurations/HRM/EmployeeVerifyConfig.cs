using _365EJSC.ERP.Domain.Constants;
using _365EJSC.ERP.Domain.Constants.HRM;
using _365EJSC.ERP.Domain.Entities.HRM;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _365EJSC.ERP.Persistence.Configurations.HRM
{
    public class EmployeeVerifyConfig : IEntityTypeConfiguration<EmployeeVerify>
    {
        public void Configure(EntityTypeBuilder<EmployeeVerify> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName(EmployeeVerifyConst.FIELD_VERIFY_ID);
            builder.Property(x => x.EmployeeId).HasColumnName(EmployeeVerifyConst.FIELD_EMPLOYEE_ID);
            builder.Property(x => x.VerImage).HasColumnName(EmployeeVerifyConst.FIELD_VER_IMAGE).HasMaxLength(EmployeeVerifyConst.VER_IMAGE_MAX_LENGTH);
            builder.Property(x => x.UserIdVerify).HasColumnName(EmployeeVerifyConst.FIELD_USER_ID_VERIFY);
            builder.Property(x => x.VerCreatedDate).HasColumnName(EmployeeVerifyConst.FIELD_VER_CREATED_DATE);
            builder.Property(x => x.IsActived).HasColumnName(EmployeeVerifyConst.FIELD_IS_ACTIVED);

            //builder.HasOne(x => x.Employee).WithMany().HasForeignKey(x => x.EmployeeId);

            builder.ToTable(TableConst.TABLE_HRM_EMPLOYEE_VERIFY);
        }
    }
}
