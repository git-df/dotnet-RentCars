using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Rent.Queries.GetAllRents
{
    public class GetAllRentsQueryVM
    {
        public int Id { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Status { get; set; }

        public CarInGetAllRentsQueryVM Car { get; set; }

        public UserAppInGetAllRentsQueryVM UserApp { get; set; }

        public RentPaymentInGetAllRentsQueryVM RentPayment { get; set; }
    }

    public class CarInGetAllRentsQueryVM
    {
        public int Id { get; set; }
        public string PlaceNumber { get; set; }
        public string VIN { get; set; }

        public CarsModelInGetAllRentsQueryVM CarsModel { get; set; }
    }

    public class CarsModelInGetAllRentsQueryVM
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
    }

    public class UserAppInGetAllRentsQueryVM
    {
        public int Id { get; set; }
        public string Email { get; set; }
    }

    public class RentPaymentInGetAllRentsQueryVM
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
    }
}
