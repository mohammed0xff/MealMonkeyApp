using MealMonkey.Domain.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MealMonkey.Infrastructure.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode();
            
            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(50)
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
                .HasDefaultValue(DateTime.Now);

            // relations 
/*            builder.HasOne(u => u.Address)
                .WithMany()
                .HasForeignKey(u => u.AddressId);*/

        }
    }
}
