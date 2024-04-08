using Microsoft.EntityFrameworkCore;
using RentAndDelivery.Domain.Entities;
using RentAndDelivery.Domain.Interfaces.Output;
using RentAndDelivery.Infrastructure.Context;

namespace RentAndDelivery.Infrastructure.Repositories.Output
{
    public class RentalPlanOutputRepository : IRentalPlanOutputRepository
    {
        protected readonly AppDbContext db;

        public RentalPlanOutputRepository(AppDbContext _db)
        {
            db = _db;
        }

        public async Task<IEnumerable<RentalPlan>> GetRentalPlans()
        {
            var rentalPlanlist = await db.RentalPlans.ToListAsync();
            return rentalPlanlist ?? Enumerable.Empty<RentalPlan>();
        }

        public async Task<RentalPlan> GetRentalPlanById(string rentalPlanId)
        {
            var rentalPlan = await db.RentalPlans.FindAsync(new Guid(rentalPlanId));

            /*if (rentalPlan is null)
                throw new InvalidOperationException("RentalPlan not found!");*/

            return rentalPlan;
        }
    }
}