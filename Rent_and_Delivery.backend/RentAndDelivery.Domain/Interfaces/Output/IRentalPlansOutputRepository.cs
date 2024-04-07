

using RentAndDelivery.Domain.Entities;

namespace RentAndDelivery.Domain.Interfaces.Output
{
    public interface IRentalPlanOutputRepository
    {
        Task<RentalPlan> GetRentalPlanById(string rentalPlanId);
        Task<IEnumerable<RentalPlan>> GetRentalPlans();
    }
}