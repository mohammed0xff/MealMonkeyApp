using MealMonkey.Domain.Entities.CartEntities;
using MealMonkey.Domain.Entities.OrderEntities;
using MealMonkey.Domain.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MealMonkey.Infrastructure.Configurations.CartConfigs
{
    public class CartConfigurations : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            // Relationships with
            // User
            builder.HasOne(c => c.User)
                .WithMany(u => u.Carts)
                .HasForeignKey(c => c.UserId)
                .IsRequired();

            // Order 
            builder.HasOne(c => c.Order)
                .WithOne(o => o.Cart)
                .HasForeignKey<Cart>(m => m.OrderId)
                .IsRequired(false);
        }
    }
}
