using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Employes.Queries.GetBranchEmployes
{
    public class GetBranchEmployesQueryVM
    {
        public int Id { get; set; }
        public bool IsAdmin { get; set; }
        public UserAppInGetBranchEmployesQueryVM UserApp { get; set; }
    }

    public class UserAppInGetBranchEmployesQueryVM
    {
        public string Email { get; set; }
        public UserInfoInGetBranchEmployesQueryVM UserInfo { get; set; }
    }

    public class UserInfoInGetBranchEmployesQueryVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
