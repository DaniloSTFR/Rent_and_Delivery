using RentAndDelivery.Domain.Entities;
using RentAndDelivery.Domain.Interfaces.Output;
using RentAndDelivery.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace RentAndDelivery.Infrastructure.Repositories.Output
{
    public class DeliveryPersonOutputRepository : IDeliveryPersonOutputRepository
    {
        protected readonly AppDbContext db;

        public DeliveryPersonOutputRepository(AppDbContext _db)
        {
            db = _db;
        }

        public async Task<DeliveryPerson> GetDeliveryPersonByCNPJ(string cnpj)
        {   
            if (string.IsNullOrEmpty(cnpj))
                throw new InvalidOperationException("CNPJ is null");

            var deliveryPersons = await db.DeliveryPersons
                    .FirstOrDefaultAsync(dp => dp.CNPJ == cnpj);

          /*if (deliveryPersons is null)
                throw new InvalidOperationException("DeliveryPersons not found!");*/
                
            return  deliveryPersons;
        }

        public async Task<DeliveryPerson> GetDeliveryPersonById(string deliveryPersonId)
        {
            var delivery = await db.DeliveryPersons.FindAsync(new Guid(deliveryPersonId));

/*             if (delivery is null)
                throw new InvalidOperationException("Delivery person not found!"); */

            return delivery;
        }

        public async Task<IEnumerable<DeliveryPerson>> GetDeliveryPersons()
        {
            var deliveryPersonlist = await db.DeliveryPersons.ToListAsync();
            return deliveryPersonlist ?? Enumerable.Empty<DeliveryPerson>();
        }
    }
}