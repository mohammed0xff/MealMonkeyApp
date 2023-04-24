using Microsoft.EntityFrameworkCore;
using EntityFramework.Exceptions.SqlServer;
using MealMonkey.Domain.Entities.AddressEntities;
using MealMonkey.Domain.Entities.CartEntities;
using MealMonkey.Domain.Entities.MealEntities;
using MealMonkey.Domain.Entities.OrderEntities;
using MealMonkey.Domain.Entities.ResturantEntities;
using MealMonkey.Domain.Entities.UserEntities;
using MealMonkey.Infrastructure.Configurations.AddressConfigs;
using MealMonkey.Infrastructure.Configurations.CartConfigs;
using MealMonkey.Infrastructure.Configurations.MealConfigs;
using MealMonkey.Infrastructure.Configurations.OrderConfigs;
using MealMonkey.Infrastructure.Configurations.ResturantConfigs;
using MealMonkey.Infrastructure.Configurations.UserConfigs;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseExceptionProcessor();
    }
    // User
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    
    // Resturant
    public DbSet<Resturant> Resturants { get; set; }
    public DbSet<ResturantPhoneNumber> ResturantsPhoneNumbers { get; set; }

    // Address
    public DbSet<Address> Addresses { get; set; }
    public DbSet<City> Cities { get; set; }

    // Meal
    public DbSet<Meal> Meals { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Offer> Offers { get; set; }
    public DbSet<Serving> Servings { get; set; }
    public DbSet<MealType> MealTypes { get; set; }
    
    // Order
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderStatus> OrderStatuses { get; set; }
    public DbSet<PaymentMethod> PaymentMethods { get; set; }

    // Cart
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Identity 
        base.OnModelCreating(modelBuilder);

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