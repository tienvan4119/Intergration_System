using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Domain.Entities.ToDos;
using TM.Infrastructure.Data.Repositories.Base;

namespace TM.Infrastructure.Data.Repositories
{
    public class TodoRepository : RepositoryBase<Todo>, IToDoRepository
    {
        public TodoRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public async Task<List<Todo>> GetTodos(int[] todoNos)
        {
            return await GetListAsync(_ => todoNos.Contains(_.Id));
        }

        public async Task<List<Todo>> GetTodos(int cardId)
        {
            return await GetListAsync(_ => _.CardId == cardId);
        }
    }
}
