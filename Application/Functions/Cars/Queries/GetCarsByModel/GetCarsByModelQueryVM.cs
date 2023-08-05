using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Cars.Queries.GetCarsByModel
{
    public class GetCarsByModelQueryVM
    {
        public int Id { get; set; }
        public string PlaceNumber { get; set; }
        public string VIN { get; set; }
        public int Year { get; set; }
        public string Image { get; set; }

        public CarsModelInGetCarsByModelQueryVM CarsModel { get; set; }
        public int OffersCount { get; set; }
        public int RentsCount { get; set; }
    }

    public class CarsModelInGetCarsByModelQueryVM
    {
        public string BrandName { get; set; }
        public string ModelName { get; set; }
    }
}
