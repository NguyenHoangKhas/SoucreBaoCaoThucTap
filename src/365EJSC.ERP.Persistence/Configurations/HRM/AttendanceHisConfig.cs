using _365EJSC.ERP.Domain.Constants;
using _365EJSC.ERP.Domain.Entities.HRM;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _365EJSC.ERP.Persistence.Configurations.HRM
{
    public class AttendanceHisConfig : IEntityTypeConfiguration<AttendanceHis>
    {
        public void Configure(EntityTypeBuilder<AttendanceHis> builder)
        {
            builder.ToTable(TableConst.TABLE_HRM_ATTENDANCE_HIS);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("attendance_id_his").ValueGeneratedOnAdd();
            builder.Property(x => x.AttendanceId).HasColumnName("attendance_id").IsRequired();
            builder.HasOne(x => x.AttendanceInfo).WithMany().HasForeignKey(x => x.AttendanceId).OnDelete(DeleteBehavior.Cascade);
            builder.Property(x => x.CheckInTime).HasColumnName("check_in_time").IsRequired(false);
            builder.Property(x => x.CheckOutTime).HasColumnName("check_out_time").IsRequired(false);
            builder.Property(x => x.NumLate).HasColumnName("num_late").IsRequired(false);
            builder.Property(x => x.NumEarlyLeave).HasColumnName("num_early_leave").IsRequired(false);
            builder.Property(x => x.WorkingMinutes).HasColumnName("working_minutes").IsRequired(false);
            builder.Property(x => x.IsActived).HasColumnName("is_actived").HasDefaultValue(0).IsRequired();
            builder.HasIndex(x => x.AttendanceId).HasDatabaseName("IX_hrm_attendance_his_attendance_id");
        }
    }
}
