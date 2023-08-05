using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Rent.Queries.GetRentOptionsDetails
{
    public class GetRentOptionsDetailsQueryVM
    {
        public int Id { get; set; }
        public string PlaceNumber { get; set; }
        public string VIN { get; set; }
        public string Fuel { get; set; }
        public int Year { get; set; }
        public string Image { get; set; }

        public CarsModelInGetRentOptionsDetailsQueryVM CarsModel { get; set; }
        public List<CarAttributeInGetRentOptionsDetailsQueryVM> CarAttributes { get; set; }
        public List<OfferInGetRentOptionsDetailsQueryVM> Offers { get; set; }
    }

    public class CarsModelInGetRentOptionsDetailsQueryVM
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
    }

    public class CarAttributeInGetRentOptionsDetailsQueryVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }

    public class OfferInGetRentOptionsDetailsQueryVM
    {
        public int Id { get; set; }
        public decimal PricePreDay { get; set; }
        public decimal PricePerHour { get; set; }
        public decimal Price { get; set; }

        public BranchInGetRentOptionsDetailsQueryVM Branch { get; set; }
    }

    public class BranchInGetRentOptionsDetailsQueryVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
