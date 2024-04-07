using RentAndDelivery.Domain.Entities;
using RentAndDelivery.Domain.Interfaces.Input;
using RentAndDelivery.Infrastructure.Context;

namespace RentAndDelivery.Infrastructure.Repositories.Input
{
    public class RentalPlanInputRepository : IRentalPlanInputRepository
    {
        protected readonly AppDbContext db;

        public RentalPlanInputRepository(AppDbContext _db)
        {
            db = _db;
        }

        public async Task<RentalPlan> AddRentalPlan(RentalPlan rentalPlan)
        {
            if (rentalPlan is null)
                throw new ArgumentNullException(nameof(rentalPlan));

            await db.RentalPlans.AddAsync(rentalPlan);
            return rentalPlan;
        }

        public async Task<RentalPlan> DeleteRentalPlan(string rentalPlanId)
        {
            var rentalPlan = await db.RentalPlans.FindAsync(new Guid(rentalPlanId));

            if (rentalPlan is null)
                throw new InvalidOperationException("RentalPlan not found!");

            db.RentalPlans.Remove(rentalPlan);
            return rentalPlan;
        }  

        public void UpdateRentalPlan(RentalPlan rentalPlan)
        {
            if (rentalPlan is null)
                throw new ArgumentNullException(nameof(rentalPlan));

            db.RentalPlans.Update(rentalPlan);
        }
    }
}