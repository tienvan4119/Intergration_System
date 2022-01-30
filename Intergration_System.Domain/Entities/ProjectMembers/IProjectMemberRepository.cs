using System.Threading.Tasks;
using TM.Domain.Interfaces;
using TM.Domain.Interfaces.Database;

namespace TM.Domain.Entities.ProjectMembers
{
    public interface IMemberProjectRepository : IEntityRepository<ProjectMember>
    {
        Task<bool> IsHaveProjectMemberAsync(int? projectId, int? userId);
    }
}
