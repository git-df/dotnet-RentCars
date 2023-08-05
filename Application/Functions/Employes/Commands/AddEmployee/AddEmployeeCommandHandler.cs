using Application.Contracts.Persistence;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Employes.Commands.AddEmployee
{
    public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommand, BaseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserEmployeeRepository _userEmployeeRepository;
        private readonly IUserAppRepository _userAppRepository;

        public AddEmployeeCommandHandler(IMapper mapper, IUserEmployeeRepository userEmployeeRepository, IUserAppRepository userAppRepository)
        {
            _userEmployeeRepository = userEmployeeRepository;
            _mapper = mapper;
            _userAppRepository = userAppRepository;
        }

        public async Task<BaseResponse> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _userEmployeeRepository.GetEmployeeByUserId(request.UserId);

            if (employee != null)
                return new BaseResponse("Ten użytkownik jest pracownikiem", false);

            var user = await _userAppRepository.GetById(request.UserId);

            if (user == null)
                return new BaseResponse("Brak użytkownika o takim id", false);

            var data = await _userEmployeeRepository.Add(new UserEmployee()
            {
                IsAdmin = request.IsAdmin,
                UserAppId = request.UserId
            });

            if (data == null || !(data.Id > 0))
                return new BaseResponse("Nie udało się dodać pracownika", false);

            return new BaseResponse("Pracownik został dodany");
        }
    }
}
