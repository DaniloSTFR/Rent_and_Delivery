using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentAndDelivery.Domain.Entities;
using RentAndDelivery.Domain.Enum;

namespace RentAndDelivery.Infrastructure.EntityConfiguration
{
    public class MotorcycleConfiguration : IEntityTypeConfiguration<Motorcycle>
    {
        public void Configure(EntityTypeBuilder<Motorcycle> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Year).IsRequired();
            builder.Property(m => m.Model).HasMaxLength(100).IsRequired();
            builder.HasAlternateKey(c => c.Plate).HasName("UniqueKey_Plate");
            //builder.Property(m => m.Plate).HasMaxLength(100).IsRequired();
            builder.Property(m => m.Status).IsRequired();
            builder.Property(m => m.CreatedOn).HasDefaultValueSql("Now()").IsRequired();
            

            //ValuesDafault to test
            builder.HasData(
                new Motorcycle(new Guid("6c31f522-56b1-4bc2-a8c9-585627c23318"), DateTime.Now.Year - 1, "Factor 125", "OFL0823", MotorcycleStatusType.Available, DateTime.Now)
            );
        }
    }
}