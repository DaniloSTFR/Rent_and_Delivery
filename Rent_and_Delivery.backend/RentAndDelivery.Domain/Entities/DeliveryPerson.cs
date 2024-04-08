using System.Text.Json.Serialization;
using RentAndDelivery.Domain.Enum;
using RentAndDelivery.Domain.Validation;

namespace RentAndDelivery.Domain.Entities
{
    public class DeliveryPerson : BaseEntity
    {

        #region  External Props
        public string? Name { get; private set; }
        public string? CNPJ { get; private set; }
        public DateTime? BirthDate { get; private set; }
        public string? LicenseNumberCNH { get; private set; }
        public CNHDriversLicenseType? LicenseType { get; private set; }
        public string? ImageCNH { get; private set; }

        #endregion 
        
        public DeliveryPerson(){}
        public DeliveryPerson(string name, string cnpj, DateTime birthDate, string licenseNumberCNH, CNHDriversLicenseType licenseType, string imageCNH)
        {
            Id = SGVG.Next(null);
            CreatedOn = DateTime.Now;
            ValidateDomain(name, cnpj, birthDate, licenseNumberCNH, licenseType, imageCNH);
        }

        [JsonConstructor]
        public DeliveryPerson(Guid id, string name, string cnpj, DateTime birthDate, string licenseNumberCNH, CNHDriversLicenseType licenseType, string imageCNH, DateTime createdOn)
        {
            DomainValidation.When(string.IsNullOrEmpty(id.ToString()), "Invalid Id value!");
            Id = id;
            CreatedOn = createdOn;
            ValidateDomain(name, cnpj, birthDate, licenseNumberCNH, licenseType, imageCNH);
        }

        public void Update(string name, string cnpj, DateTime birthDate, string licenseNumberCNH, CNHDriversLicenseType licenseType, string imageCNH)
        {
            ValidateDomain(name, cnpj, birthDate, licenseNumberCNH, licenseType, imageCNH);
        }

        private void ValidateDomain(string name, string cnpj, DateTime birthDate, string licenseNumberCNH, CNHDriversLicenseType licenseType, string imageCNH)
        {

            DomainValidation.When(string.IsNullOrEmpty(name),
                "Invalid name. FirstName is required!");

            DomainValidation.When(name.Length < 3,
                "Invalid name, too short, minimum 3 characters!");

            //TODO: Implements a CNPJ validator algorithm
            DomainValidation.When(string.IsNullOrEmpty(cnpj),
                "Invalid CNPJ. CNPJ is required!");

            DomainValidation.When(cnpj.Length < 14,
                "Invalid CNPJ, too short, minimum 14 characters!");

            DomainValidation.When(birthDate < new DateTime(DateTime.Now.AddYears(-100).Year, 1, 1) || birthDate > DateTime.Now,
                "Birth date is invalid. Birth date of birth is required!");

            DomainValidation.When(string.IsNullOrEmpty(licenseNumberCNH),
                "License Number CNH is invalid. License Number CNH is required!");

            /* DomainValidation.When( Enum.IsDefined(typeof(CNHDriversLicenseType), licenseType),
            "Invalid name. FirstName is required!"); */

            DomainValidation.When(string.IsNullOrEmpty(imageCNH),
                "Invalid Image of CNH. Image of CNH is required!");

            Name = name;
            CNPJ = cnpj;
            BirthDate = birthDate;
            LicenseNumberCNH = licenseNumberCNH;
            LicenseType = licenseType;
            ImageCNH = imageCNH; 
        }


    }
}