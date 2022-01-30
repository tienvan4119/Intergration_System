using System.Threading.Tasks;
using TM.Domain.Interfaces;
using TM.Domain.Interfaces.Database;

namespace TM.Domain.Entities.CardMovements
{
    public interface ICardMovementRepository : IEntityRepository<CardMovement>
    {
        Task<CardMovement> GetCurrentPhaseByCardIdAsync(int? cardId);
    }
}
