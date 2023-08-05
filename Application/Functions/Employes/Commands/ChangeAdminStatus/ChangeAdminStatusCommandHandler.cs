using Application.Contracts.Persistence;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Employes.Commands.ChangeAdminStatus
{
    public class ChangeAdminStatusCommandHandler : IRequestHandler<ChangeAdminStatusCommand, BaseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserEmployeeRepository _userEmployeeRepository;

        public ChangeAdminStatusCommandHandler(IMapper mapper, IUserEmployeeRepository userEmployeeRepository)
        {
            _mapper = mapper;
            _userEmployeeRepository = userEmployeeRepository;
        }

        public async Task<BaseResponse> Handle(ChangeAdminStatusCommand request, CancellationToken cancellationToken)
        {
            var employee = await _userEmployeeRepository.GetById(request.Id);

            if (employee == null)
                return new BaseResponse("Nie ma pracownika z takim Id", false);

            employee.IsAdmin = request.IsAdmin;

            await _userEmployeeRepository.Update(employee);

            return new BaseResponse("Edytowano pracownika");
        }
    }
}
