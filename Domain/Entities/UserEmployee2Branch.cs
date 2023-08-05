using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserEmployee2Branch : AuditableEntity
    {
        public int Id { get; set; }

        public int? UserEmployeeId { get; set; }
        public UserEmployee? UserEmployee { get; set; }

        public int? BranchId { get; set; }
        public Branch? Branch { get; set; }
    }
}
