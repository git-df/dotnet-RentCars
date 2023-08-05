using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Rent.Queries.GetRentOptions
{
    public class GetRentOptionsQueryVM
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string Image { get; set; }
        public CarsModelInGetRentOptionsQueryVM CarsModel { get; set; }
        public decimal BestPrice { get; set; }
    }

    public class CarsModelInGetRentOptionsQueryVM
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
    }
}
