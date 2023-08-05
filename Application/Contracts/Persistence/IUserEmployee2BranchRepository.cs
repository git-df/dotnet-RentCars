using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence
{
    public interface IUserEmployee2BranchRepository : IAsyncRepository<UserEmployee2Branch>
    {
        Task<UserEmployee2Branch> GetByIds(int employeeId, int branchId);
        Task DeleteRangeByEmployeeId(int EmployeeId);
    }
}
