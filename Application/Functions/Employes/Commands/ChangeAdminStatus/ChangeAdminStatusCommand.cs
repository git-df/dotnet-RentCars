using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Employes.Commands.ChangeAdminStatus
{
    public class ChangeAdminStatusCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }
        public bool IsAdmin { get; set; }
    }
}
