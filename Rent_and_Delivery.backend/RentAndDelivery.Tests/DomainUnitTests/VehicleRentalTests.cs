using RentAndDelivery.Domain.Entities;
using RentAndDelivery.Domain.Enum;
using RentAndDelivery.Domain.Validation;

namespace RentAndDelivery.Tests.DomainUnitTests
{
    public class VehicleRentalTests
    {
        private VehicleRental? _vehicleRental;

        private DateTime StartDate = DateTime.Now.AddDays(1);
        private DateTime EndDate;
        private DateTime EstimatedEndDate;
        private float TotalAmount;
        private DeliveryPerson DeliveryPerson;
        private Motorcycle Motorcycle;
        private RentalPlan RentalPlan;

        public VehicleRentalTests(){}

        private void InitializingParameters()
        {
            EndDate = DateTime.Now.AddDays(3);
            EstimatedEndDate = DateTime.Now.AddDays(3);
            TotalAmount = 0;
            DeliveryPerson = new DeliveryPerson("john doe", "74979006000199", DateTime.Now.AddYears(-20), "30222894101", CNHDriversLicenseType.AandB , "./images/imageCNH.jpg");
            Motorcycle = new Motorcycle(DateTime.Now.Year, "Fac", "OFL", MotorcycleStatusType.Available);
            RentalPlan = new RentalPlan(new Guid("3531a2ac-015f-4b7e-95b6-8f6e54a040bb"), "7_Days", 7, 30, 20, 50, DateTime.Now);
        }

         
        [Fact(DisplayName = "When creating the Vehicle Rental object, exceptions must be returned.Validate for EndDate Same To StartDate")]
        public void CreateVehicleRentalExceptionIsExpectedValidateEndDateSameToStartDate()
        {
            // Arrange
            InitializingParameters();
            var exceptionType = typeof(DomainValidation);
            EndDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.AddDays(1).Day);
            string exceptionMessege = "The rental end date cannot be equals or less than the start date!";

            //Act
            var ex = Record.Exception(() => _vehicleRental = new VehicleRental(StartDate, EndDate, EstimatedEndDate, TotalAmount, DeliveryPerson, Motorcycle, RentalPlan));

            //Assert
            Assert.NotNull(ex);
            Assert.IsType(exceptionType, ex);
            Assert.Equal(exceptionMessege, ex.Message);
        }

        [Fact(DisplayName = "When creating the Vehicle Rental object, exceptions must be returned.Validate for EndDate less than the StartDate")]
        public void CreateVehicleRentalExceptionIsExpectedValidateEndDateLessThanTheStartDate()
        {
            // Arrange
            InitializingParameters();
            var exceptionType = typeof(DomainValidation);
            EndDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            string exceptionMessege = "The rental end date cannot be equals or less than the start date!";

            //Act
            var ex = Record.Exception(() => _vehicleRental = new VehicleRental(StartDate, EndDate, EstimatedEndDate, TotalAmount, DeliveryPerson, Motorcycle, RentalPlan));

            //Assert
            Assert.NotNull(ex);
            Assert.IsType(exceptionType, ex);
            Assert.Equal(exceptionMessege, ex.Message);
        }

        [Fact(DisplayName = "When creating the Vehicle Rental object, exceptions must be returned.Validate for EstimatedEndDate Same To StartDate")]
        public void CreateVehicleRentalExceptionIsExpectedValidateEstimatedEndDateSameToStartDate()
        {
            // Arrange
            InitializingParameters();
            var exceptionType = typeof(DomainValidation);
            EstimatedEndDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.AddDays(1).Day);
            string exceptionMessege = "The rental end estimated End Date cannot be equal or less than the start date!";

            //Act
            var ex = Record.Exception(() => _vehicleRental = new VehicleRental(StartDate, EndDate, EstimatedEndDate, TotalAmount, DeliveryPerson, Motorcycle, RentalPlan));

            //Assert
            Assert.NotNull(ex);
            Assert.IsType(exceptionType, ex);
            Assert.Equal(exceptionMessege, ex.Message);
        }

        [Fact(DisplayName = "When creating the Vehicle Rental object, exceptions must be returned.Validate for EstimatedEndDate less than the StartDate")]
        public void CreateVehicleRentalExceptionIsExpectedValidateEstimatedEndDateLessThanTheStartDate()
        {
            // Arrange
            InitializingParameters();
            var exceptionType = typeof(DomainValidation);
            EstimatedEndDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            string exceptionMessege = "The rental end estimated End Date cannot be equal or less than the start date!";

            //Act
            var ex = Record.Exception(() => _vehicleRental = new VehicleRental(StartDate, EndDate, EstimatedEndDate, TotalAmount, DeliveryPerson, Motorcycle, RentalPlan));

            //Assert
            Assert.NotNull(ex);
            Assert.IsType(exceptionType, ex);
            Assert.Equal(exceptionMessege, ex.Message);
        }

       [Fact(DisplayName = "When creating the Vehicle Rental object, exceptions must be returned.Validate for TotalAmount less than zero")]
        public void CreateVehicleRentalExceptionIsExpectedValidateTotalAmountLessThanZero()
        {
            // Arrange
            InitializingParameters();
            var exceptionType = typeof(DomainValidation);
            TotalAmount = (float) - 0.1;
            string exceptionMessege = "The total amount does not have a valid value!";

            //Act
            var ex = Record.Exception(() => _vehicleRental = new VehicleRental(StartDate, EndDate, EstimatedEndDate, TotalAmount, DeliveryPerson, Motorcycle,RentalPlan));

            //Assert
            Assert.NotNull(ex);
            Assert.IsType(exceptionType, ex);
            Assert.Equal(exceptionMessege, ex.Message);
        }

        [Fact(DisplayName = "When creating the Vehicle Rental object, exceptions must be returned. Validate If DeliveryPerson is null it will generate an exception")]
        public void CreateVehicleRentalExceptionIsExpectedValidateDeliveryPersonIsNull()
        {
            // Arrange
            InitializingParameters();
            var exceptionType = typeof(DomainValidation);
            DeliveryPerson = null;
            string exceptionMessege = "DeliveryPerson is Invalid. DeliveryPerson is required";

            //Act
            var ex = Record.Exception(() => _vehicleRental = new VehicleRental(StartDate, EndDate, EstimatedEndDate, TotalAmount, DeliveryPerson, Motorcycle, RentalPlan));

            //Assert
            Assert.NotNull(ex);
            Assert.IsType(exceptionType, ex);
            Assert.Equal(exceptionMessege, ex.Message);
        }

        [Fact(DisplayName = "When creating the Vehicle Rental object, exceptions must be returned. Validate If DeliveryPerson has a license other than A, an exception will be generated.")]
        public void CreateVehicleRentalExceptionIsExpectedValidateDeliveryLicenseOtherThanA()
        {
            // Arrange
            InitializingParameters();
            var exceptionType = typeof(DomainValidation);
            DeliveryPerson = new DeliveryPerson("john doe", "74979006000199", DateTime.Now.AddYears(-20), "30222894101", CNHDriversLicenseType.B, "./images/imageCNH.jpg");
            string exceptionMessege = "Delivery person does not have a valid type of license. The license type must be A or A and B!";

            //Act
            var ex = Record.Exception(() => _vehicleRental = new VehicleRental(StartDate, EndDate, EstimatedEndDate, TotalAmount, DeliveryPerson, Motorcycle, RentalPlan));

            //Assert
            Assert.NotNull(ex);
            Assert.IsType(exceptionType, ex);
            Assert.Equal(exceptionMessege, ex.Message);
        }
        
        [Fact(DisplayName = "When creating the Vehicle Rental object, exceptions must be returned. Validate If motorcycle is null it will generate an exception")]
        public void CreateVehicleRentalExceptionIsExpectedValidateMotorcycleIsNull()
        {
            // Arrange
            InitializingParameters();
            var exceptionType = typeof(DomainValidation);
            Motorcycle = null;
            string exceptionMessege = "Motorcycle is Invalid. Motorcycle is required!";

            //Act
            var ex = Record.Exception(() => _vehicleRental = new VehicleRental(StartDate, EndDate, EstimatedEndDate, TotalAmount, DeliveryPerson, Motorcycle, RentalPlan));

            //Assert
            Assert.NotNull(ex);
            Assert.IsType(exceptionType, ex);
            Assert.Equal(exceptionMessege, ex.Message);
        }

        [Fact(DisplayName = "When creating the Vehicle Rental object, exceptions must be returned. Validate If the motorcycle is not available, an exception will be generated.")]
        public void CreateVehicleRentalExceptionIsExpectedValidateIfTheMotorcycleIsNotAvailable()
        {
            // Arrange
            InitializingParameters();
            var exceptionType = typeof(DomainValidation);
            Motorcycle = new Motorcycle(DateTime.Now.Year, "Fac", "OFL", MotorcycleStatusType.Rented);
            string exceptionMessege = "The motorcycle is not available for rent. An available motorcycle is required!";

            //Act
            var ex = Record.Exception(() => _vehicleRental = new VehicleRental(StartDate, EndDate, EstimatedEndDate, TotalAmount, DeliveryPerson, Motorcycle, RentalPlan));

            //Assert
            Assert.NotNull(ex);
            Assert.IsType(exceptionType, ex);
            Assert.Equal(exceptionMessege, ex.Message);
        }

        [Fact(DisplayName = "When creating the Vehicle Rental object, exceptions should not be returned")]
        public void CreateVehicleRentalExceptionIsNotExpected()
        {
            // Arrange
            InitializingParameters();
            //Act
            var ex = Record.Exception(() => _vehicleRental = new VehicleRental(StartDate, EndDate, EstimatedEndDate, TotalAmount, DeliveryPerson, Motorcycle, RentalPlan));

            //Assert
            Assert.Null(ex);
        }
    }
}