using System.Text.Json.Serialization;
using RentAndDelivery.Domain.Validation;

namespace RentAndDelivery.Domain.Entities
{
    public class OrderNotification : BaseEntity
    {
        #region  External Props
        public Guid DeliveryPersonId { get; private set; }
        public DeliveryPerson? DeliveryPerson { get; private set; }

        public Guid OrderId { get; private set; }
        public Order? Order { get; private set; }
        #endregion

        public OrderNotification(){}

        public OrderNotification(DeliveryPerson? deliveryPerson, Order? orders)
        {
            Id = SGVG.Next(null);
            CreatedOn = DateTime.Now;
            ValidateDomain(deliveryPerson, orders);
        }

        [JsonConstructor]
        public OrderNotification(Guid id,DeliveryPerson? deliveryPerson, Order? orders, DateTime createdOn)
        {
            DomainValidation.When(string.IsNullOrEmpty(id.ToString()), "Invalid Id value.");
            Id = id;
            CreatedOn = createdOn;
            ValidateDomain(deliveryPerson, orders);
        }


        public void Update(DeliveryPerson? deliveryPerson, Order? orders)
        {
             ValidateDomain(deliveryPerson, orders);
        }

        private void ValidateDomain(DeliveryPerson? deliveryPerson, Order? orders)
        {
            DomainValidation.When(deliveryPerson is null,
                "DeliveryPerson is Invalid. DeliveryPerson is required!");
             
            DomainValidation.When(orders is null,
                "Order is Invalid. Order is required!");
             

            DeliveryPerson = deliveryPerson;
            DeliveryPersonId = deliveryPerson.Id;
            Order = orders;
            OrderId = orders.Id;
        }
        
    }
}