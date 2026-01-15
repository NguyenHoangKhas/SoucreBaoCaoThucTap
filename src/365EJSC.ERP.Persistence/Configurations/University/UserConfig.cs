using _365EJSC.ERP.Domain.Constants.University;
using _365EJSC.ERP.Domain.Entities.University;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _365EJSC.ERP.Persistence.Configurations.University
{
    /// <summary>
    /// EF Core configuration for <see cref="User"/>
    /// </summary>
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id");

            builder.Property(x => x.Username)
                .HasColumnName("Username")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.PasswordHash)
                .HasColumnName("PasswordHash")  // ✅ PascalCase
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(x => x.FullName)
                .HasColumnName("FullName")      // ✅ PascalCase
                .HasMaxLength(150);

            builder.Property(x => x.Email)
                .HasColumnName("Email")
                .HasMaxLength(150);

            builder.Property(x => x.Role)
                .HasColumnName("Role")
                .HasMaxLength(50);

            builder.ToTable("User");
        }
    }
}
