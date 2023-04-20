using MealMonkey.Domain.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MealMonkey.Infrastructure.Configurations.UserConfigs
{
    public class NotificationConfigurations : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            // Properties
            builder.Property(n => n.Message)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(n => n.SentDate)
                .IsRequired()
                .HasDefaultValue(DateTime.UtcNow);

            // Relationships
            // User
            builder.HasOne(r => r.User)
                .WithMany(u => u.Notifications)
                .HasForeignKey(r => r.UserId)
                .IsRequired();
        }
    }
}
