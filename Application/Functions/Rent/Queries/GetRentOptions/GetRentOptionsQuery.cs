using Application.Functions.Common;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Rent.Queries.GetRentOptions
{
    public class GetRentOptionsQuery : ListRequestOptions, IRequest<BaseResponse<List<GetRentOptionsQueryVM>>>
    {
        public int BranchId { get; set; } = 0;
        public string OrderBy { get; set; } = "Price";
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
