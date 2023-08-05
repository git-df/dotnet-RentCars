using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserEmployee : AuditableEntity
    {
        public int Id { get; set; }
        public bool IsAdmin { get; set; } = false;

        public int? UserAppId { get; set; }
        public UserApp? UserApp { get; set; }

        public List<UserEmployee2Branch> UserEmployee2Branches { get; set; } = new List<UserEmployee2Branch>();
    }
}
