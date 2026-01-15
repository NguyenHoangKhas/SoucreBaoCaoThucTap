using _365EJSC.ERP.Domain.Entities.University;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _365EJSC.ERP.Persistence.Configurations.University
{
    public class CourseRegistrationConfig : IEntityTypeConfiguration<CourseRegistration>
    {
        public void Configure(EntityTypeBuilder<CourseRegistration> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.StudentId).HasColumnName("StudentId").IsRequired();
            builder.Property(x => x.SubjectId).HasColumnName("SubjectId").IsRequired();
            builder.Property(x => x.Semester).HasColumnName("Semester").HasMaxLength(20);
            builder.Property(x => x.AcademicYear).HasColumnName("AcademicYear").HasMaxLength(20);
            builder.Property(x => x.Status).HasColumnName("Status").HasMaxLength(20);
            builder.Property(x => x.RegistrationDate).HasColumnName("RegistrationDate");

            builder.HasOne(x => x.StudentInfo).WithMany(x => x.CourseRegistrations).HasForeignKey(x => x.StudentId);
            builder.HasOne(x => x.SubjectInfo).WithMany(x => x.CourseRegistrations).HasForeignKey(x => x.SubjectId);

            builder.ToTable("CourseRegistration");
        }
    }
}
