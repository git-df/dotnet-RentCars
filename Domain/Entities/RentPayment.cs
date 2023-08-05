using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class RentPayment : AuditableEntity
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; } = string.Empty;

        public int RentId { get; set; }
        public Rent? Rent { get; set; }
    }
}
