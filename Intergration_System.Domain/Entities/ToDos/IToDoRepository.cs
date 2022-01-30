using System.Collections.Generic;
using System.Threading.Tasks;
using TM.Domain.Interfaces;
using TM.Domain.Interfaces.Database;

namespace TM.Domain.Entities.ToDos
{
    public interface IToDoRepository : IEntityRepository<Todo>
    {
        public Task<List<Todo>> GetTodos(int[] todoNos);

        public Task<List<Todo>> GetTodos(int cardId);
    }
}
