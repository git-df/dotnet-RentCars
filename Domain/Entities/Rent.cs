using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Rent : AuditableEntity
    {
        public int Id { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Status { get; set; } = string.Empty;

        public int CarId { get; set; }
        public Car? Car { get; set; }

        public int? UserAppId { get; set; }
        public UserApp? UserApp { get; set; }

        public RentPayment? RentPayment { get; set; }
    }
}
