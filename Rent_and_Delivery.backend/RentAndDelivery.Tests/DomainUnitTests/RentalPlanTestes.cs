using RentAndDelivery.Domain.Entities;
using RentAndDelivery.Domain.Validation;

namespace RentAndDelivery.Tests.DomainUnitTests
{
    public class RentalPlanTestes
    {
        private RentalPlan? _rentalPlan;

        public RentalPlanTestes(){}

        // Arrange
        [Theory(DisplayName = "When creating the Rental Plans object, exceptions must be returned. Parameter:In planName={0}, planDays={1}, costPerDay={2}, fineInPercentage={3}, additionalValuePerDay={4}, Out {5} ")]
        [InlineData("", 7, 30, 20, 50,   "Invalid Plan Name. Plan Name is required!")]
        [InlineData(null, 7, 30, 20, 50, "Invalid Plan Name. Plan Name is required!")]
        [InlineData("7 dias", -1, 30, 20, 50, "Invalid Plan Days. Plan Days must be greater than zero!")]
        [InlineData("7 dias", 7, -0.1, 20, 50, "Invalid model. Cost per day must be greater than zero!")]
        [InlineData("7 dias", 7, 30, -0.1, 50, "Invalid fines. Fine must be greater than zero!")]
        [InlineData("7 dias", 7, 30, 20, -0.1, "Additional value per day is Invalid. Additional value per day must be greater than zero!")]
        public void CreateRentalPlanExceptionIsExpected(string planName, int planDays, float costPerDay, float fineInPercentage, float additionalValuePerDay, string exceptionMessege)
        {
            var exceptionType = typeof(DomainValidation);

            //Act
            var ex = Record.Exception(() => _rentalPlan = new RentalPlan(planName, planDays, costPerDay, fineInPercentage, additionalValuePerDay));

            //Assert
            Assert.NotNull(ex);
            Assert.IsType(exceptionType, ex);
            Assert.Equal(exceptionMessege, ex.Message);
        }

        
        [Fact(DisplayName = "When creating the Rental Plans object, exceptions should not be returned")]
        public void CreateRentalPlanExceptionIsNotExpected()
        {
            // Arrange
            string planName = "7 dias";
            int planDays = 7;
            float costPerDay = 30;
            float fineInPercentage = 20;
            float additionalValuePerDay = 50;

            //Act
            var ex = Record.Exception(() => _rentalPlan = new RentalPlan(planName, planDays, costPerDay, fineInPercentage, additionalValuePerDay));

            //Assert
            Assert.Null(ex);
        }
    }
}