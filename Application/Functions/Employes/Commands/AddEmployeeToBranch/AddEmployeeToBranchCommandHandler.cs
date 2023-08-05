using Application.Contracts.Persistence;
using Application.Functions.Employes.Queries.GetBranchEmployes;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Employes.Commands.AddEmployeeToBranch
{
    public class AddEmployeeToBranchCommandHandler : IRequestHandler<AddEmployeeToBranchCommand, BaseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserEmployeeRepository _userEmployeeRepository;
        private readonly IBranchRepository _branchRepository;
        private readonly IUserEmployee2BranchRepository _userEmployee2BranchRepository;

        public AddEmployeeToBranchCommandHandler(IMapper mapper, IUserEmployeeRepository userEmployeeRepository, IBranchRepository branchRepository, IUserEmployee2BranchRepository userEmployee2BranchRepository)
        {
            _userEmployeeRepository = userEmployeeRepository;
            _mapper = mapper;
            _branchRepository = branchRepository;
            _userEmployee2BranchRepository = userEmployee2BranchRepository;
        }

        public async Task<BaseResponse> Handle(AddEmployeeToBranchCommand request, CancellationToken cancellationToken)
        {
            if (!(request.EmployeeId > 0) || !(request.BranchId > 0))
                return new BaseResponse("Błędne Id", false);

            var userEmployee2Branch = await _userEmployee2BranchRepository.GetByIds(request.EmployeeId, request.BranchId);

            if (userEmployee2Branch != null)
                return new BaseResponse("Pracownik jest już przypisany do tego oddziału", false);

            var employe = await _userEmployeeRepository.GetById(request.EmployeeId);

            if (employe == null)
                return new BaseResponse("Nie ma pracownika z takim Id", false);

            var branch = await _branchRepository.GetById(request.BranchId);

            if (branch == null)
                return new BaseResponse("Nie ma oddziału z takim Id", false);

            var data = await _userEmployee2BranchRepository.Add(new Domain.Entities.UserEmployee2Branch()
            {
                BranchId = request.BranchId,
                UserEmployeeId = request.EmployeeId
            });

            if (data == null || !(data.Id > 0))
                return new BaseResponse("Nie udało się dodać pracownika do oddziału", false);

            return new BaseResponse("Pracownik został dodany do oddziału");
        }
    }
}
