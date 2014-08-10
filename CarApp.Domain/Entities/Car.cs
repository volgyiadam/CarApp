using System;
namespace CarApp.Domain.Entities
{
    public class Car : Entity
    {
        public string LicencePlate { get; set; }

        public string TelepHelyAddress { get; set; }

        public System.Collections.Generic.IEnumerable<Site> Telephelyek { get; set; }
        public Guid TelepId { get; set; }
    }
}
