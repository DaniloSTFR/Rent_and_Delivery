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

        public async Task<Admin> AddAdmin(Admin admin)
        {
            if (admin is null)
                throw new ArgumentNullException(nameof(admin));

            await db.Admins.AddAsync(admin);
            return admin;
        }

        public async Task<Admin> DeleteAdmin(string adminId)
        {
            var admin = await db.Admins.FindAsync(new Guid(adminId));

            if (admin is null)
                throw new InvalidOperationException("Admin not found!");

            db.Admins.Remove(admin);
            return admin;
        }  

        public void UpdateAdmin(Admin admin)
        {
            if (admin is null)
                throw new ArgumentNullException(nameof(admin));

            db.Admins.Update(admin);
        }
    }
}