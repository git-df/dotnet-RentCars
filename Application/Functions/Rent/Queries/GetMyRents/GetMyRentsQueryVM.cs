using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Rent.Queries.GetMyRents
{
    public class GetMyRentsQueryVM
    {
        public int Id { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Status { get; set; }

        public CarInGetMyRentsQueryVM Car { get; set; }

        public RentPaymentInGetMyRentsQueryVM RentPayment { get; set; }
    }

    public class CarInGetMyRentsQueryVM
    {
        public int Id { get; set; }
        public string PlaceNumber { get; set; }
        public string VIN { get; set; }

        public CarsModelInCarInGetMyRentsQueryVM CarsModel { get; set; }
    }

    public class CarsModelInCarInGetMyRentsQueryVM
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
    }

    public class RentPaymentInGetMyRentsQueryVM
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
    }
}
