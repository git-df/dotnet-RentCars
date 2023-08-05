using Application.Functions.Users.Queries.GetProfile;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Users.Commands.EditProfile
{
    public class EditProfileCommand : IRequest<BaseResponse>
    {
        public int Id { get; private set; }
        public UserInfoInEditProfileCommand UserInfo { get; set; }

        public void SetId(int id)
        {
            Id = id;
        }
    }

    public class UserInfoInEditProfileCommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string PESEL { get; set; }
    }
}
