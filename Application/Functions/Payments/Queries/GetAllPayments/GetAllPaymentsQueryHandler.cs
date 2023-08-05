using Application.Contracts.Persistence;
using Application.Functions.Rent.Queries.GetAllRents;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Payments.Queries.GetAllPayments
{
    public class GetAllPaymentsQueryHandler : IRequestHandler<GetAllPaymentsQuery, BaseResponse<List<GetAllPaymentsQueryVM>>>
    {
        private readonly IMapper _mapper;
        private readonly IPaymentRepository _paymentRepository;

        public GetAllPaymentsQueryHandler(IMapper mapper, IPaymentRepository paymentRepository)
        {
            _mapper = mapper;
            _paymentRepository = paymentRepository;
        }

        public async Task<BaseResponse<List<GetAllPaymentsQueryVM>>> Handle(GetAllPaymentsQuery request, CancellationToken cancellationToken)
        {
            var data = await _paymentRepository.GetAllPayments(request.Page, request.PageSize, request.Search);

            if (data == null || !data.Any())
                return new BaseResponse<List<GetAllPaymentsQueryVM>>("Brak płatności", false);

            var dataCount = await _paymentRepository.GetAllPaymentsCount(request.Search);

            return new BaseResponse<List<GetAllPaymentsQueryVM>>
                (_mapper.Map<List<GetAllPaymentsQueryVM>>(data), dataCount);
        }
    }
}
