using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Employes.Queries.GetEmployes
{
    public class GetEmployesQueryVM
    {
        public int Id { get; set; }
        public bool IsAdmin { get; set; }
        public UserAppInGetEmployesQueryVM UserApp { get; set; }
    }

    public class UserAppInGetEmployesQueryVM
    {
        public string Email { get; set; }
        public UserInfoInGetEmployesQueryVM UserInfo { get; set; }
    }

    public class UserInfoInGetEmployesQueryVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
