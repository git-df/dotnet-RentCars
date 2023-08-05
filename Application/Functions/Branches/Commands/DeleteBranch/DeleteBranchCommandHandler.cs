using Application.Contracts.Persistence;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Branches.Commands.DeleteBranch
{
    public class DeleteBranchCommandHandler : IRequestHandler<DeleteBranchCommand, BaseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBranchRepository _branchRepository;
        private readonly IAddressRepository _addressRepository;

        public DeleteBranchCommandHandler(IMapper mapper, IBranchRepository branchRepository, IAddressRepository addressRepository)
        {
            _branchRepository = branchRepository;
            _mapper = mapper;
            _addressRepository = addressRepository;
        }

        public async Task<BaseResponse> Handle(DeleteBranchCommand request, CancellationToken cancellationToken)
        {
            if (!(request.Id > 0))
                return new BaseResponse("Błędne Id", false);

            var data = await _branchRepository.GetBranchByIdWithAllReferences(request.Id);

            if (data == null)
                return new BaseResponse("Brak oddziału z takim Id", false);

            if (data.Offers.Count > 0)
                return new BaseResponse("Ten oddział posiada oferty", false);

            if (data.UserEmployee2Branches.Count > 0)
                return new BaseResponse("Ten oddział posiada pracowników", false);

            await _branchRepository.Delete(data);

            if (data.Address != null)
            {
                await _addressRepository.Delete(data.Address);
            }

            return new BaseResponse("Usunięto oddział");
        }
    }
}
