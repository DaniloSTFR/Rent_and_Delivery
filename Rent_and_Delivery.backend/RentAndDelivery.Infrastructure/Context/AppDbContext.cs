using Microsoft.EntityFrameworkCore;
using RentAndDelivery.Domain.Entities;
using RentAndDelivery.Infrastructure.EntityConfiguration;

namespace RentAndDelivery.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<DeliveryPerson> DeliveryPersons { get; set; }
        public DbSet<Motorcycle> Motorcycles { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderNotification> OrderNotifications { get; set; }
        public DbSet<RentalPlan> RentalPlans { get; set; }
        public DbSet<VehicleRental> VehiclesRentals { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AdminConfiguration());
            builder.ApplyConfiguration(new DeliveryPersonConfiguration());
            builder.ApplyConfiguration(new MotorcycleConfiguration());
            builder.ApplyConfiguration(new OrderConfiguration());
            builder.ApplyConfiguration(new OrderNotificationConfiguration());
            builder.ApplyConfiguration(new RentalPlanConfiguration());
            builder.ApplyConfiguration(new VehicleRentalConfiguration());

            builder.Entity<DeliveryPerson>()
                .HasMany(e => e.Orders)
                .WithOne(e => e.DeliveryPerson)
                .HasForeignKey(e => e.DeliveryPersonId)
                .IsRequired(false); 

            builder.Entity<Motorcycle>()
                .HasMany(e => e.DeliveryPersons)
                .WithMany(e => e.Motorcycles)
                .UsingEntity<VehicleRental>();

/*             builder.Entity<Order>()
                .HasMany(e => e.DeliveryPersons)
                .WithMany(e => e.Orders)
                .UsingEntity<OrderNotification>(); */

        }

    }
}