using UI.Services;

namespace UI.Interfaces
{
    public interface IRentService
    {
        Task<GetRentOptionsQueryVMListBaseResponse> GetRentOptions(GetRentOptionsQuery requestModel);
        Task<GetBranchesWithOffertsQueryVMListBaseResponse> GetBranchesWithOfferts();
        Task<GetRentOptionsDetailsQueryVMBaseResponse> GetRentOptionsDetails(GetRentOptionsDetailsQuery requestModel);
        Task<BaseResponse> AddRent(AddRentCommand requestModel);
        Task<GetMyRentsQueryVMListBaseResponse> GetMyRents(GetMyRentsQuery requestModel);
        Task<GetAllRentsQueryVMListBaseResponse> GetAllRents(GetAllRentsQuery requestModel);
        Task<BaseResponse> DeleteRent(DeleteRentCommand requestModel);
        Task<BaseResponse> ConfirmRent(ConfirmRentCommand requestModel);
        Task<BaseResponse> NoConfirmRent(NoConfirmRentCommand requestModel);
        Task<BaseResponse> DoneRent(DoneRentCommand requestModel);
    }
}
