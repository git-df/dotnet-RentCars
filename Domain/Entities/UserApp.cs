using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserApp : AuditableEntity
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Salt { get; set; } = string.Empty;

        public UserInfo? UserInfo { get; set; }

        public UserEmployee? UserEmployee { get; set; }

        public List<User2Address> User2Addresses { get; set; } = new List<User2Address>();

        public List<Rent> Rents { get; set; } = new List<Rent>();
    }
}
