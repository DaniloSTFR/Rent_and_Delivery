using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentAndDelivery.Domain.Entities;
using RentAndDelivery.Domain.Enum;

namespace RentAndDelivery.Infrastructure.EntityConfiguration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.RaceValue).IsRequired();
            builder.Property(m => m.OrderStatusStatus).IsRequired();
            builder.Property(m => m.CreatedOn).HasDefaultValueSql("Now()").IsRequired();
            builder.Property(m => m.DeliveryPersonId);
            builder.Property(m => m.AcceptedOrderDate);
            builder.Property(m => m.DeliveredOrderDate);

/*             builder.HasMany(e => e.DeliveryPersons)
                .WithMany(e => e.Orders)
                .UsingEntity<OrderNotification>(
                    l => l.HasOne<DeliveryPerson>().WithMany().HasForeignKey(e => e.DeliveryPersonId),
                    r => r.HasOne<Order>().WithMany().HasForeignKey(e => e.OrderId)); */

            //ValuesDafault to test
            builder.HasData(
                new Order(new Guid("814270d0-e6f8-4b95-b1c8-c74ba38e0381"), 50, OrderStatusType.Available, DateTime.Now)
            );
        }

        
    }
}