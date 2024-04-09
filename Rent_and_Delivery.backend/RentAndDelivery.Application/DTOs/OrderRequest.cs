using MediatR;
using RentAndDelivery.Domain.Entities;
using RentAndDelivery.Domain.Enum;

namespace RentAndDelivery.Application.DTOS
{
    public abstract class OrderRequest
    {
        public float? RaceValue { get; set; } = 0;
        public OrderStatusType? OrderStatus { get; set; }
        public Guid? DeliveryPersonId { get; set; } = null;
        public DateTime? AcceptedOrderDate { get; set; } = null;
        public DateTime? DeliveredOrderDate { get; set; } = null;
        
    }
}