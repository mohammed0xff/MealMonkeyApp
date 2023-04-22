using MealMonkey.Domain.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MealMonkey.Infrastructure.Configurations.UserConfigs
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            
            builder.ToTable(nameof(ApplicationDbContext.Users));
            
            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode();

            builder.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode();

            builder.Property(u => u.PhoneNumber)
                .HasMaxLength(20);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.HashPassword)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(u => u.CreatedAt)
                .IsRequired()
                .HasDefaultValue(DateTime.UtcNow);
        }
    }
}
