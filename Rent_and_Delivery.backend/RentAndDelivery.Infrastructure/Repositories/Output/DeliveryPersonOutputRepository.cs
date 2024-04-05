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

        public Task<DeliveryPerson> GetDeliveryPersonById(string deliveryPersonId)
        {
            throw new NotImplementedException();
        }
    }
}