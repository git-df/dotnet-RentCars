using Application.Functions.Employes.Queries.GetBranchEmployes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Employes.Queries.GetEmployesNoInBranch
{
    public class GetEmployesNoInBranchQueryVM
    {
        public int Id { get; set; }
        public bool IsAdmin { get; set; }
        public UserAppInGetEmployesNoInBranchQueryVM UserApp { get; set; }
    }

    public class UserAppInGetEmployesNoInBranchQueryVM
    {
        public string Email { get; set; }
        public UserInfoInGetEmployesNoInBranchQueryVM UserInfo { get; set; }
    }

    public class UserInfoInGetEmployesNoInBranchQueryVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
