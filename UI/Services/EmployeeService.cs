using AutoMapper;
using UI.Interfaces;
using UI.Interfaces.Security;

namespace UI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IMapper _mapper;
        private readonly IClient _client;
        private readonly IAddBearerTokenService _addBearerTokenService;

        public EmployeeService(IMapper mapper, IClient client, IAddBearerTokenService addBearerTokenService)
        {
            _addBearerTokenService = addBearerTokenService;
            _mapper = mapper;
            _client = client;
        }

        public async Task<BaseResponse> AddEmployee(AddEmployeeCommand requestModel)
        {
            try
            {
                await _addBearerTokenService.AddBearerToken(_client);

                return await _client.AddEmployeeAsync(requestModel);
            }
            catch (Exception ex)
            {
                return new BaseResponse() { Message = ex.Message, Success = false };
            }
        }

        public async Task<BaseResponse> ChangeAdminStatus(ChangeAdminStatusCommand requestModel)
        {
            try
            {
                await _addBearerTokenService.AddBearerToken(_client);

                return await _client.ChangeAdminStatusAsync(requestModel);
            }
            catch (Exception ex)
            {
                return new BaseResponse() { Message = ex.Message, Success = false };
            }
        }

        public async Task<BaseResponse> DeleteEmployee(DeleteEmployeeCommand requestModel)
        {
            try
            {
                await _addBearerTokenService.AddBearerToken(_client);

                return await _client.DeleteEmployeeAsync(requestModel);
            }
            catch (Exception ex)
            {
                return new BaseResponse() { Message = ex.Message, Success = false };
            }
        }

        public async Task<GetEmployesQueryVMListBaseResponse> GetEmployes(GetEmployesQuery requestModel)
        {
            try
            {
                await _addBearerTokenService.AddBearerToken(_client);

                return await _client.GetEmployesAsync(requestModel);
            }
            catch (Exception ex)
            {
                return new GetEmployesQueryVMListBaseResponse() { Message = ex.Message, Success = false };
            }
        }
    }
}
