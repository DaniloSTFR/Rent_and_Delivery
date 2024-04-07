using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentAndDelivery.Domain.Entities;

namespace RentAndDelivery.Infrastructure.EntityConfiguration
{
    public class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Name).HasMaxLength(100).IsRequired();
            builder.Property(m => m.CreatedOn).HasDefaultValueSql("Now()").IsRequired();

            //ValuesDafault to test
            builder.HasData(
                new Admin(new Guid("4FAA9CAB-F205-40CB-5953-08DC489CFB2D"), "Admin", DateTime.Now)
            );
        }
    }
}