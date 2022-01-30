using System.Threading.Tasks;
using TM.Domain.Interfaces;
using TM.Domain.Interfaces.Database;

namespace TM.Domain.Entities.CardAssigns
{
    public interface ICardAssignRepository : IEntityRepository<CardAssign>
    {
        Task<CardAssign> GetCardAssignIsAssignedAsync(int? cardId);
    }
}
