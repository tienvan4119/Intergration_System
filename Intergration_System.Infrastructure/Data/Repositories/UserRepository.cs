using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TM.Domain.Entities.Users;
using TM.Infrastructure.Data.Repositories.Base;

namespace TM.Infrastructure.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>,IUserRepository
    {
        public UserRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public async Task<User> NewUser(string userName, string password)
        {
            var user = new User(userName, password);
            if (user.ValidOnAdd())
            {
                await this.InsertAsync(user);
                return user;
            }
            else
                throw new Exception("User invalid");
        }

        public async Task<IEnumerable<User>> UsersInProjectAsync(int? projectId)
        {
            return await GetListAsync(_ => _.ProjectMembers.Any(_ => _.ProjectId == projectId));
                           
        }
        public async Task<User> Login(string userName, string password)
        {
            return await GetAsync(_ => _.UserName.Equals(userName) && _.Password.Equals(password));
        }
    }
}
