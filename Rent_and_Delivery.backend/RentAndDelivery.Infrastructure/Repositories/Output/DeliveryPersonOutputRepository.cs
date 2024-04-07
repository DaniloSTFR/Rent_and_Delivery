using RentAndDelivery.Domain.Entities;
using RentAndDelivery.Domain.Interfaces.Output;
using RentAndDelivery.Infrastructure.Context;


namespace RentAndDelivery.Infrastructure.Repositories.Output
{
    public class DeliveryPersonOutputRepository : IDeliveryPersonOutputRepository
    {
        protected readonly AppDbContext db;

        public DeliveryPersonOutputRepository(AppDbContext _db)
        {
            db = _db;
        }

        public Task<DeliveryPerson> GetDeliveryPersonByCNPJ(string cnpj)
        {
            throw new NotImplementedException();
        }

        public async Task<DeliveryPerson> GetDeliveryPersonById(string deliveryPersonId)
        {
            var delivery = await db.DeliveryPersons.FindAsync(new Guid(deliveryPersonId));

            if (delivery is null)
                throw new InvalidOperationException("Delivery person not found!");

            return delivery;
        }
    }
}