using Application.Functions.Attributes.Commands.AddCarAtribute;
using Application.Functions.Attributes.Commands.EditCarAttribute;
using Application.Functions.Attributes.Commands.RemoveCarAtribute;
using Application.Functions.Attributes.Queries.GetCarAtributesByCar;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Api.Controllers
{
    [Authorize(Roles = "Admin, Employee")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarAttributeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarAttributeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<BaseResponse<List<GetCarAtributesByCarQueryVM>>> GetCarAtributesByCar([FromBody] GetCarAtributesByCarQuery request) 
        {
            return await _mediator.Send(request);
        }

        [HttpPut]
        public async Task<BaseResponse> AddCarAtribute([FromBody] AddCarAtributeCommand request) 
        {
            return await _mediator.Send(request);
        }

        [HttpDelete]
        public async Task<BaseResponse> RemoveCarAtribute([FromBody] RemoveCarAtributeCommand request) 
        {
            return await _mediator.Send(request);
        }

        [HttpPatch]
        public async Task<BaseResponse> EditCarAtribute([FromBody] EditCarAtributeCommand request)
        {
            return await _mediator.Send(request);
        }
    }
}
