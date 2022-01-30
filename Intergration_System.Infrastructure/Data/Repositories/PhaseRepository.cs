using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Domain.Entities.Phases;
using TM.Infrastructure.Data.Repositories.Base;

namespace TM.Infrastructure.Data.Repositories
{
    public class PhaseRepository : RepositoryBase<Phase>, IPhaseRepository
    {
        public PhaseRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public async Task<IEnumerable<Phase>> GetPhasesAndTaskByProjectIdAsync(int projectId)
        {
            return await GetListAsync(_ => _.ProjectPhases.Any(_ => _.ProjectId == projectId));
        }
    }
}
