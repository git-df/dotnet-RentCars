using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Models.Commands.RemoveModel
{
    public class RemoveModelCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }
    }
}
