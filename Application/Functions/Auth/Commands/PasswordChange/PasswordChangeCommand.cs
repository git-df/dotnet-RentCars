using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Auth.Commands.PasswordChange
{
    public class PasswordChangeCommand : IRequest<BaseResponse>
    {
        public int Id { get; private set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }

        public void SetId(int id)
        {
            Id = id;
        }
    }
}
