using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Offer : AuditableEntity
    {
        public int Id { get; set; }
        public decimal PricePreDay { get; set; }
        public decimal PricePerHour { get; set; }

        public int? CarId { get; set; }
        public Car? Car { get; set; }

        public int? BranchId { get; set; }
        public Branch? Branch { get; set; }
    }
}
