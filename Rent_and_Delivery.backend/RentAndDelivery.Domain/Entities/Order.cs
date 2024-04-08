
using System.Text.Json.Serialization;
using RentAndDelivery.Domain.Enum;
using RentAndDelivery.Domain.Validation;

namespace RentAndDelivery.Domain.Entities
{
    public class Order : BaseEntity
    {
        #region  External Props
        public float? RaceValue { get; private set; }
        public OrderStatusType? OrderStatusStatus { get; private set; }
        public Guid? DeliveryPersonId { get; set; }
        public DeliveryPerson? DeliveryPerson { get; set; }       
        public DateTime? AcceptedOrderDate { get; set; }
        public DateTime? DeliveredOrderDate { get; set; }
        #endregion

        public Order(){}

        public Order(float raceValue, OrderStatusType orderStatusStatus)
        {
            Id = SGVG.Next(null);
            CreatedOn = DateTime.Now;
            ValidateDomain(raceValue, orderStatusStatus);
        }

        [JsonConstructor]
        public Order(Guid id, float raceValue, OrderStatusType orderStatusStatus, DateTime createdOn)
        {
            DomainValidation.When(string.IsNullOrEmpty(id.ToString()), "Invalid Id value.");
            Id = id;
            CreatedOn = createdOn;
            ValidateDomain(raceValue, orderStatusStatus);
        }

        public void Update(float raceValue, OrderStatusType orderStatusStatus)
        {
            ValidateDomain(raceValue, orderStatusStatus);
        }


        private void ValidateDomain(float raceValue, OrderStatusType orderStatusStatus)
        {
            DomainValidation.When(raceValue < 0,
                "The race Value does not have a valid value!");

            RaceValue = raceValue;
            OrderStatusStatus = orderStatusStatus;
        }

    }
}