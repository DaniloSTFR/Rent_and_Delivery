using RentAndDelivery.Domain.Entities;
using RentAndDelivery.Domain.Enum;
using RentAndDelivery.Domain.Validation;

namespace RentAndDelivery.Tests.DomainUnitTests
{
    public class OrderTests
    {
        private Order? _order;

        public OrderTests(){}

        // Arrange
        [Theory(DisplayName = "When creating the Order object, exceptions must be returned. Parameter:In {0}, Out {1} ")]// Arrange
        [InlineData(-0.1, "The race Value does not have a valid value!")]
        [InlineData(-1, "The race Value does not have a valid value!")]
        public void CreateOrderExceptionIsExpected(float raceValue, string exceptionMessege)
        {
            var exceptionType = typeof(DomainValidation);

            //Act
            var ex = Record.Exception(() => _order = new Order(raceValue, OrderStatusType.Available));

            //Assert
            Assert.NotNull(ex);
            Assert.IsType(exceptionType, ex);
            Assert.Equal(exceptionMessege, ex.Message);
        }

        // Arrange
        [Theory(DisplayName = "When creating the Order object, exceptions should not be returned. Parameter:In {0}, Out Null")]// Arrange
        [InlineData(0)]
        [InlineData(1)]
        public void CreateOrderExceptionIsNotExpected(float raceValue)
        {
            //Act
            var ex = Record.Exception(() => _order = new Order(raceValue, OrderStatusType.Available));

            //Assert
            Assert.Null(ex);
        }
    }
}