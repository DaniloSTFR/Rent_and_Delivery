using RentAndDelivery.Domain.Entities;
using RentAndDelivery.Domain.Interfaces.Output;
using RentAndDelivery.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace RentAndDelivery.Infrastructure.Repositories.Output
{
    public class AdminOutputRepository : IAdminOutputRepository
    {
        protected readonly AppDbContext db;

        public AdminOutputRepository(AppDbContext _db)
        {
            db = _db;
        }

        public async Task<Admin> GetAdminById(string adminId)
        {
            var admin = await db.Admins.FindAsync(new Guid(adminId));

            if (admin is null)
                throw new InvalidOperationException("Admin not found!");

            return admin;
        }

        public Task<Admin> GetAdminByName(string adminId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Admin>> GetAdmins()
        {
            var adminlist = await db.Admins.ToListAsync();
            return adminlist ?? Enumerable.Empty<Admin>();
        }
    }
}