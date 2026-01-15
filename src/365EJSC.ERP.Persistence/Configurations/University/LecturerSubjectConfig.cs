using _365EJSC.ERP.Domain.Entities.University;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _365EJSC.ERP.Persistence.Configurations.University
{
    public class LecturerSubjectConfig : IEntityTypeConfiguration<LecturerSubject>
    {
        public void Configure(EntityTypeBuilder<LecturerSubject> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.LecturerId).HasColumnName("LecturerId").IsRequired();
            builder.Property(x => x.SubjectId).HasColumnName("SubjectId").IsRequired();
            builder.Property(x => x.Semester).HasColumnName("Semester").HasMaxLength(20);
            builder.Property(x => x.AcademicYear).HasColumnName("AcademicYear").HasMaxLength(20);

            builder.HasOne(x => x.LecturerInfo).WithMany(x => x.LecturerSubjects).HasForeignKey(x => x.LecturerId);
            builder.HasOne(x => x.SubjectInfo).WithMany(x => x.LecturerSubjects).HasForeignKey(x => x.SubjectId);

            builder.ToTable("LecturerSubject");
        }
    }
}