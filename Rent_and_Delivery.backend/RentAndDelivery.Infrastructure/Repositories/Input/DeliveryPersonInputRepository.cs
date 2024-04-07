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
        
        public async Task<DeliveryPerson> AddDeliveryPerson(DeliveryPerson deliveryPerson)
        {
            if (deliveryPerson is null)
                throw new ArgumentNullException(nameof(deliveryPerson));

            await db.DeliveryPersons.AddAsync(deliveryPerson);
            return deliveryPerson;
        }

        public async Task<DeliveryPerson> DeleteDeliveryPerson(string deliveryPersonId)
        {
            var deliveryPerson = await db.DeliveryPersons.FindAsync(new Guid(deliveryPersonId));

            if (deliveryPerson is null)
                throw new InvalidOperationException("DeliveryPerson not found!");

            db.DeliveryPersons.Remove(deliveryPerson);
            return deliveryPerson;
        }  

        public void UpdateDeliveryPerson(DeliveryPerson deliveryPerson)
        {
            if (deliveryPerson is null)
                throw new ArgumentNullException(nameof(deliveryPerson));

            db.DeliveryPersons.Update(deliveryPerson);
        }
    }
}