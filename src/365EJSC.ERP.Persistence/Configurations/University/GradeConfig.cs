using _365EJSC.ERP.Domain.Entities.University;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _365EJSC.ERP.Persistence.Configurations.University
{
    public class GradeConfig : IEntityTypeConfiguration<Grade>
    {
        public void Configure(EntityTypeBuilder<Grade> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.StudentId).HasColumnName("StudentId").IsRequired();
            builder.Property(x => x.SubjectId).HasColumnName("SubjectId").IsRequired();
            builder.Property(x => x.Semester).HasColumnName("Semester").HasMaxLength(20);
            builder.Property(x => x.AcademicYear).HasColumnName("AcademicYear").HasMaxLength(20);
            builder.Property(x => x.ProcessScore).HasColumnName("ProcessScore");
            builder.Property(x => x.MidtermScore).HasColumnName("MidtermScore");
            builder.Property(x => x.FinalScore).HasColumnName("FinalScore");
            builder.Property(x => x.TotalScore).HasColumnName("TotalScore");
            builder.Property(x => x.LetterGrade).HasColumnName("LetterGrade").HasMaxLength(5);

            builder.HasOne(x => x.StudentInfo).WithMany(s => s.Grades).HasForeignKey(x => x.StudentId);
            builder.HasOne(x => x.SubjectInfo).WithMany(s => s.Grades).HasForeignKey(x => x.SubjectId);

            builder.ToTable("Grade");
        }
    }
}