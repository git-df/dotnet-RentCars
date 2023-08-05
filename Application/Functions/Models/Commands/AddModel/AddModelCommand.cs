using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Models.Commands.AddModel
{
    public class AddModelCommand : IRequest<BaseResponse>
    {
        public string BrandName { get; set; }
        public string ModelName { get; set; }
    }
}
