using System.Collections.Generic;
using System.Threading.Tasks;
using TM.Domain.Interfaces;
using TM.Domain.Interfaces.Database;

namespace TM.Domain.Entities.Phases
{
    public interface IPhaseRepository : IEntityRepository<Phase>
    {
        public Task<IEnumerable<Phase>> GetPhasesAndTaskByProjectIdAsync(int projectId);
    }
}
