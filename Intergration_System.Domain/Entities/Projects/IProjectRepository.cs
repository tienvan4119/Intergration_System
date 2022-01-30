using System.Collections.Generic;
using System.Threading.Tasks;
using TM.Domain.Interfaces;
using TM.Domain.Interfaces.Database;

namespace TM.Domain.Entities.Projects
{
    public interface IProjectRepository : IEntityRepository<Project>
    {
        public Task<List<Project>> GetProjectsByIdUser(int idUser);
        public Task<Project> GetProjectsAndRelated(int idProject);
    }
}
