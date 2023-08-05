using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Cars.Queries.GetCar
{
    public class GetCarQueryVM
    {
        public int Id { get; set; }
        public string Fuel { get; set; }
        public int Year { get; set; }
        public string Image { get; set; }

        public CarsModelInGetCarQueryVM CarsModel { get; set; }

        public List<CarAttributeInGetCarQueryVM> CarAttributes { get; set; } = new List<CarAttributeInGetCarQueryVM>();

        public List<OfferInGetCarQueryVM> Offers { get; set; } = new List<OfferInGetCarQueryVM>();
    }

    public class CarsModelInGetCarQueryVM
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
    }

    public class CarAttributeInGetCarQueryVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class OfferInGetCarQueryVM
    {
        public int Id { get; set; }
        public decimal PricePreDay { get; set; }
        public decimal PricePerHour { get; set; }

        public BranchInGetCarQueryVM Branch { get; set; }
    }

    public class BranchInGetCarQueryVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
