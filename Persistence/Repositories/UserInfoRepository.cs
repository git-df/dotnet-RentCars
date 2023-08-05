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
    public class UserInfoRepository : AsyncRepository<UserInfo>, IUserInfoRepository
    {
        public UserInfoRepository(RentCarsDbContext rentCarsDbContext) : base(rentCarsDbContext)
        {
        }

        public async Task<UserInfo?> GetUserInfoByUserId(int id)
        {
            return await _context.UsersInfo
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.UserAppId == id);
        }
    }
}
