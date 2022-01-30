using System.Collections.Generic;
using System.Threading.Tasks;
using TM.Domain.Interfaces.Database;

namespace TM.Domain.Entities.Users
{
    public interface IUserRepository : IEntityRepository<User>
    {
        Task<User> NewUser(string userName
            , string password);
        Task<IEnumerable<User>> UsersInProjectAsync(int? projectId);
        Task<User> Login(string userName, string password);
    }
}
