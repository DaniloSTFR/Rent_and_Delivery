using RentAndDelivery.Domain.Entities;

namespace RentAndDelivery.Domain.Interfaces.Input
{
    public interface IAdminInputRepository
    {
        Task<Admin> AddAdmin(Admin admin);
        void UpdateAdmin(Admin admin);
        Task<Admin> DeleteAdmin(string adminId);
    }
    
}