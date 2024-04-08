using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentAndDelivery.Domain.Entities;

namespace RentAndDelivery.Infrastructure.EntityConfiguration
{
    public class OrderNotificationConfiguration : IEntityTypeConfiguration<OrderNotification>
    {
        public void Configure(EntityTypeBuilder<OrderNotification> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.OrderId).IsRequired();
            builder.Property(m => m.DeliveryPersonId).IsRequired();
            builder.Property(m => m.CreatedOn).HasConversion(new UtcDateTimeConverter()).HasDefaultValueSql("Now()").IsRequired();
        }
    }
}