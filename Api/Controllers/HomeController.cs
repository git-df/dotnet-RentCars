using Application.Functions.Branches.Queries.GetContacts;
using Application.Functions.Cars.Queries.GetCar;
using Application.Functions.Cars.Queries.GetCars;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<BaseResponse<List<GetContactsQueryVM>>> GetContacts()
        {
            var request = new GetContactsQuery();
            return await _mediator.Send(request);
        }

        [HttpPost]
        public async Task<BaseResponse<List<GetCarsQueryVM>>> GetCars([FromBody] GetCarsQuery request)
        {
            return await _mediator.Send(request);
        }

        [HttpPost]
        public async Task<BaseResponse<GetCarQueryVM>> GetCar([FromBody] GetCarQuery request)
        {
            return await _mediator.Send(request);
        }
    }
}
