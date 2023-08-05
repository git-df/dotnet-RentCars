using Application.Contracts.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class UserEmployeeRepository : AsyncRepository<UserEmployee>, IUserEmployeeRepository
    {
        public UserEmployeeRepository(RentCarsDbContext rentCarsDbContext) : base(rentCarsDbContext)
        {
        }

        public async Task<UserEmployee?> GetEmployeeByUserId(int userId)
        {
            return await _context.UsersEmployees
                .Include(e => e.UserApp)
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.UserAppId == userId);
        }

        public async Task<List<UserEmployee>> GetEmployes(int page, int pageSize, string search)
        {
            return await _context.UsersEmployees
                .Include(e => e.UserEmployee2Branches)
                .Include(e => e.UserApp)
                .ThenInclude(ee => ee.UserInfo)
                .Where(e => search.IsNullOrEmpty() || e.UserApp.Email.ToLower().Contains(search.ToLower()) || e.UserApp.UserInfo.FirstName.ToLower().Contains(search.ToLower()) || e.UserApp.UserInfo.LastName.ToLower().Contains(search.ToLower()))
                .Skip(pageSize * (page - 1))
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<UserEmployee>> GetEmployesByBranchId(int id, int page, int pageSize, string search)
        {
            return await _context.UsersEmployees
                .Include(e => e.UserEmployee2Branches)
                .Where(e => e.UserEmployee2Branches.Where(ee => ee.BranchId == id).Any())
                .Include(e => e.UserApp)
                .ThenInclude(ee => ee.UserInfo)
                .Where(e => search.IsNullOrEmpty() || e.UserApp.Email.ToLower().Contains(search.ToLower()) || e.UserApp.UserInfo.FirstName.ToLower().Contains(search.ToLower()) || e.UserApp.UserInfo.LastName.ToLower().Contains(search.ToLower()))
                .Skip(pageSize * (page - 1))
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<int> GetEmployesByBranchIdCount(int id, string search)
        {
            return await _context.UsersEmployees
                .Include(e => e.UserEmployee2Branches)
                .Where(e => e.UserEmployee2Branches.Where(ee => ee.BranchId == id).Any())
                .Include(e => e.UserApp)
                .ThenInclude(ee => ee.UserInfo)
                .Where(e => search.IsNullOrEmpty() || e.UserApp.Email.ToLower().Contains(search.ToLower()) || e.UserApp.UserInfo.FirstName.ToLower().Contains(search.ToLower()) || e.UserApp.UserInfo.LastName.ToLower().Contains(search.ToLower()))
                .CountAsync();
        }

        public async Task<List<UserEmployee>> GetEmployesByNoBranchId(int id, int page, int pageSize, string search)
        {
            return await _context.UsersEmployees
                .Include(e => e.UserEmployee2Branches)
                .Where(e => !e.UserEmployee2Branches.Where(ee => ee.BranchId == id).Any())
                .Include(e => e.UserApp)
                .ThenInclude(ee => ee.UserInfo)
                .Where(e => search.IsNullOrEmpty() || e.UserApp.Email.ToLower().Contains(search.ToLower()) || e.UserApp.UserInfo.FirstName.ToLower().Contains(search.ToLower()) || e.UserApp.UserInfo.LastName.ToLower().Contains(search.ToLower()))
                .Skip(pageSize * (page - 1))
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<int> GetEmployesByNoBranchIdCount(int id, string search)
        {
            return await _context.UsersEmployees
                .Include(e => e.UserEmployee2Branches)
                .Where(e => !e.UserEmployee2Branches.Where(ee => ee.BranchId == id).Any())
                .Include(e => e.UserApp)
                .ThenInclude(ee => ee.UserInfo)
                .Where(e => search.IsNullOrEmpty() || e.UserApp.Email.ToLower().Contains(search.ToLower()) || e.UserApp.UserInfo.FirstName.ToLower().Contains(search.ToLower()) || e.UserApp.UserInfo.LastName.ToLower().Contains(search.ToLower()))
                .CountAsync();
        }

        public async Task<int> GetEmployesCount(string search)
        {
            return await _context.UsersEmployees
                .Include(e => e.UserEmployee2Branches)
                .Include(e => e.UserApp)
                .ThenInclude(ee => ee.UserInfo)
                .Where(e => search.IsNullOrEmpty() || e.UserApp.Email.ToLower().Contains(search.ToLower()) || e.UserApp.UserInfo.FirstName.ToLower().Contains(search.ToLower()) || e.UserApp.UserInfo.LastName.ToLower().Contains(search.ToLower()))
                .CountAsync();
        }
    }
}
