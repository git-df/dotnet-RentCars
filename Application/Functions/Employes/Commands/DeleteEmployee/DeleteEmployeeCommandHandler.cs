using Application.Contracts.Persistence;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Employes.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, BaseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserEmployeeRepository _userEmployeeRepository;
        private readonly IUserEmployee2BranchRepository _userEmployee2BranchRepository;

        public DeleteEmployeeCommandHandler(IMapper mapper, IUserEmployeeRepository userEmployeeRepository, IUserEmployee2BranchRepository userEmployee2BranchRepository)
        {
            _mapper = mapper;
            _userEmployeeRepository = userEmployeeRepository;
            _userEmployee2BranchRepository = userEmployee2BranchRepository;
        }

        public async Task<BaseResponse> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _userEmployeeRepository.GetById(request.Id);

            if (employee == null)
                return new BaseResponse("Nie ma pracownika z takim Id", false);

            await _userEmployee2BranchRepository.DeleteRangeByEmployeeId(employee.Id);
            await _userEmployeeRepository.Delete(employee);

            return new BaseResponse("Usunięto pracownika");
        }
    }
}
