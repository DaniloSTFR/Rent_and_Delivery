using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentAndDelivery.Domain.Entities;

namespace RentAndDelivery.Infrastructure.EntityConfiguration
{
    public class RentalPlanConfiguration : IEntityTypeConfiguration<RentalPlan>
    {
        public void Configure(EntityTypeBuilder<RentalPlan> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.PlanName).HasMaxLength(100).IsRequired();
            builder.Property(m => m.PlanDays).IsRequired();
            builder.Property(m => m.CostPerDay).IsRequired();
            builder.Property(m => m.FineInPercentage).IsRequired();
            builder.Property(m => m.AdditionalValuePerDay).IsRequired();
            builder.Property(m => m.CreatedOn).HasDefaultValueSql("Now()").IsRequired();

            //Set ValuesDafault to test
            builder.HasData(
                new RentalPlan(new Guid("3531a2ac-015f-4b7e-95b6-8f6e54a040bb"), "7_Days", 7, 30, 20, 50, DateTime.Now),
                new RentalPlan(new Guid("54b78006-d2c0-4041-ad81-5e88b84142c0"), "15_Days", 15, 28, 40, 50, DateTime.Now),
                new RentalPlan(new Guid("5b17845c-d0a7-4a84-b380-a0ac18382b5a"), "30_Days", 30, 22, 60, 50, DateTime.Now)
            );
        }
    }
}