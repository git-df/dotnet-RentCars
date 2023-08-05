using UI.Services;

namespace UI.Interfaces.Security
{
    public interface IAuthService
    {
        Task<StringBaseResponse> SignIn(SignInCommand requestModel);
        Task<BaseResponse> SignUp(SignUpCommand requestModel);
        Task<BaseResponse> PasswordChange(PasswordChangeCommand requestModel);
        Task<GetUserAuthInfoVMBaseResponse> GetUserAuthInfo();
        Task SignOut();
    }
}
