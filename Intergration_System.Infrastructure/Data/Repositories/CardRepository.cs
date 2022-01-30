using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Domain.Entities.Cards;
using TM.Domain.Entities.ToDos;
using TM.Infrastructure.Data.Repositories.Base;

namespace TM.Infrastructure.Data.Repositories
{
    public class CardRepository : RepositoryBase<Card>, ICardRepository
    {
        public CardRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public Task<Card> GetCardDetails(int cardId, int projectId)
        {
            return GetAsync(_ => _.Id == cardId && _.ProjectId == projectId);
        }

        public Task<Card> GetCardPhase(int cardId)
        {
            return GetAsync(_ => _.Id == cardId);
        }
        public Task<Card> GetCardTodo(int cardId)
        {
            return GetAsync(_ => _.Id == cardId);
        }
    }
}
