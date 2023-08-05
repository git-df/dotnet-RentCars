using Application.Functions.Cars.Commands.AddCar;
using Application.Functions.Cars.Commands.ChangeImage;
using Application.Functions.Cars.Commands.EditCar;
using Application.Functions.Cars.Commands.RemoveCar;
using Application.Functions.Cars.Queries.GetCarDetails;
using Application.Functions.Cars.Queries.GetCarsByModel;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Api.Controllers
{
    [Authorize(Roles = "Employee, Admin")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<BaseResponse<List<GetCarsByModelQueryVM>>> GetCarsByModel([FromBody] GetCarsByModelQuery request) 
        {
            return await _mediator.Send(request);
        }

        [HttpPost]
        public async Task<BaseResponse<GetCarDetailsQueryVM>> GetCarDetails([FromBody] GetCarDetailsQuery request) 
        {
            return await _mediator.Send(request);
        }

        [HttpPut]
        public async Task<BaseResponse<int>> AddCar([FromBody] AddCarCommand request) 
        {
            return await _mediator.Send(request);
        }

        [HttpPatch]
        public async Task<BaseResponse> EditCar([FromBody] EditCarCommand request) 
        {
            return await _mediator.Send(request);
        }

        [HttpDelete]
        public async Task<BaseResponse> RemoveCar([FromBody] RemoveCarCommand request) 
        {
            return await _mediator.Send(request);
        }

        [HttpPatch]
        public async Task<BaseResponse> ChangeImage([FromBody] ChangeImageCommand request)
        {
            return await _mediator.Send(request);
        }
    }
}
