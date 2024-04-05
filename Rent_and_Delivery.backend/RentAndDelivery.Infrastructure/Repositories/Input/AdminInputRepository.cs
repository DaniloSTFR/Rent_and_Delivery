using RentAndDelivery.Domain.Entities;
using RentAndDelivery.Domain.Interfaces.Input;
using RentAndDelivery.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace RentAndDelivery.Infrastructure.Repositories.Input
{
    public class AdminInputRepository : IAdminInputRepository
    {
        protected readonly AppDbContext db;

        public AdminInputRepository(AppDbContext _db)
        {
            db = _db;
        }

        public Task<Admin> AddAdmin(Admin admin)
        {
            throw new NotImplementedException();
        }

        public Task<Admin> DeleteAdmin(string adminId)
        {
            throw new NotImplementedException();
        }

        public void UpdateAdmin(Admin admin)
        {
            throw new NotImplementedException();
        }
    }
}