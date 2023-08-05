using UI.Services;

namespace UI.Interfaces
{
    public interface IEmployeeService
    {
        Task<GetEmployesQueryVMListBaseResponse> GetEmployes(GetEmployesQuery requestModel);
        Task<BaseResponse> DeleteEmployee(DeleteEmployeeCommand requestModel);
        Task<BaseResponse> ChangeAdminStatus(ChangeAdminStatusCommand requestModel);
        Task<BaseResponse> AddEmployee(AddEmployeeCommand requestModel);
        
    }
}
