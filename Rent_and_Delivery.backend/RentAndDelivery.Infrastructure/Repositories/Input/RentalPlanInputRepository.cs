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

        public Task<RentalPlan> AddRentalPlan(RentalPlan rentalPlan)
        {
            throw new NotImplementedException();
        }

        public Task<RentalPlan> DeleteRentalPlan(string rentalPlanId)
        {
            throw new NotImplementedException();
        }

        public void UpdateRentalPlan(RentalPlan rentalPlan)
        {
            throw new NotImplementedException();
        }
    }
}