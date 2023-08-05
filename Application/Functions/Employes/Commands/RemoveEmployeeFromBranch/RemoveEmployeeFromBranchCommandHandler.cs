using Application.Contracts.Persistence;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Employes.Commands.RemoveEmployeeFromBranch
{
    public class RemoveEmployeeFromBranchCommandHandler : IRequestHandler<RemoveEmployeeFromBranchCommand, BaseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserEmployee2BranchRepository _userEmployee2BranchRepository;

        public RemoveEmployeeFromBranchCommandHandler(IMapper mapper, IUserEmployee2BranchRepository userEmployee2BranchRepository)
        {
            _mapper = mapper;
            _userEmployee2BranchRepository = userEmployee2BranchRepository;
        }

        public async Task<BaseResponse> Handle(RemoveEmployeeFromBranchCommand request, CancellationToken cancellationToken)
        {
            if (!(request.EmployeeId > 0) || !(request.BranchId > 0))
                return new BaseResponse("Błędne Id", false);

            var userEmployee2Branch = await _userEmployee2BranchRepository.GetByIds(request.EmployeeId, request.BranchId);

            if (userEmployee2Branch == null)
                return new BaseResponse("Pracownik nie jest przypisany do tego oddziału", false);

            await _userEmployee2BranchRepository.Delete(userEmployee2Branch);

            return new BaseResponse("Usunięto pracownika z oddziału");
        }
    }
}
