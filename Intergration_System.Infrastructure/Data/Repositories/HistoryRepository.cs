using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Domain.Entities.CardHistories;
using TM.Infrastructure.Data.Repositories.Base;

namespace TM.Infrastructure.Data.Repositories
{
    public class HistoryRepository : RepositoryBase<CardHistory>, ICardHistoryRepository
    {
        public HistoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public async Task<IList<CardHistory>> GetHistories(int cardId) {
            return await GetListAsync(_ => _.CardId == cardId);
        }
    }
}
