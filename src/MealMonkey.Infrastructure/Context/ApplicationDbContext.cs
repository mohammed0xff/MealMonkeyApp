using EntityFramework.Exceptions.SqlServer;
using MealMonkey.Infrastructure.Configurations.AddressConfigs;
using MealMonkey.Infrastructure.Configurations.CartConfigs;
using MealMonkey.Infrastructure.Configurations.MealConfigs;
using MealMonkey.Infrastructure.Configurations.OrderConfigs;
using MealMonkey.Infrastructure.Configurations.ResturantConfigs;
using MealMonkey.Infrastructure.Configurations.UserConfigs;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseExceptionProcessor();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Address
        modelBuilder.ApplyConfiguration(new AddressConfigurations());
        modelBuilder.ApplyConfiguration(new CityConfigurations());

        // Cart
        modelBuilder.ApplyConfiguration(new CartConfigurations());
        modelBuilder.ApplyConfiguration(new CartItemConfigurations());

        // Meal 
        modelBuilder.ApplyConfiguration(new CategoryConfigurations());
        modelBuilder.ApplyConfiguration(new MealConfigurations());
        modelBuilder.ApplyConfiguration(new MealsOffersConfigurations());
        modelBuilder.ApplyConfiguration(new MealTypeConfigurations());
        modelBuilder.ApplyConfiguration(new ServingConfigurations());
        modelBuilder.ApplyConfiguration(new OfferConfigurations());

        // Order
        modelBuilder.ApplyConfiguration(new OrderConfigurations());
        modelBuilder.ApplyConfiguration(new OrderStatusConfigurations());
        modelBuilder.ApplyConfiguration(new PaymentMethodConfigurations());

        // Resturant
        modelBuilder.ApplyConfiguration(new ResturantConfigurations());
        modelBuilder.ApplyConfiguration(new ResturantPhoneNumberConfigurations());

        // User
        modelBuilder.ApplyConfiguration(new UserConfigurations());
        modelBuilder.ApplyConfiguration(new ReviewConfigurations());
        modelBuilder.ApplyConfiguration(new NotificationConfigurations());
    }
}