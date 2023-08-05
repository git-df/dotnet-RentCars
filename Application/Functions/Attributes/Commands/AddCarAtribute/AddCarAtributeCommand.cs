using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Attributes.Commands.AddCarAtribute
{
    public class AddCarAtributeCommand : IRequest<BaseResponse>
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public int CarId { get; set; }
    }
}
