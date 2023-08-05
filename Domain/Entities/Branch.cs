using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Branch : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        public int? AddressId { get; set; }
        public Address? Address { get; set; }

        public List<UserEmployee2Branch> UserEmployee2Branches { get; set; } = new List<UserEmployee2Branch>();

        public List<Offer> Offers { get; set; } = new List<Offer>();
    }
}
