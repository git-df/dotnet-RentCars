using Application.Contracts.Persistence;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Models.Queries.GetModelsList
{
    public class GetModelsListQueryHandler : IRequestHandler<GetModelsListQuery, BaseResponse<List<GetModelsListQueryVM>>>
    {
        private readonly IMapper _mapper;
        private readonly ICarModelRepository _carModelRepository;

        public GetModelsListQueryHandler(IMapper mapper, ICarModelRepository carModelRepository)
        {
            _carModelRepository = carModelRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<List<GetModelsListQueryVM>>> Handle(GetModelsListQuery request, CancellationToken cancellationToken)
        {
            var data = await _carModelRepository.GetModelsWithCarCounts(request.Page, request.PageSize, request.Search);

            if (data == null || !data.Any())
                return new BaseResponse<List<GetModelsListQueryVM>>("Brak modeli", false);

            var dataCount = await _carModelRepository.GetSearchModelsCount(request.Search);

            return new BaseResponse<List<GetModelsListQueryVM>>(
                _mapper.Map<List<GetModelsListQueryVM>>(data), dataCount);
        }
    }
}
