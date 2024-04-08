using MediatR;
using RentAndDelivery.Domain.Entities;

namespace RentAndDelivery.Application.DTOS
{
    public abstract class RentalPlanRequest
    {
        public string? PlanName { get; set; }
        public int? PlanDays { get; set; }
        public float? CostPerDay { get; set; }
        public float? FineInPercentage { get; set; }
        public float? AdditionalValuePerDay { get; set; }
        
    }
}