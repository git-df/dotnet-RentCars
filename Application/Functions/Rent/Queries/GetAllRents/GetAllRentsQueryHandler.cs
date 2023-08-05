using Application.Contracts.Persistence;
using Application.Functions.Rent.Queries.GetMyRents;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Rent.Queries.GetAllRents
{
    public class GetAllRentsQueryHAndler : IRequestHandler<GetAllRentsQuery, BaseResponse<List<GetAllRentsQueryVM>>>
    {
        IMapper _mapper;
        IRentRepository _rentRepository;

        public GetAllRentsQueryHAndler(IMapper mapper, IRentRepository rentRepository)
        {
            _mapper = mapper;
            _rentRepository = rentRepository;
        }

        public async Task<BaseResponse<List<GetAllRentsQueryVM>>> Handle(GetAllRentsQuery request, CancellationToken cancellationToken)
        {
            var data = await _rentRepository.GetAllRents(request.Page, request.PageSize, request.Search);

            if (data == null || !data.Any())
                return new BaseResponse<List<GetAllRentsQueryVM>>("Brak zamówień", false);

            var dataCount = await _rentRepository.GetAllRentsCount(request.Search);

            return new BaseResponse<List<GetAllRentsQueryVM>>
                (_mapper.Map<List<GetAllRentsQueryVM>>(data), dataCount);
        }
    }
}
