using Application.Functions.Branches.Commands.AddBranch;
using Application.Functions.Branches.Commands.DeleteBranch;
using Application.Functions.Branches.Commands.EditBranch;
using Application.Functions.Branches.Queries.GetBranchDetails;
using Application.Functions.Branches.Queries.GetBranches;
using Application.Functions.Employes.Commands.AddEmployeeToBranch;
using Application.Functions.Employes.Commands.RemoveEmployeeFromBranch;
using Application.Functions.Employes.Queries.GetBranchEmployes;
using Application.Functions.Employes.Queries.GetEmployesNoInBranch;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BranchesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BranchesController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<BaseResponse<List<GetBranchesQueryVM>>> GetBranches([FromBody] GetBranchesQuery request)
        {
            return await _mediator.Send(request);
        }

        [HttpPost]
        public async Task<BaseResponse<GetBranchDetailsQueryVM>> GetBranchDetails([FromBody] GetBranchDetailsQuery request)
        {
            return await _mediator.Send(request);
        }

        [HttpPatch]
        public async Task<BaseResponse> EditBranch([FromBody] EditBranchCommand request)
        {
            return await _mediator.Send(request);
        }

        [HttpPut]
        public async Task<BaseResponse> AddBranch([FromBody] AddBranchCommand request)
        {
            return await _mediator.Send(request);
        }

        [HttpDelete]
        public async Task<BaseResponse> DeleteBranch([FromBody] DeleteBranchCommand request)
        {
            return await _mediator.Send(request);
        }

        [HttpPost]
        public async Task<BaseResponse<List<GetBranchEmployesQueryVM>>> GetBranchEmployes([FromBody] GetBranchEmployesQuery request)
        {
            return await _mediator.Send(request);
        }

        [HttpPut]
        public async Task<BaseResponse> AddEmployeeToBranch([FromBody] AddEmployeeToBranchCommand request)
        {
            return await _mediator.Send(request);
        }

        [HttpDelete]
        public async Task<BaseResponse> RemoveEmployeeFromBranch([FromBody] RemoveEmployeeFromBranchCommand request)
        {
            return await _mediator.Send(request);
        }

        [HttpPost]
        public async Task<BaseResponse<List<GetEmployesNoInBranchQueryVM>>> GetEmployesNoInBranch([FromBody] GetEmployesNoInBranchQuery request)
        {
            return await _mediator.Send(request);
        }
    }
}
