using Application.Contracts.Persistence;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Rent.Queries.GetMyRents
{
    public class GetMyRentsQueryHandler : IRequestHandler<GetMyRentsQuery, BaseResponse<List<GetMyRentsQueryVM>>>
    {
        IMapper _mapper;
        IRentRepository _rentRepository;

        public GetMyRentsQueryHandler(IMapper mapper, IRentRepository rentRepository)
        {
            _mapper = mapper;
            _rentRepository = rentRepository;
        }

        public async Task<BaseResponse<List<GetMyRentsQueryVM>>> Handle(GetMyRentsQuery request, CancellationToken cancellationToken)
        {
            if (!(request.Id >= 0))
                return new BaseResponse<List<GetMyRentsQueryVM>>("Błędne Id", false);

            var data = await _rentRepository.GetRentsByUserId(request.Id, request.Page, request.PageSize, request.Search);

            if (data == null || !data.Any())
                return new BaseResponse<List<GetMyRentsQueryVM>>("Brak zamówień", false);

            var dataCount = await _rentRepository.GetRentsByUserIdCount(request.Id, request.Search);

            return new BaseResponse<List<GetMyRentsQueryVM>>
                (_mapper.Map<List<GetMyRentsQueryVM>>(data), dataCount);
        }
    }
}
