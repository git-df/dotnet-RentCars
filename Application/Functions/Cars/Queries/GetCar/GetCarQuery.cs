using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Cars.Queries.GetCar
{
    public class GetCarQuery : IRequest<BaseResponse<GetCarQueryVM>>
    {
        public int CarId { get; set; }
    }
}
