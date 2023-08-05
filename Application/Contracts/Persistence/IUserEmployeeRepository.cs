using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence
{
    public interface IUserEmployeeRepository : IAsyncRepository<UserEmployee>
    {
        Task<List<UserEmployee>> GetEmployesByBranchId(int id, int page, int pageSize, string search);
        Task<List<UserEmployee>> GetEmployesByNoBranchId(int id, int page, int pageSize, string search);
        Task<List<UserEmployee>> GetEmployes(int page, int pageSize, string search);
        Task<UserEmployee> GetEmployeeByUserId(int userId);
        Task<int> GetEmployesCount(string search);
        Task<int> GetEmployesByBranchIdCount(int id, string search);
        Task<int> GetEmployesByNoBranchIdCount(int id, string search);
    }
}
