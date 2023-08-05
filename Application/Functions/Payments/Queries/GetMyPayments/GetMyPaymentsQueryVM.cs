using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Payments.Queries.GetMyPayments
{
    public class GetMyPaymentsQueryVM
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }

        public RentInGetMyPaymentsQueryVM Rent { get; set; }
    }

    public class RentInGetMyPaymentsQueryVM
    {
        public int Id { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Status { get; set; }
    }
}
