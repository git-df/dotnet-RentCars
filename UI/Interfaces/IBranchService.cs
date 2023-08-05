using UI.Services;

namespace UI.Interfaces
{
    public interface IBranchService
    {
        Task<GetBranchesQueryVMListBaseResponse> GetBranches(GetBranchesQuery requestModel);
        Task<GetBranchDetailsQueryVMBaseResponse> GetBranchDetails(GetBranchDetailsQuery requestModel);
        Task<BaseResponse> EditBranch(EditBranchCommand requestModel);
        Task<BaseResponse> AddBranch(AddBranchCommand requestModel);
        Task<GetBranchEmployesQueryVMListBaseResponse> GetBranchEmployes(GetBranchEmployesQuery requestModel);
        Task<BaseResponse> RemoveEmployeeFromBranch(RemoveEmployeeFromBranchCommand requestModel);
        Task<BaseResponse> AddEmployeeToBranch(AddEmployeeToBranchCommand requestModel);
        Task<GetEmployesNoInBranchQueryVMListBaseResponse> GetEmployesNoInBranch(GetEmployesNoInBranchQuery requestModel);
        Task<BaseResponse> DeleteBranch(DeleteBranchCommand requestModel);
    }
}
