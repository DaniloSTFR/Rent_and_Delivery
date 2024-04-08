using System.Text.Json.Serialization;
using RentAndDelivery.Domain.Validation;

namespace RentAndDelivery.Domain.Entities
{
    public class RentalPlan : BaseEntity
    {
        #region  External Props
        public string? PlanName { get; private set; }
        public int? PlanDays { get; private set; }
        public float? CostPerDay { get; private set; }
        public float? FineInPercentage { get; private set; }
        public float? AdditionalValuePerDay { get; private set; }
        #endregion 

        public RentalPlan()
        {}

        public RentalPlan(string planName, int planDays, float costPerDay, float fineInPercentage, float additionalValuePerDay)
        {
            Id = SGVG.Next(null);
            CreatedOn = DateTime.Now;
            ValidateDomain(planName, planDays, costPerDay, fineInPercentage, additionalValuePerDay);
        }

        [JsonConstructor]
        public RentalPlan(Guid id, string planName, int planDays, float costPerDay, float fineInPercentage, float additionalValuePerDay, DateTime createdOn)
        {
            DomainValidation.When(string.IsNullOrEmpty(id.ToString()), "Invalid Id value.");
            Id = id;
            CreatedOn = createdOn;
            ValidateDomain(planName, planDays, costPerDay, fineInPercentage, additionalValuePerDay);
        }


        public void Update(string planName, int planDays, float costPerDay, float fineInPercentage, float additionalValuePerDay)
        {
            ValidateDomain(planName, planDays, costPerDay, fineInPercentage, additionalValuePerDay);
        }

        private void ValidateDomain(string planName, int planDays, float costPerDay, float fineInPercentage, float additionalValuePerDay)
        {
            DomainValidation.When(string.IsNullOrEmpty(planName),
                "Invalid Plan Name. Plan Name is required!");

            DomainValidation.When(planDays <= 0 ,
                "Invalid Plan Days. Plan Days must be greater than zero!");

            DomainValidation.When(costPerDay < 0,
                "Invalid model. Cost per day must be greater than zero!");

            DomainValidation.When(fineInPercentage < 0,
                "Invalid fines. Fine must be greater than zero!");

            DomainValidation.When(additionalValuePerDay < 0,
                "Additional value per day is Invalid. Additional value per day must be greater than zero!");

            PlanName = planName;
            PlanDays = planDays;
            CostPerDay = costPerDay;
            FineInPercentage = fineInPercentage;
            AdditionalValuePerDay = additionalValuePerDay;
        }
    }
}