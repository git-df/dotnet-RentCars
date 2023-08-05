using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Users.Queries.GetUsersNoEmployee
{
    public class GetUsersNoEmployeeQueryVM
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public UserInfoInGetUsersNoEmployeeQueryVM UserInfo { get; set; }
    }

    public class UserInfoInGetUsersNoEmployeeQueryVM
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
