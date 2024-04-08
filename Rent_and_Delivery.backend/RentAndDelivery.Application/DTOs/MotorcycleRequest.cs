using MediatR;
using RentAndDelivery.Domain.Entities;
using RentAndDelivery.Domain.Enum;

namespace RentAndDelivery.Application.DTOS
{
    public abstract class MotorcycleRequest
    {
        public int? Year { get; set; }
        public string? Model { get; set; }
        public string? Plate  { get; set; }
        public MotorcycleStatusType? Status { get; set; }
    }
}