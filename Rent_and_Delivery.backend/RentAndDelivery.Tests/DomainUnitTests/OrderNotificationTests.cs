using RentAndDelivery.Domain.Entities;
using RentAndDelivery.Domain.Enum;
using RentAndDelivery.Domain.Validation;

namespace RentAndDelivery.Tests.DomainUnitTests
{
    public class OrderNotificationTests
    {
        private OrderNotification? _orderNotification;

        public OrderNotificationTests()
        {
        }

        // Arrange
        [Theory(DisplayName = "When creating the Order Notification object, exceptions must be returned. Parameter:In DeliveryPerson=Object->{0}, Order=Object->{1}. Out Exception")]// Arrange
        [InlineData(true, false, "Order is Invalid. Order is required!")]
        [InlineData(false, true, "DeliveryPerson is Invalid. DeliveryPerson is required!")]
        public void CreateOrderNotificationExceptionIsExpected(bool CreateDeliveryPerson, bool CreateOrders, string exceptionMessege)
        {
            var exceptionType = typeof(DomainValidation);
            DeliveryPerson? deliveryPerson = null; 
            Order? orders = null;

            //Act
            if(CreateDeliveryPerson){ deliveryPerson = new DeliveryPerson();}
            if(CreateOrders){orders = new Order();}
            var ex = Record.Exception(() => _orderNotification = new OrderNotification(deliveryPerson, orders));

            //Assert
            Assert.NotNull(ex);
            Assert.IsType(exceptionType, ex);
            Assert.Equal(exceptionMessege, ex.Message);
        }


        [Fact(DisplayName = "When creating the Order Notification object, exceptions should not be returned")]
        public void CreateOrderNotificationExceptionIsNotExpected()
        {
            // Arrange
            DeliveryPerson deliveryPerson = new DeliveryPerson();
            Order orders = new Order();

            //Act
            var ex = Record.Exception(() => _orderNotification = new OrderNotification(deliveryPerson, orders));

            //Assert
            Assert.Null(ex);
        }
    }
}