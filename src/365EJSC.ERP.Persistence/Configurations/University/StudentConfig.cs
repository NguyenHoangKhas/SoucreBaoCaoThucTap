using _365EJSC.ERP.Domain.Entities.University;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _365EJSC.ERP.Persistence.Configurations.University
{
    public class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.StudentCode).HasColumnName("StudentCode").HasMaxLength(50).IsRequired();
            builder.Property(x => x.FullName).HasColumnName("FullName").HasMaxLength(150);
            builder.Property(x => x.Email).HasColumnName("Email").HasMaxLength(150);
            builder.Property(x => x.PhoneNumber).HasColumnName("PhoneNumber").HasMaxLength(20);
            builder.Property(x => x.UserId).HasColumnName("UserId").IsRequired();
            builder.Property(x => x.ClassId).HasColumnName("ClassId");

            builder.HasOne(x => x.UserInfo).WithOne(x => x.StudentInfo).HasForeignKey<Student>(x => x.UserId);
            builder.HasOne(x => x.ClassInfo).WithMany(x => x.Students).HasForeignKey(x => x.ClassId);
            builder.HasMany(x => x.Grades).WithOne(x => x.StudentInfo).HasForeignKey(x => x.StudentId);
            builder.HasMany(x => x.CourseRegistrations).WithOne(x => x.StudentInfo).HasForeignKey(x => x.StudentId);

            builder.ToTable("Student");
        }
    }
}