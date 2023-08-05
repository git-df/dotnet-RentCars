using AutoMapper;
using UI.Interfaces;
using UI.Interfaces.Security;

namespace UI.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IMapper _mapper;
        private readonly IClient _client;
        private readonly IAddBearerTokenService _addBearerTokenService;

        public PaymentService(IMapper mapper, IClient client, IAddBearerTokenService addBearerTokenService)
        {
            _addBearerTokenService = addBearerTokenService;
            _mapper = mapper;
            _client = client;
        }

        public async Task<GetAllPaymentsQueryVMListBaseResponse> GetAllPayments(GetAllPaymentsQuery requestModel)
        {
            try
            {
                await _addBearerTokenService.AddBearerToken(_client);

                return await _client.GetAllPaymentsAsync(requestModel);
            }
            catch (Exception ex)
            {
                return new GetAllPaymentsQueryVMListBaseResponse() { Message = ex.Message, Success = false };
            }
        }

        public async Task<GetMyPaymentsQueryVMListBaseResponse> GetMyPayments(GetMyPaymentsQuery requestModel)
        {
            try
            {
                await _addBearerTokenService.AddBearerToken(_client);

                return await _client.GetMyPaymentsAsync(requestModel);
            }
            catch (Exception ex)
            {
                return new GetMyPaymentsQueryVMListBaseResponse() { Message = ex.Message, Success = false };
            }
        }

        public async Task<BaseResponse> Pay(PayCommand requestModel)
        {
            try
            {
                await _addBearerTokenService.AddBearerToken(_client);

                return await _client.PayAsync(requestModel);
            }
            catch (Exception ex)
            {
                return new BaseResponse() { Message = ex.Message, Success = false };
            }
        }
    }
}
