using System.Threading.Tasks;
using TM.Domain.Interfaces;
using TM.Domain.Interfaces.Database;

namespace TM.Domain.Entities.CardTags
{
    public interface ICardTagRepository : IEntityRepository<CardTag>
    {
        Task<CardTag> GetCardTagAsync(int? cardId, int? tagId);
    }
}
