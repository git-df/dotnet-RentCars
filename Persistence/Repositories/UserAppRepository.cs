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
    public class UserAppRepository : AsyncRepository<UserApp>, IUserAppRepository
    {
        public UserAppRepository(RentCarsDbContext rentCarsDbContext) : base(rentCarsDbContext)
        {
        }

        public async Task<UserApp?> GetUserByEmail(string email)
        {
            return await _context.UsersApp
                .Include(e => e.UserInfo)
                .Include(e => e.UserEmployee)
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Email == email);
        }

        public async Task<UserApp?> GetUserByIdWithUserInfo(int id)
        {
            return await _context.UsersApp
                .Include(e => e.UserInfo)
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<UserApp>> GetUsersNoEmployes(int page, int pageSize, string search)
        {
            return await _context.UsersApp
                .Include(e => e.UserInfo)
                .Include(e => e.UserEmployee)
                .Where(e => e.UserEmployee == null)
                .Where(e => search.IsNullOrEmpty() || (e.UserInfo.FirstName + " " + e.UserInfo.LastName).ToLower().Contains(search.ToLower()) || e.Email.ToLower().Contains(search.ToLower()))
                .Skip(pageSize * (page - 1))
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<int> GetUsersNoEmployesCount(string search)
        {
            return await _context.UsersApp
                .Include(e => e.UserInfo)
                .Include(e => e.UserEmployee)
                .Where(e => e.UserEmployee == null)
                .Where(e => search.IsNullOrEmpty() || (e.UserInfo.FirstName + " " + e.UserInfo.LastName).ToLower().Contains(search.ToLower()) || e.Email.ToLower().Contains(search.ToLower()))
                .CountAsync();
        }
    }
}
