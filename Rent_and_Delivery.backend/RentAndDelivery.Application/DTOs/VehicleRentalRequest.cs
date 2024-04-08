using MediatR;
using RentAndDelivery.Domain.Entities;
using RentAndDelivery.Domain.Enum;

namespace RentAndDelivery.Application.DTOS
{
    public class VehicleRentalRequest
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? EstimatedEndDate { get; set; }
        public float? TotalAmount { get; set; }
        public Guid DeliveryPersonId { get; set; }
        public Guid MotorcycleId { get; set; }
    }
}