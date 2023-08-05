using UI.Services;

namespace UI.Interfaces
{
    public interface IUserService
    {
        Task<GetMenuVMListBaseResponse> GetMenu();
        Task<GetProfileQueryVMBaseResponse> GetProfile();
        Task<GetUsersNoEmployeeQueryVMListBaseResponse> GetUsersNoEmployee(GetUsersNoEmployeeQuery requestModel);
        Task<BaseResponse> EditProfile(EditProfileCommand requestModel);
    }
}
