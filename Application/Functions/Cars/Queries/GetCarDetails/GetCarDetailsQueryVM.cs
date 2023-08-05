using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Cars.Queries.GetCarDetails
{
    public class GetCarDetailsQueryVM
    {
        public int Id { get; set; }
        public string PlaceNumber { get; set; }
        public string VIN { get; set; }
        public string Fuel { get; set; }
        public int Year { get; set; }
        public string Image { get; set; }
        public CarsModelInGetCarDetailsQueryVM CarsModel { get; set; }
    }

    public class CarsModelInGetCarDetailsQueryVM
    {
        public int Id { get; set; }
        public string BrandName { get; set; } = string.Empty;
        public string ModelName { get; set; } = string.Empty;
    }
}
