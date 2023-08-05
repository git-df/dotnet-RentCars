using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Car : AuditableEntity
    {
        public int Id { get; set; }
        public string PlaceNumber { get; set; } = string.Empty;
        public string VIN { get; set; } = string.Empty;
        public string Fuel { get; set; } = string.Empty;
        public int Year { get; set; }
        public string Image { get; set; } = string.Empty;
        public bool IsDeleted { get; set; } = false;

        public int? CarsModelId { get; set; }
        public CarsModel? CarsModel { get; set; }

        public List<CarAttribute> CarAttributes { get; set; } = new List<CarAttribute>();

        public List<Offer> Offers { get; set; } = new List<Offer>();

        public List<Rent> Rents { get; set; } = new List<Rent>();
    }
}
