using MediatR;
using RentAndDelivery.Domain.Entities;
using RentAndDelivery.Domain.Enum;

namespace RentAndDelivery.Application.DTOS
{
    public abstract class OrderRequest
    {
        public float? RaceValue { get; private set; }
        public OrderStatusType? OrderStatusStatus { get; private set; }
        public Guid? DeliveryPersonId { get; set; }
        public DateTime? AcceptedOrderDate { get; set; }
        public DateTime? DeliveredOrderDate { get; set; }
        
    }
}