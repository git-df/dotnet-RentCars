using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User2Address : AuditableEntity
    {
        public int Id { get; set; }

        public int? UserAppId { get; set; }
        public UserApp? UserApp { get; set; }

        public int? AddressId { get; set; }
        public Address? Address { get; set; }
    }
}
