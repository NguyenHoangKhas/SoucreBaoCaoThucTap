using _365EJSC.ERP.Domain.Entities.University;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _365EJSC.ERP.Persistence.Configurations.University
{
    public class LecturerConfig : IEntityTypeConfiguration<Lecturer>
    {
        public void Configure(EntityTypeBuilder<Lecturer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.LecturerCode).HasColumnName("LecturerCode").HasMaxLength(50).IsRequired();
            builder.Property(x => x.FullName).HasColumnName("FullName").HasMaxLength(150);
            builder.Property(x => x.Email).HasColumnName("Email").HasMaxLength(150);
            builder.Property(x => x.Degree).HasColumnName("Degree").HasMaxLength(100);
            builder.Property(x => x.UserId).HasColumnName("UserId").IsRequired();

            builder.HasOne(x => x.UserInfo).WithOne(x => x.LecturerInfo).HasForeignKey<Lecturer>(x => x.UserId);
            builder.HasMany(x => x.LecturerSubjects).WithOne(x => x.LecturerInfo).HasForeignKey(x => x.LecturerId);

            builder.ToTable("Lecturer");
        }
    }
}
