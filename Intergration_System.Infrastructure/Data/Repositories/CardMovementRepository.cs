using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Domain.Entities.CardMovements;
using TM.Infrastructure.Data.Repositories.Base;

namespace TM.Infrastructure.Data.Repositories
{
    public class CardMovementRepository : RepositoryBase<CardMovement>, ICardMovementRepository
    {
        public CardMovementRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public async Task<CardMovement> GetCurrentPhaseByCardIdAsync(int? cardId)
        {
            return await GetAsync(_ => _.CardId == cardId && (bool)_.IsCurrent);
        }
    }
}
