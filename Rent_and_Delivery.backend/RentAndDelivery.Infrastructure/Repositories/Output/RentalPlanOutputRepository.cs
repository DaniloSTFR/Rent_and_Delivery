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

        public Task<IEnumerable<RentalPlan>> GetRentalPlan()
        {
            throw new NotImplementedException();
        }

        public Task<RentalPlan> GetRentalPlanById(string rentalPlanId)
        {
            throw new NotImplementedException();
        }
    }
}