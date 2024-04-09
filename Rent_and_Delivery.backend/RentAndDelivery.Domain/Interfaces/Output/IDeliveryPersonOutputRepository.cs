using RentAndDelivery.Domain.Entities;

namespace RentAndDelivery.Domain.Interfaces.Output
{
    public interface IDeliveryPersonOutputRepository
    {
        Task<IEnumerable<DeliveryPerson>> GetDeliveryPersons();
        Task<DeliveryPerson> GetDeliveryPersonById(string deliveryPersonId);
        Task<DeliveryPerson> GetDeliveryPersonByCNPJ(string cnpj);

    }
}