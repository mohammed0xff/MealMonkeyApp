using MealMonkey.Domain.Entities.CartEntities;
using MealMonkey.Domain.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MealMonkey.Infrastructure.Configurations
{
    public class CartConfigurations : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            // Relationships with
            // user
            builder.HasOne<User>(chart => chart.User)
                .WithMany(user => user.Carts)
                .HasForeignKey(chart => chart.UserId)
                .IsRequired();
        }
    }
}
