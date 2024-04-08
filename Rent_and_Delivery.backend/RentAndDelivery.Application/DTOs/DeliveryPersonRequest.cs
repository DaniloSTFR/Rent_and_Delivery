using MediatR;
using RentAndDelivery.Domain.Entities;
using RentAndDelivery.Domain.Enum;


namespace RentAndDelivery.Application.DTOS
{
    public class DeliveryPersonRequest
    {
        public string? Name { get; set; }
        public string? CNPJ { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? LicenseNumberCNH { get; set; }
        public CNHDriversLicenseType? LicenseType { get; set; }
        public string? ImageCNH { get; set; }

    }
}