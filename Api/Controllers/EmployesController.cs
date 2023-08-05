using Application.Functions.Employes.Commands.AddEmployee;
using Application.Functions.Employes.Commands.ChangeAdminStatus;
using Application.Functions.Employes.Commands.DeleteEmployee;
using Application.Functions.Employes.Queries.GetEmployes;
using Application.Functions.Users.Queries.GetUsersNoEmployee;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Api.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployesController( IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<BaseResponse<List<GetEmployesQueryVM>>> GetEmployes([FromBody] GetEmployesQuery request)
        {
            return await _mediator.Send(request);
        }

        [HttpPost]
        public async Task<BaseResponse> ChangeAdminStatus([FromBody] ChangeAdminStatusCommand request)
        {
            return await _mediator.Send(request);
        }

        [HttpPost]
        public async Task<BaseResponse<List<GetUsersNoEmployeeQueryVM>>> GetUsersNoEmployee([FromBody] GetUsersNoEmployeeQuery request)
        {
            return await _mediator.Send(request);
        }

        [HttpPut]
        public async Task<BaseResponse> AddEmployee([FromBody] AddEmployeeCommand request)
        {
            return await _mediator.Send(request);
        }

        [HttpDelete]
        public async Task<BaseResponse> DeleteEmployee([FromBody] DeleteEmployeeCommand request)
        {
            return await _mediator.Send(request);
        }
    }
}
