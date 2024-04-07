using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentAndDelivery.Domain.Entities;
using RentAndDelivery.Domain.Enum;

namespace RentAndDelivery.Infrastructure.EntityConfiguration
{
    public class DeliveryPersonConfiguration : IEntityTypeConfiguration<DeliveryPerson>
    {
        public void Configure(EntityTypeBuilder<DeliveryPerson> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Name).HasMaxLength(200).IsRequired();
            builder.Property(m => m.CNPJ).HasMaxLength(50).IsRequired();
            builder.Property(m => m.BirthDate).IsRequired();
            builder.Property(m => m.LicenseNumberCNH).HasMaxLength(100).IsRequired();
            builder.Property(m => m.LicenseType).IsRequired();
            builder.Property(m => m.ImageCNH).HasMaxLength(300).IsRequired();
            builder.Property(m => m.CreatedOn).HasDefaultValueSql("Now()").IsRequired();

            //ValuesDafault to test
            builder.HasData(
                new DeliveryPerson(new Guid("15ef9e35-e3af-4a70-826d-88edba8efcc0"), "John Doe Test", "74979006000199", DateTime.Now.AddYears(-20),"30222894101", CNHDriversLicenseType.A, "./images/imageCNH.jpg", DateTime.Now)
            );
        }
    }
}