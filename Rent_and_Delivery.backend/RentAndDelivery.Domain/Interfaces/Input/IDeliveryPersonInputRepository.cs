using RentAndDelivery.Domain.Entities;

namespace RentAndDelivery.Domain.Interfaces.Input
{
    public interface IDeliveryPersonInputRepository
    {
        Task<DeliveryPerson> AddDeliveryPerson(DeliveryPerson deliveryPerson);
        void UpdateDeliveryPerson(DeliveryPerson deliveryPerson);
        Task<DeliveryPerson> DeleteDeliveryPerson(string deliveryPersonId);
    }
}