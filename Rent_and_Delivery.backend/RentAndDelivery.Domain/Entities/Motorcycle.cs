using System.Text.Json.Serialization;
using RentAndDelivery.Domain.Enum;
using RentAndDelivery.Domain.Validation;
using RentAndDelivery.Domain.Util;

namespace RentAndDelivery.Domain.Entities
{
    public class Motorcycle : BaseEntity
    {

        #region  External Props
        public int? Year { get; private set; }
        public string? Model { get; private set; }
        public string? Plate  { get; private set; }
        public MotorcycleStatusType? Status { get; set; }
        #endregion 

        public Motorcycle()
        {}

        public Motorcycle(int year, string model, string plate, MotorcycleStatusType status)
        {
            Id = SGVG.Next(null);
            CreatedOn = DateTime.Now;
            ValidateDomain(year, model, plate, status);
        }

        [JsonConstructor]
        public Motorcycle(Guid id, int year, string model, string plate, MotorcycleStatusType status, DateTime createdOn)
        {
            DomainValidation.When(string.IsNullOrEmpty(id.ToString()), "Invalid Id value.");
            Id = id;
            CreatedOn = createdOn;
            ValidateDomain(year, model, plate, status);
        }

        public void Update(int? year, string model, string plate, MotorcycleStatusType? status)
        {
            ValidateDomain(year, model, plate, status);
        }

        private void ValidateDomain(int? year, string model, string plate, MotorcycleStatusType? status)
        {


            DomainValidation.When(year<1910 || year>DateTime.Now.Year,
                "Year of manufacture is invalid. Year of manufacture is required!");

            DomainValidation.When(string.IsNullOrEmpty(model),
                "Invalid model. Model is required!");

            DomainValidation.When(model.Length < 3,
                "Invalid model, too short, minimum 3 characters!");

            DomainValidation.When(string.IsNullOrEmpty(plate),
                "Invalid plate. Plate is required!");

            DomainValidation.When(plate.Length < 3,
                "Invalid plate, too short, minimum 3 characters!");

            //TODO: validate FOR MotorcycleStatusType status

            Year = year;
            Model = model.ToUpper();
            Plate = RemoveSpecialCharacters.RemoveSpecialCharactersStr(plate.ToUpper());
            Status = status;
        }
    }
}