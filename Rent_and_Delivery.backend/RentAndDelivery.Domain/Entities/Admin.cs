using System.Text.Json.Serialization;
using RentAndDelivery.Domain.Validation;

namespace RentAndDelivery.Domain.Entities
{
    public class Admin : BaseEntity
    {
        #region  External Props
        public string? Name { get; private set; }
        #endregion 

        public Admin()
        {            
        }

        public Admin(string name)
        {
            CreatedOn = DateTime.Now;
            ValidateDomain(name);
        }

        [JsonConstructor]
        public Admin(Guid id, string name, DateTime createdOn)
        {
            DomainValidation.When(string.IsNullOrEmpty(id.ToString()), "Invalid Id value!");
            Id = id;
            CreatedOn = createdOn;
            ValidateDomain(name);
        }

        public void Update(string name)
        {
            ValidateDomain(name);
        }

        private void ValidateDomain(string name)
        {
            DomainValidation.When(string.IsNullOrEmpty(name),
                "Invalid name. Name is required!");

            DomainValidation.When(name.Length < 3,
                "Invalid name, too short, minimum 3 characters!");

            Name = name;
        }

    }
}