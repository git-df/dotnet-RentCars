using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence
{
    public interface IUserAppRepository : IAsyncRepository<UserApp>
    {
        Task<UserApp> GetUserByEmail(string email);
        Task<UserApp> GetUserByIdWithUserInfo(int id);
        Task<List<UserApp>> GetUsersNoEmployes(int page, int pageSize, string search);
        Task<int> GetUsersNoEmployesCount(string search);
    }
}
