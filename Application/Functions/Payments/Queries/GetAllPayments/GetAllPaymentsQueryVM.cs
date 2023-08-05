using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Payments.Queries.GetAllPayments
{
    public class GetAllPaymentsQueryVM
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }

        public RentInGetAllPaymentsQueryVM Rent { get; set; }
    }

    public class RentInGetAllPaymentsQueryVM
    {
        public int Id { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Status { get; set; }

        public UserAppInGetAllPaymentsQueryVM UserApp { get; set; }
    }

    public class UserAppInGetAllPaymentsQueryVM
    {
        public int Id { get; set; }
        public string Email { get; set; }
    }
}
