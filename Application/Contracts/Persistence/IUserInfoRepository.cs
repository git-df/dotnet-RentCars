using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence
{
    public interface IUserInfoRepository : IAsyncRepository<UserInfo>
    {
        Task<UserInfo> GetUserInfoByUserId(int id);
    }
}
