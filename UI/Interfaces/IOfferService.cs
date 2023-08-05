using UI.Services;

namespace UI.Interfaces
{
    public interface IOfferService
    {
        Task<GetOffersQueryVMListBaseResponse> GetOffers(GetOffersQuery requestModel);
        Task<BaseResponse> AddOffer(AddOfferCommand requestModel);
        Task<BaseResponse> EditOffer(EditOfferCommand requestModel);
        Task<BaseResponse> DeleteOffer(DeleteOfferCommand requestModel);
        Task<GetCarsToOfferQueryVMListBaseResponse> GetCarsToOffer();
        Task<GetBranchesToOfferQueryVMListBaseResponse> GetBranchesToOffer();
    }
}
