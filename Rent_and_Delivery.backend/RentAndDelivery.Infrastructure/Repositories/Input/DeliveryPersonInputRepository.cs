using RentAndDelivery.Domain.Entities;
using RentAndDelivery.Domain.Interfaces.Input;
using RentAndDelivery.Infrastructure.Context;

namespace RentAndDelivery.Infrastructure.Repositories.Input
{
    public class DeliveryPersonInputRepository : IDeliveryPersonInputRepository
    {
        protected readonly AppDbContext db;

        public DeliveryPersonInputRepository(AppDbContext _db)
        {
            db = _db;
        }
        
        public Task<DeliveryPerson> AddDeliveryPerson(DeliveryPerson deliveryPerson)
        {
            throw new NotImplementedException();
        }

        public Task<DeliveryPerson> DeleteDeliveryPerson(string deliveryPersonId)
        {
            throw new NotImplementedException();
        }

        public void UpdateDeliveryPerson(DeliveryPerson deliveryPerson)
        {
            throw new NotImplementedException();
        }
    }
}