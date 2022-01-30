using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Domain.Entities.CardTags;
using TM.Infrastructure.Data.Repositories.Base;

namespace TM.Infrastructure.Data.Repositories
{
    public class CardTagRepository : RepositoryBase<CardTag>, ICardTagRepository
    {
        public CardTagRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public async Task<CardTag> GetCardTagAsync(int? cardId, int? tagId)
        {
            return await GetAsync(_ => _.CardId == cardId && _.TagId == tagId);
        }
    }
}
