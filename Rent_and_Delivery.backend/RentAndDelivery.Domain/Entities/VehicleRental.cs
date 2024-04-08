
using System.Text.Json.Serialization;
using RentAndDelivery.Domain.Enum;
using RentAndDelivery.Domain.Validation;

namespace RentAndDelivery.Domain.Entities
{
    public class VehicleRental : BaseEntity
    {
        #region  External Props
        public DateTime? StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }
        public DateTime? EstimatedEndDate { get; private set; }
        public float? TotalAmount { get; set; }

        public Guid DeliveryPersonId { get; private set; }
        public DeliveryPerson? DeliveryPerson { get; private set; }

        public Guid MotorcycleId { get; private set; }
        public Motorcycle? Motorcycle { get; private set; }

        public Guid RentalPlanId { get; private set; }
        public RentalPlan? RentalPlan { get; private set; }

        #endregion

        public VehicleRental(){}

        public VehicleRental(DateTime startDate, DateTime endDate, DateTime estimatedEndDate, float totalAmount, DeliveryPerson deliveryPerson, Motorcycle motorcycle, RentalPlan? rentalPlan)
        {
            Id = SGVG.Next(null);
            CreatedOn = DateTime.Now;
            ValidateDomain(startDate, endDate, estimatedEndDate, totalAmount, deliveryPerson, motorcycle, rentalPlan);
        }

        [JsonConstructor]
        public VehicleRental(Guid id, DateTime startDate, DateTime endDate, DateTime estimatedEndDate, float totalAmount, DeliveryPerson deliveryPerson, Motorcycle motorcycle,RentalPlan? rentalPlan, DateTime createdOn)
        {
            DomainValidation.When(string.IsNullOrEmpty(id.ToString()), "Invalid Id value.");
            Id = id;
            CreatedOn = createdOn;
            ValidateDomain(startDate, endDate, estimatedEndDate, totalAmount, deliveryPerson, motorcycle, rentalPlan);
        }

        public void Update(DateTime startDate, DateTime endDate, DateTime estimatedEndDate, float totalAmount, DeliveryPerson deliveryPerson, Motorcycle motorcycle, RentalPlan? rentalPlan)
        {
            ValidateDomain(startDate, endDate, estimatedEndDate, totalAmount, deliveryPerson, motorcycle, rentalPlan);
        }

        private void ValidateDomain(DateTime startDate, DateTime endDate, DateTime estimatedEndDate, float totalAmount, DeliveryPerson deliveryPerson, Motorcycle motorcycle, RentalPlan? rentalPlan)
        {
            DomainValidation.When(endDate <= startDate,
                "The rental end date cannot be equals or less than the start date!");

            DomainValidation.When(estimatedEndDate < DateTime.Now.AddDays(2),
                "The rental end estimated End Date cannot be equal or less than the start date!");

            DomainValidation.When(totalAmount < 0,
                "The total amount does not have a valid value!");

            DomainValidation.When(deliveryPerson is null,
                "DeliveryPerson is Invalid. DeliveryPerson is required");

            DomainValidation.When(!(deliveryPerson.LicenseType.Equals(CNHDriversLicenseType.A) ||
                    deliveryPerson.LicenseType.Equals(CNHDriversLicenseType.AandB)),
                "Delivery person does not have a valid type of license. The license type must be A or A and B!");

            DomainValidation.When(motorcycle is null,
                "Motorcycle is Invalid. Motorcycle is required!");

            DomainValidation.When(!motorcycle.Status.Equals(MotorcycleStatusType.Available),
                "The motorcycle is not available for rent. An available motorcycle is required!");

            DomainValidation.When(rentalPlan is null,
                "RentalPlan is Invalid. RentalPlan is required!");

            StartDate = startDate;
            EndDate = endDate;
            EstimatedEndDate = estimatedEndDate;
            TotalAmount = totalAmount;
            DeliveryPersonId = deliveryPerson.Id;
            DeliveryPerson = deliveryPerson;
            MotorcycleId = motorcycle.Id;
            Motorcycle = motorcycle;
            RentalPlan = rentalPlan;
        }
        
    }
}