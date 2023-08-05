using Application.Contracts.Persistence;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Branches.Queries.GetContacts
{
    public class GetContactsQueryHandler : IRequestHandler<GetContactsQuery, BaseResponse<List<GetContactsQueryVM>>>
    {
        private readonly IMapper _mapper;
        private readonly IBranchRepository _branchRepository;

        public GetContactsQueryHandler(IMapper mapper, IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<List<GetContactsQueryVM>>> Handle(GetContactsQuery request, CancellationToken cancellationToken)
        {
            var data = await _branchRepository.GetBranchesWithAdresses();

            if (data == null || !data.Any())
                return new BaseResponse<List<GetContactsQueryVM>>("Brak kontaktów", false);

            return new BaseResponse<List<GetContactsQueryVM>>(
                _mapper.Map<List<GetContactsQueryVM>>(data));
        }
    }
}
