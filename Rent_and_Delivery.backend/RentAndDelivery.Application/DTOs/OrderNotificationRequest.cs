using MediatR;
using RentAndDelivery.Domain.Entities;
using RentAndDelivery.Domain.Enum;

namespace RentAndDelivery.Application.DTOS
{
    public abstract class OrderNotificationRequest
    {
        public Guid DeliveryPersonId { get; private set; }
        public Guid OrderId { get; private set; }
        
    }
}