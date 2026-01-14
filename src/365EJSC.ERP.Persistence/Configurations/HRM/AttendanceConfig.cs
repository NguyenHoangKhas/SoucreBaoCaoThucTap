using _365EJSC.ERP.Domain.Constants;
using _365EJSC.ERP.Domain.Constants.HRM;
using _365EJSC.ERP.Domain.Entities.HRM;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _365EJSC.ERP.Persistence.Configurations.HRM
{
    public class AttendanceConfig : IEntityTypeConfiguration<Attendance>
    {
        public void Configure(EntityTypeBuilder<Attendance> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName(AttendanceConst.FIELD_ID);

            builder.Property(x => x.EmployeeId).HasColumnName(AttendanceConst.FIELD_EMPLOYEE_ID).IsRequired();
            builder.Property(x => x.CheckInTime).HasColumnName(AttendanceConst.FIELD_CHECKIN_TIME);
            builder.Property(x => x.CheckOutTime).HasColumnName(AttendanceConst.FIELD_CHECKOUT_TIME);
            builder.Property(x => x.WorkDate).HasColumnName(AttendanceConst.FIELD_WORK_DATE).IsRequired(false);
            builder.Property(x => x.TotalWorkingMinutes).HasColumnName(AttendanceConst.FIELD_TOTAL_WORKING_MINUTES).IsRequired(false);
            builder.Property(x => x.AttendanceStatus).HasColumnName(AttendanceConst.FIELD_ATTENDANCE_STATUS).IsRequired(false);

            builder.HasOne(x => x.Employee)
                   .WithOne()
                   .HasForeignKey<Attendance>(x => x.EmployeeId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableConst.TABLE_HRM_ATTENDANCE);
        }
    }
}
