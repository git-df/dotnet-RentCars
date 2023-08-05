using Application.Contracts.Persistence;
using Application.Functions.Offers.Commands.AddOffer;
using Application.Functions.Rent.Queries.GetBranchesWithOfferts;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Rent.Queries.GetRentOptions
{
    public class GetRentOptionsQueryHandler : IRequestHandler<GetRentOptionsQuery, BaseResponse<List<GetRentOptionsQueryVM>>>
    {
        private readonly IMapper _mapper;
        private readonly ICarRepository _carRepository;

        public GetRentOptionsQueryHandler(IMapper mapper, ICarRepository carRepository)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<List<GetRentOptionsQueryVM>>> Handle(GetRentOptionsQuery request, CancellationToken cancellationToken)
        {
            if (!(request.BranchId >= 0))
                return new BaseResponse<List<GetRentOptionsQueryVM>>("Błędne Id", false);

            var validator = new GetRentOptionsQueryValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                return new BaseResponse<List<GetRentOptionsQueryVM>>(validationResult);

            var data = await _carRepository.GetRentOptions(request.BranchId, request.DateFrom, request.DateTo, request.Search);

            if (data == null || !data.Any())
                return new BaseResponse<List<GetRentOptionsQueryVM>>("Brak ofert", false);

            var dataCount = data.Count();

            List<GetRentOptionsQueryVM> offers = new List<GetRentOptionsQueryVM>();

            foreach (var item in data)
            {
                offers.Add(new GetRentOptionsQueryVM()
                {
                    Id = item.Id,
                    CarsModel = new CarsModelInGetRentOptionsQueryVM()
                    {
                        BrandName = item.CarsModel.BrandName,
                        ModelName = item.CarsModel.ModelName,
                        Id = item.CarsModel.Id
                    },
                    Year = item.Year,
                    Image = item.Image,
                    BestPrice = request.BranchId == 0 
                        ? item.Offers.Min(x => RentPriceCalcHandler.CalcPrice(request.DateFrom, request.DateTo, x.PricePerHour, x.PricePreDay)) 
                        : item.Offers.Where(x => x.BranchId == request.BranchId).Min(x => RentPriceCalcHandler.CalcPrice(request.DateFrom, request.DateTo, x.PricePerHour, x.PricePreDay))
                });
            }

            if (!string.IsNullOrEmpty(request.OrderBy))
            {
                switch (request.OrderBy)
                {
                    case "Price": offers = offers.OrderBy(e => e.BestPrice).ToList(); break;
                    case "PriceDesc": offers = offers.OrderByDescending(e => e.BestPrice).ToList(); break;
                    case "Name": offers = offers.OrderBy(e => e.CarsModel.BrandName + e.CarsModel.ModelName).ToList(); break;
                    case "NameDesc": offers = offers.OrderByDescending(e => e.CarsModel.BrandName + e.CarsModel.ModelName).ToList(); break;
                }
            }

            return new BaseResponse<List<GetRentOptionsQueryVM>>(
                offers.Skip(request.PageSize * (request.Page - 1)).Take(request.PageSize).ToList(), dataCount);
        }
    }
}
