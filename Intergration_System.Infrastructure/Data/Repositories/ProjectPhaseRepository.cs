using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Domain.Entities.ProjectPhases;
using TM.Infrastructure.Data.Repositories.Base;

namespace TM.Infrastructure.Data.Repositories
{
    public class ProjectPhaseRepository : RepositoryBase<ProjectPhase>, IProjectPhaseRepository
    {
        public ProjectPhaseRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
