using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Domain.Entities.CardAssigns;
using TM.Infrastructure.Data.Repositories.Base;

namespace TM.Infrastructure.Data.Repositories
{
    public class CardAssignRepository : RepositoryBase<CardAssign>, ICardAssignRepository
    {
        public CardAssignRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public async Task<CardAssign> GetCardAssignIsAssignedAsync(int? cardId)
        {
           return await GetAsync (_ => _.CardId == cardId && (bool)_.IsAssigned);
        }
    }
}
