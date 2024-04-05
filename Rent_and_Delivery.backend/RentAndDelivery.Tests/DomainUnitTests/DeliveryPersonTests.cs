using RentAndDelivery.Domain.Entities;
using RentAndDelivery.Domain.Enum;
using RentAndDelivery.Domain.Validation;

namespace RentAndDelivery.Tests.DomainUnitTests
{
    public class DeliveryPersonTests
    {
        private DeliveryPerson? _deliveryPerson;

        public DeliveryPersonTests(){
        }

        // Arrange
        [Theory(DisplayName = "When creating the DeliveryPerson object, exceptions must be returned. Parameter:In name={0}, cnpj={1}, birthDate=DateTime.Now.AddYears(-20), licenseNumberCNH={3}, licenseType={4}, imageCNH . Out {5} ")]
        [InlineData("", "74979006000199", "30222894101", CNHDriversLicenseType.A, "./images/imageCNH.jpg",   "Invalid name. FirstName is required!")]
        [InlineData(null, "74979006000199", "30222894101", CNHDriversLicenseType.A, "./images/imageCNH.jpg",   "Invalid name. FirstName is required!")]
        [InlineData("Jo", "74979006000199", "30222894101", CNHDriversLicenseType.A, "./images/imageCNH.jpg",   "Invalid name, too short, minimum 3 characters!")]
        [InlineData("john doe", "", "30222894101", CNHDriversLicenseType.A, "./images/imageCNH.jpg",   "Invalid CNPJ. CNPJ is required!")]
        [InlineData("john doe", null, "30222894101", CNHDriversLicenseType.A, "./images/imageCNH.jpg",   "Invalid CNPJ. CNPJ is required!")]
        [InlineData("john doe", "7497900600019", "30222894101", CNHDriversLicenseType.A, "./images/imageCNH.jpg",   "Invalid CNPJ, too short, minimum 14 characters!")]
        [InlineData("john doe", "74979006000199", "", CNHDriversLicenseType.A, "./images/imageCNH.jpg",   "License Number CNH is invalid. License Number CNH is required!")]
        [InlineData("john doe", "74979006000199", null, CNHDriversLicenseType.A, "./images/imageCNH.jpg",   "License Number CNH is invalid. License Number CNH is required!")]
        [InlineData("john doe", "74979006000199", "30222894101", CNHDriversLicenseType.A, "",   "Invalid Image of CNH. Image of CNH is required!")]
        [InlineData("john doe", "74979006000199", "30222894101", CNHDriversLicenseType.A, null,   "Invalid Image of CNH. Image of CNH is required!")]
        public void CreateDeliveryPersonExceptionIsExpected(string name, string cnpj, string licenseNumberCNH, CNHDriversLicenseType licenseType, string imageCNH, string exceptionMessege)
        {
            var exceptionType = typeof(DomainValidation);
            DateTime birthDate = DateTime.Now.AddYears(-20);

            //Act
            var ex = Record.Exception(() => _deliveryPerson = new DeliveryPerson(name, cnpj, birthDate, licenseNumberCNH, licenseType, imageCNH));

            //Assert
            Assert.NotNull(ex);
            Assert.IsType(exceptionType, ex);
            Assert.Equal(exceptionMessege, ex.Message);
        }

        [Fact(DisplayName = "When creating the DeliveryPerson object, exceptions must be returned. Parameter: IN birthDate = DateTime.Now. Out Birth date is invalid. Birth date of birth is required!")]
        public void CreateDeliveryPersonPlusYearExceptionIsExpected()
        {   // Arrange
            var exceptionType = typeof(DomainValidation);
            string name = "john doe";
            string cnpj = "74979006000199";
            DateTime birthDate = DateTime.Now.AddYears(1);
            string licenseNumberCNH = "30222894101";
            CNHDriversLicenseType licenseType = CNHDriversLicenseType.A;
            string imageCNH  = "./images/imageCNH.jpg";
            string exceptionMessege = "Birth date is invalid. Birth date of birth is required!";

            //Act
            var ex = Record.Exception(() => _deliveryPerson = new DeliveryPerson(name, cnpj, birthDate, licenseNumberCNH, licenseType, imageCNH));

            //Assert
            Assert.NotNull(ex);
            Assert.IsType(exceptionType, ex);
            Assert.Equal(exceptionMessege, ex.Message);
        }

        [Fact(DisplayName = "When creating the DeliveryPerson object, exceptions must be returned. Parameter: IN birthDate = DateTime.Now.AddYears(-101);. Out Birth date is invalid. Birth date of birth is required!")]
        public void CreateDeliveryPersonMoreThan100YearsOldExceptionIsExpected()
        {   // Arrange
            var exceptionType = typeof(DomainValidation);
            string name = "john doe";
            string cnpj = "74979006000199";
            DateTime birthDate = DateTime.Now.AddYears(-101);
            string licenseNumberCNH = "30222894101";
            CNHDriversLicenseType licenseType = CNHDriversLicenseType.A;
            string imageCNH  = "./images/imageCNH.jpg";
            string exceptionMessege = "Birth date is invalid. Birth date of birth is required!";

            //Act
            var ex = Record.Exception(() => _deliveryPerson = new DeliveryPerson(name, cnpj, birthDate, licenseNumberCNH, licenseType, imageCNH));

            //Assert
            Assert.NotNull(ex);
            Assert.IsType(exceptionType, ex);
            Assert.Equal(exceptionMessege, ex.Message);
        }


        [Fact(DisplayName = "When creating the Delivery Person object, exceptions should not be returned")]
        public void CreateDeliveryPersonExceptionIsNotExpected()
        {
            // Arrange
            string name = "john doe";
            string cnpj = "74979006000199";
            DateTime birthDate = DateTime.Now.AddYears(-20);
            string licenseNumberCNH = "30222894101";
            CNHDriversLicenseType licenseType = CNHDriversLicenseType.A;
            string imageCNH  = "./images/imageCNH.jpg";

            //Act
            var ex = Record.Exception(() => _deliveryPerson = new DeliveryPerson(name, cnpj, birthDate, licenseNumberCNH, licenseType, imageCNH));

            //Assert
            Assert.Null(ex);
        }
        
    }
}