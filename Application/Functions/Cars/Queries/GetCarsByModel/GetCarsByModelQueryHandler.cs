using Application.Contracts.Persistence;
using Application.Functions.Models.Queries.GetModelsList;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Cars.Queries.GetCarsByModel
{
    public class GetCarsByModelQueryHandler : IRequestHandler<GetCarsByModelQuery, BaseResponse<List<GetCarsByModelQueryVM>>>
    {
        private readonly IMapper _mapper;
        private readonly ICarRepository _carRepository;

        public GetCarsByModelQueryHandler(IMapper mapper, ICarRepository carRepository)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<List<GetCarsByModelQueryVM>>> Handle(GetCarsByModelQuery request, CancellationToken cancellationToken)
        {
            if (!(request.ModelId > 0))
                return new BaseResponse<List<GetCarsByModelQueryVM>>("Błędne Id", false);

            var data = await _carRepository.GetCarsByModelId(request.ModelId ,request.Page, request.PageSize, request.Search);

            if (data == null || !data.Any())
                return new BaseResponse<List<GetCarsByModelQueryVM>>("Brak samochodów", false);

            var dataCount = await _carRepository.GetCarsByModelIdCount(request.ModelId, request.Search);

            return new BaseResponse<List<GetCarsByModelQueryVM>>(
                _mapper.Map<List<GetCarsByModelQueryVM>>(data), dataCount);
        }
    }
}
