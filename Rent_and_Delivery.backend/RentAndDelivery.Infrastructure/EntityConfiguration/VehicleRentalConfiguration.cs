using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentAndDelivery.Domain.Entities;

namespace RentAndDelivery.Infrastructure.EntityConfiguration
{
    public class VehicleRentalConfiguration : IEntityTypeConfiguration<VehicleRental>
    {
        public void Configure(EntityTypeBuilder<VehicleRental> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.StartDate).HasConversion(new UtcDateTimeConverter()).IsRequired();
            builder.Property(m => m.EndDate).HasConversion(new UtcDateTimeConverter()).IsRequired();
            builder.Property(m => m.EstimatedEndDate).HasConversion(new UtcDateTimeConverter()).IsRequired();
            builder.Property(m => m.TotalAmount).HasMaxLength(100).IsRequired();
            builder.Property(m => m.DeliveryPersonId).HasMaxLength(100).IsRequired();
            builder.Property(m => m.MotorcycleId).HasMaxLength(100).IsRequired();
            builder.Property(m => m.RentalPlanId).HasMaxLength(100).IsRequired();
            builder.Property(m => m.CreatedOn).HasConversion(new UtcDateTimeConverter()).HasDefaultValueSql("Now()").IsRequired();
        }
    }
}