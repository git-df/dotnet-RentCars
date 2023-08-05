using Application.Functions.Models.Commands.AddModel;
using Application.Functions.Models.Commands.EditModel;
using Application.Functions.Models.Commands.RemoveModel;
using Application.Functions.Models.Queries.GetModelsList;
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
    public class CarModelController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarModelController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<BaseResponse<List<GetModelsListQueryVM>>> GetModelsList([FromBody] GetModelsListQuery request) 
        {
            return await _mediator.Send(request);
        }

        [HttpPut]
        public async Task<BaseResponse> AddModel([FromBody] AddModelCommand request) 
        {
            return await _mediator.Send(request);
        }

        [HttpPatch]
        public async Task<BaseResponse> EditModel([FromBody] EditModelCommand request) 
        {
            return await _mediator.Send(request);
        }

        [HttpDelete]
        public async Task<BaseResponse> RemoveModel([FromBody] RemoveModelCommand request)
        {
            return await _mediator.Send(request);
        }
    }
}
