using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Employes.Commands.AddEmployee
{
    public class AddEmployeeCommand : IRequest<BaseResponse>
    {
        public int UserId { get; set; }
        public bool IsAdmin { get; set; } = false;
    }
}
