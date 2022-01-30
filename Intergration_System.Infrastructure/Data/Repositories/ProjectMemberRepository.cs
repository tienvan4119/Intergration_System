using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Domain.Entities.ProjectMembers;
using TM.Infrastructure.Data.Repositories.Base;

namespace TM.Infrastructure.Data.Repositories
{
    public class ProjectMemberRepository : RepositoryBase<ProjectMember>, IMemberProjectRepository
    {
        public ProjectMemberRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public async Task<bool> IsHaveProjectMemberAsync(int? projectId, int? userId)
        {
            return await AnyAsync(_ => _.UserId == userId
                                        && _.ProjectId == projectId
                                        && _.IsActive == true);
        }
    }
}
