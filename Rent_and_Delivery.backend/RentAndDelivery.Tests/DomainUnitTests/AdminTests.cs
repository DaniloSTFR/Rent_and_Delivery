
using RentAndDelivery.Domain.Entities;
using RentAndDelivery.Domain.Validation;

namespace RentAndDelivery.Tests.DomainUnitTests
{
    public class AdminTests
    {
        private Admin? _admin;

        public AdminTests(){}

        [Theory(DisplayName = "When creating the admin object, exceptions must be returned. Parameter:In {0}, Out {1} ")]// Arrange
        [InlineData(null, "Invalid name. Name is required!")]
        [InlineData("", "Invalid name. Name is required!")]
        [InlineData("DS", "Invalid name, too short, minimum 3 characters!")]
        public void CreateAdminExceptionIsExpected(string name, string exceptionMessege)
        {
            var exceptionType = typeof(DomainValidation);

            //Act
            var ex = Record.Exception(() => _admin = new Admin(name));

            //Assert
            Assert.NotNull(ex);
            Assert.IsType(exceptionType, ex);
            Assert.Equal(exceptionMessege, ex.Message);
        }

        [Fact(DisplayName = "When creating the admin object, exceptions should not be returned")]
        public void CreateAdminExceptionIsNotExpected()
        {
            // Arrange
            string name = "DSF";
            var exceptionType = typeof(DomainValidation);

            //Act
            var ex = Record.Exception(() => _admin = new Admin(name));

            //Assert
            Assert.Null(ex);
        }


    }
}