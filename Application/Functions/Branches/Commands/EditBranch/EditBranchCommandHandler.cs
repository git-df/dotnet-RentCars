using Application.Contracts.Persistence;
using Application.Functions.Branches.Commands.AddBranch;
using Application.Functions.Branches.Queries.GetBranchDetails;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Functions.Branches.Commands.EditBranch
{
    public class EditBranchCommandHandler : IRequestHandler<EditBranchCommand, BaseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBranchRepository _branchRepository;
        private readonly IAddressRepository _addressRepository;

        public EditBranchCommandHandler(IMapper mapper, IBranchRepository branchRepository, IAddressRepository addressRepository)
        {
            _branchRepository = branchRepository;
            _mapper = mapper;
            _addressRepository = addressRepository;
        }

        public async Task<BaseResponse> Handle(EditBranchCommand request, CancellationToken cancellationToken)
        {
            if (!(request.Id > 0))
                return new BaseResponse("Błędne Id", false);

            var validator = new EditBranchCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                return new BaseResponse(validationResult);

            var data = await _branchRepository.GetBranchByIdWithAddress(request.Id);

            if (data == null)
                return new BaseResponse("Brak oddziału z takim Id", false);

            if (data.AddressId > 0)
            {
                data.Address.Country = request.Address.Country;
                data.Address.City = request.Address.City;
                data.Address.StreetWithNumber = request.Address.StreetWithNumber;
                data.Address.PostalCode = request.Address.PostalCode;

                await _addressRepository.Update(data.Address);
            }
            else
            {
                var address = new Address()
                {
                    Country = request.Address.Country,
                    City = request.Address.City,
                    StreetWithNumber = request.Address.StreetWithNumber,
                    PostalCode = request.Address.PostalCode
                };

                var newAddress = await _addressRepository.Add(address);
                data.AddressId = newAddress.Id;
            }

            data.Name = request.Name;
            data.PhoneNumber = request.PhoneNumber;

            await _branchRepository.Update(data);

            return new BaseResponse("Oddział został edytowany");
        }
    }
}
