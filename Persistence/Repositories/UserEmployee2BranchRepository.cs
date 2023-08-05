using Application.Contracts.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class UserEmployee2BranchRepository : AsyncRepository<UserEmployee2Branch>, IUserEmployee2BranchRepository
    {
        public UserEmployee2BranchRepository(RentCarsDbContext rentCarsDbContext) : base(rentCarsDbContext)
        {
        }

        public async Task DeleteRangeByEmployeeId(int EmployeeId)
        {
            var data = await _context.UserEmployees2Branches
                .Where(e => e.UserEmployeeId == EmployeeId)
                .ToListAsync();

            _context.RemoveRange(data);
        }

        public async Task<UserEmployee2Branch?> GetByIds(int employeeId, int branchId)
        {
            return await _context.UserEmployees2Branches
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.BranchId == branchId && e.UserEmployeeId == employeeId);
        }
    }
}
