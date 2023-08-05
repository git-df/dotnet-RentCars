using Application.Contracts.Persistence;
using Application.Functions.Rent.Queries.GetMyRents;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Payments.Queries.GetMyPayments
{
    public class GetMyPaymentsQueryHandler : IRequestHandler<GetMyPaymentsQuery, BaseResponse<List<GetMyPaymentsQueryVM>>>
    {
        private readonly IMapper _mapper;
        private readonly IPaymentRepository _paymentRepository;

        public GetMyPaymentsQueryHandler(IMapper mapper, IPaymentRepository paymentRepository)
        {
            _mapper = mapper;
            _paymentRepository = paymentRepository;
        }

        public async Task<BaseResponse<List<GetMyPaymentsQueryVM>>> Handle(GetMyPaymentsQuery request, CancellationToken cancellationToken)
        {
            if (!(request.Id >= 0))
                return new BaseResponse<List<GetMyPaymentsQueryVM>>("Błędne Id", false);

            var data = await _paymentRepository.GetPaymentsByUserId(request.Id, request.Page, request.PageSize, request.Search);

            if (data == null || !data.Any())
                return new BaseResponse<List<GetMyPaymentsQueryVM>>("Brak płatności", false);

            var dataCount = await _paymentRepository.GetPaymentsByUserIdCount(request.Id, request.Search);

            return new BaseResponse<List<GetMyPaymentsQueryVM>>
                (_mapper.Map<List<GetMyPaymentsQueryVM>>(data), dataCount);
        }
    }
}
