using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Address : AuditableEntity
    {
        public int Id { get; set; }
        public string Country { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string StreetWithNumber { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;

        public List<Branch> Branches { get; set; } = new List<Branch>();

        public List<User2Address> User2Addresses { get; set; } = new List<User2Address>();
    }
}
