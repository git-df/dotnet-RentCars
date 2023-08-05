using Application.Contracts.Persistence;
using Application.Functions.Auth.Commands.SignIn;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Branches.Commands.AddBranch
{
    internal class AddBranchCommandHandler : IRequestHandler<AddBranchCommand, BaseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBranchRepository _branchRepository;

        public AddBranchCommandHandler(IMapper mapper, IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse> Handle(AddBranchCommand request, CancellationToken cancellationToken)
        {
            var validator = new AddBranchCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                return new BaseResponse(validationResult);

            var data = await _branchRepository.Add(
                _mapper.Map<Branch>(request));

            if (data == null || !(data.Id > 0) )
                return new BaseResponse("Nie udało się dodać oddziału", false);

            return new BaseResponse("Oddział został dodany");
        }
    }
}
