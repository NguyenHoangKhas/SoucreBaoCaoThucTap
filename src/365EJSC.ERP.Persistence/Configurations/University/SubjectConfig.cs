using _365EJSC.ERP.Domain.Entities.University;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _365EJSC.ERP.Persistence.Configurations.University
{
    public class SubjectConfig : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.SubjectCode).HasColumnName("SubjectCode").HasMaxLength(50).IsRequired();
            builder.Property(x => x.SubjectName).HasColumnName("SubjectName").HasMaxLength(150).IsRequired();
            builder.Property(x => x.Credits).HasColumnName("Credits").IsRequired();
            builder.Property(x => x.Description).HasColumnName("Description").HasMaxLength(500);
            builder.Property(x => x.PrerequisiteId).HasColumnName("PrerequisiteId");

            builder.HasOne(x => x.PrerequisiteSubject).WithMany(x => x.DependentSubjects).HasForeignKey(x => x.PrerequisiteId);
            builder.HasMany(x => x.CourseRegistrations).WithOne(x => x.SubjectInfo).HasForeignKey(x => x.SubjectId);
            builder.HasMany(x => x.LecturerSubjects).WithOne(x => x.SubjectInfo).HasForeignKey(x => x.SubjectId);
            builder.HasMany(x => x.Grades).WithOne(x => x.SubjectInfo).HasForeignKey(x => x.SubjectId);

            builder.ToTable("Subject");
        }
    }
}