using RentAndDelivery.Domain.Entities;
using RentAndDelivery.Domain.Enum;
using RentAndDelivery.Domain.Validation;

namespace RentAndDelivery.Tests.DomainUnitTests
{
    public class MotorcycleTests
    {
        private Motorcycle? _motorcycle;

        public MotorcycleTests()
        {
        }

         // Arrange
        [Theory(DisplayName = "When creating the Motorcycle object, exceptions must be returned. Parameter:In year={0}, model={1}, plate={2}. Out {3} ")]// Arrange
        [InlineData(1909, "Factor 125", "OFL0823", "Year of manufacture is invalid. Year of manufacture is required!")]
        [InlineData(2010, null, "OFL0823", "Invalid model. Model is required!")]
        [InlineData(2010, "Factor 125", null, "Invalid plate. Plate is required!")]
        [InlineData(2010, "", "OFL0823", "Invalid model. Model is required!")]
        [InlineData(2010, "Factor 125", "", "Invalid plate. Plate is required!")]
        [InlineData(2010, "Fa", "OFL0823", "Invalid model, too short, minimum 3 characters!")]
        [InlineData(2010, "Factor 125", "OF", "Invalid plate, too short, minimum 3 characters!")]
        public void CreateMotorcycleExceptionIsExpected(int year, string model, string plate, string exceptionMessege)
        {
            var exceptionType = typeof(DomainValidation);

            //Act
            var ex = Record.Exception(() => _motorcycle = new Motorcycle(year, model, plate, MotorcycleStatusType.Available));

            //Assert
            Assert.NotNull(ex);
            Assert.IsType(exceptionType, ex);
            Assert.Equal(exceptionMessege, ex.Message);
        }

        [Fact(DisplayName = "When creating the Motorcycle object and the manufacturing year is greater than the current one, exceptions should not be returned")]
        public void CreateMotorcyclePlusYearExceptionIsExpected()
        {   // Arrange
            var exceptionType = typeof(DomainValidation);
            int year = DateTime.Now.Year +1;
            string model = "Factor 125";
            string plate = "OFL0823";
            string exceptionMessege = "Year of manufacture is invalid. Year of manufacture is required!";

            //Act
            var ex = Record.Exception(() => _motorcycle = new Motorcycle(year, model, plate, MotorcycleStatusType.Available));

            //Assert
            Assert.NotNull(ex);
            Assert.IsType(exceptionType, ex);
            Assert.Equal(exceptionMessege, ex.Message);
        }

        [Fact(DisplayName = "When creating the Motorcycle object, exceptions should not be returned")]
        public void CreateMotorcycleExceptionIsNotExpected()
        {
            // Arrange
            int year = DateTime.Now.Year;
            string model = "Fac";
            string plate = "OFL";

            //Act
            var ex = Record.Exception(() => _motorcycle = new Motorcycle(year, model, plate, MotorcycleStatusType.Available));

            //Assert
            Assert.Null(ex);
        }
    }
}