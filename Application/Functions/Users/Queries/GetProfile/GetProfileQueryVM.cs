using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Users.Queries.GetProfile
{
    public class GetProfileQueryVM
    {
        public int Id { get; set; }
        public string Email { get; set; }

        public UserInfoInGetProfileQueryVM UserInfo { get; set; }
    }

    public class UserInfoInGetProfileQueryVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string PESEL { get; set; }
    }
}
