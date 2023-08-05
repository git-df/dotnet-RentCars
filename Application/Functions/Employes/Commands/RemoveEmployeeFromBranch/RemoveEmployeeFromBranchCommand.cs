using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Employes.Commands.RemoveEmployeeFromBranch
{
    public class RemoveEmployeeFromBranchCommand : IRequest<BaseResponse>
    {
        public int EmployeeId { get; set; }
        public int BranchId { get; set; }
    }
}
