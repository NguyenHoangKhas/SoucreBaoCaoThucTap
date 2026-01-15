using _365EJSC.ERP.Domain.Entities.University;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _365EJSC.ERP.Persistence.Configurations.University
{
    public class ClassConfig : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.ClassCode).HasColumnName("ClassCode").HasMaxLength(50).IsRequired();
            builder.Property(x => x.ClassName).HasColumnName("ClassName").HasMaxLength(150);
            builder.Property(x => x.AcademicYear).HasColumnName("AcademicYear").HasMaxLength(20);
            builder.Property(x => x.Department).HasColumnName("Department").HasMaxLength(100);
            builder.Property(x => x.AdvisorId).HasColumnName("AdvisorId");

            builder.HasOne(x => x.AdvisorInfo).WithMany().HasForeignKey(x => x.AdvisorId);
            builder.HasMany(x => x.Students).WithOne(x => x.ClassInfo).HasForeignKey(x => x.ClassId);

            builder.ToTable("Class");
        }
    }
}
