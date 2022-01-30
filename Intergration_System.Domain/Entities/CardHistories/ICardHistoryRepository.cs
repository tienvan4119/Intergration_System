using System.Collections.Generic;
using System.Threading.Tasks;
using TM.Domain.Interfaces;
using TM.Domain.Interfaces.Database;

namespace TM.Domain.Entities.CardHistories
{
    public interface ICardHistoryRepository : IEntityRepository<CardHistory>
    {
        public Task<IList<CardHistory>> GetHistories(int cardId);
    }
}
