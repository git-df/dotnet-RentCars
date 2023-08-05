using Application.Contracts.Persistence;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Cars.Queries.GetCars
{
    public class GetCarsQueryHandler : IRequestHandler<GetCarsQuery, BaseResponse<List<GetCarsQueryVM>>>
    {
        private readonly IMapper _mapper;
        private readonly ICarRepository _carRepository;

        public GetCarsQueryHandler(IMapper mapper, ICarRepository carRepository)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<List<GetCarsQueryVM>>> Handle(GetCarsQuery request, CancellationToken cancellationToken)
        {
            var data = await _carRepository.GetCarsWithModels(request.Page, request.PageSize, request.Search);

            if (data == null || !data.Any())
                return new BaseResponse<List<GetCarsQueryVM>>("Brak samochodów", false);

            var dataCount = await _carRepository.GetSearchCarsCount(request.Search);

            var a = _mapper.Map<List<GetCarsQueryVM>>(data).OrderBy(d => d.Name).ToList();

            return new BaseResponse<List<GetCarsQueryVM>>(
                _mapper.Map<List<GetCarsQueryVM>>(data).OrderBy(d => d.Name).ToList(), dataCount);
        }
    }
}
