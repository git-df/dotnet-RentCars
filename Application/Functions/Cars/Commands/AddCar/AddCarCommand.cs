using Application.Responses;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Cars.Commands.AddCar
{
    public class AddCarCommand : IRequest<BaseResponse<int>>
    {
        public string PlaceNumber { get; set; }
        public string VIN { get; set; }
        public string Fuel { get; set; }
        public int Year { get; set; }
        public string Image { get; set; }
        public int CarsModelId { get; set; }
    }
}
