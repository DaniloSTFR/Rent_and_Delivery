using RentAndDelivery.Domain.Entities;

namespace RentAndDelivery.Domain.Interfaces.Output
{
    public interface IAdminOutputRepository
    {
        Task<IEnumerable<Admin>> GetAdmins();
        Task<Admin> GetAdminById(string adminId);
        Task<Admin> GetAdminByName(string adminName);

    }
}