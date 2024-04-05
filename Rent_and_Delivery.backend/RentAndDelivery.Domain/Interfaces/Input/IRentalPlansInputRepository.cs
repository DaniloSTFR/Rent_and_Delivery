

using RentAndDelivery.Domain.Entities;

namespace RentAndDelivery.Domain.Interfaces.Input
{
    public interface IRentalPlanInputRepository
    {
        Task<RentalPlan> AddRentalPlan(RentalPlan rentalPlan);
        void UpdateRentalPlan(RentalPlan rentalPlan);
        Task<RentalPlan> DeleteRentalPlan(string rentalPlanId);
    }
}