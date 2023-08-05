using UI.Services;

namespace UI.Interfaces
{
    public interface IPaymentService
    {
        Task<GetMyPaymentsQueryVMListBaseResponse> GetMyPayments(GetMyPaymentsQuery requestModel);
        Task<GetAllPaymentsQueryVMListBaseResponse> GetAllPayments(GetAllPaymentsQuery requestModel);
        Task<BaseResponse> Pay(PayCommand requestModel);
    }
}
