using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Rent.Queries.GetRentOptionsDetails
{
    public class GetRentOptionsDetailsQuery : IRequest<BaseResponse<GetRentOptionsDetailsQueryVM>>
    {
        public int CarId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
