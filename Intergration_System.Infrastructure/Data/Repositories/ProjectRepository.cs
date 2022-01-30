using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Domain.Entities.Projects;
using TM.Infrastructure.Data.Repositories.Base;

namespace TM.Infrastructure.Data.Repositories
{
    public class ProjectRepository : RepositoryBase<Project>, IProjectRepository
    {
        public ProjectRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public async Task<Project> GetProjectsAndRelated(int idProject)
        {
            return await GetAsync(_ => _.Id == idProject);
        }

        public async Task<List<Project>> GetProjectsByIdUser(int userId)
        {
            return await GetListAsync(_ => _.ProjectMembers.Any(_ => _.UserId == userId));
        }
    }
}
