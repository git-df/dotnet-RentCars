using AutoMapper;
using UI.Interfaces;
using UI.Interfaces.Security;

namespace UI.Services
{
    public class BranchService : IBranchService
    {
        private readonly IMapper _mapper;
        private readonly IClient _client;
        private readonly IAddBearerTokenService _addBearerTokenService;

        public BranchService(IMapper mapper, IClient client, IAddBearerTokenService addBearerTokenService)
        {
            _addBearerTokenService = addBearerTokenService;
            _mapper = mapper;
            _client = client;
        }

        public async Task<BaseResponse> AddBranch(AddBranchCommand requestModel)
        {
            try
            {
                await _addBearerTokenService.AddBearerToken(_client);

                return await _client.AddBranchAsync(requestModel);
            }
            catch (Exception ex)
            {
                return new BaseResponse() { Message = ex.Message, Success = false };
            }
        }

        public async Task<BaseResponse> AddEmployeeToBranch(AddEmployeeToBranchCommand requestModel)
        {
            try
            {
                await _addBearerTokenService.AddBearerToken(_client);

                return await _client.AddEmployeeToBranchAsync(requestModel);
            }
            catch (Exception ex)
            {
                return new BaseResponse() { Message = ex.Message, Success = false };
            }
        }

        public async Task<BaseResponse> DeleteBranch(DeleteBranchCommand requestModel)
        {
            try
            {
                await _addBearerTokenService.AddBearerToken(_client);

                return await _client.DeleteBranchAsync(requestModel);
            }
            catch (Exception ex)
            {
                return new BaseResponse() { Message = ex.Message, Success = false };
            }
        }

        public async Task<BaseResponse> EditBranch(EditBranchCommand requestModel)
        {
            try
            {
                await _addBearerTokenService.AddBearerToken(_client);

                return await _client.EditBranchAsync(requestModel);
            }
            catch (Exception ex)
            {
                return new BaseResponse() { Message = ex.Message, Success = false };
            }
        }

        public async Task<GetBranchDetailsQueryVMBaseResponse> GetBranchDetails(GetBranchDetailsQuery requestModel)
        {
            try
            {
                await _addBearerTokenService.AddBearerToken(_client);

                return await _client.GetBranchDetailsAsync(requestModel);
            }
            catch (Exception ex)
            {
                return new GetBranchDetailsQueryVMBaseResponse() { Message = ex.Message, Success = false };
            }
        }

        public async Task<GetBranchEmployesQueryVMListBaseResponse> GetBranchEmployes(GetBranchEmployesQuery requestModel)
        {
            try
            {
                await _addBearerTokenService.AddBearerToken(_client);

                return await _client.GetBranchEmployesAsync(requestModel);
            }
            catch (Exception ex)
            {
                return new GetBranchEmployesQueryVMListBaseResponse() { Message = ex.Message, Success = false };
            }
        }

        public async Task<GetBranchesQueryVMListBaseResponse> GetBranches(GetBranchesQuery requestModel)
        {
            try
            {
                await _addBearerTokenService.AddBearerToken(_client);

                return await _client.GetBranchesAsync(requestModel);
            }
            catch (Exception ex)
            {
                return new GetBranchesQueryVMListBaseResponse() { Message = ex.Message, Success = false };
            }
        }

        public async Task<GetEmployesNoInBranchQueryVMListBaseResponse> GetEmployesNoInBranch(GetEmployesNoInBranchQuery requestModel)
        {
            try
            {
                await _addBearerTokenService.AddBearerToken(_client);

                return await _client.GetEmployesNoInBranchAsync(requestModel);
            }
            catch (Exception ex)
            {
                return new GetEmployesNoInBranchQueryVMListBaseResponse() { Message = ex.Message, Success = false };
            }
        }

        public async Task<BaseResponse> RemoveEmployeeFromBranch(RemoveEmployeeFromBranchCommand requestModel)
        {
            try
            {
                await _addBearerTokenService.AddBearerToken(_client);

                return await _client.RemoveEmployeeFromBranchAsync(requestModel);
            }
            catch (Exception ex)
            {
                return new BaseResponse() { Message = ex.Message, Success = false };
            }
        }
    }
}
