using EntityFramework.Exceptions.SqlServer;
using MealMonkey.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

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
        modelBuilder.ApplyConfiguration(new MealConfigurations());
        modelBuilder.ApplyConfiguration(new CategoryConfigurations());
        modelBuilder.ApplyConfiguration(new CityConfigurations());
        modelBuilder.ApplyConfiguration(new AddressConfigurations());
        modelBuilder.ApplyConfiguration(new UserConfigurations());
        modelBuilder.ApplyConfiguration(new CartConfigurations());
        modelBuilder.ApplyConfiguration(new CartItemConfigurations());
        modelBuilder.ApplyConfiguration(new CartItemIngredientConfigurations());
        modelBuilder.ApplyConfiguration(new IngredientConfigurations());
        modelBuilder.ApplyConfiguration(new OrderConfigurations());
        modelBuilder.ApplyConfiguration(new OrderItemConfigurations());
        modelBuilder.ApplyConfiguration(new OrderItemIngredientConfigurations());
        modelBuilder.ApplyConfiguration(new ReviewConfigurations());
        modelBuilder.ApplyConfiguration(new PaymentMethodConfigurations());
        modelBuilder.ApplyConfiguration(new ResturantConfigurations());

    }
    
}