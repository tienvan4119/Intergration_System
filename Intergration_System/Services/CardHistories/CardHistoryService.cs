using AutoMapper;
using System.Threading.Tasks;
using TM.API.DTOs.CardHistories;
using TM.Domain.Entities.CardHistories;
using TM.Domain.Interfaces.Database;

namespace TM.API.Services.CardHistories
{
    public class CardHistoryService : BaseService
    {
        private readonly IMapper _mapper;
        public CardHistoryService(
            IUnitOfWorkBase unitOfWork
            , IMapper mapper) : base(unitOfWork)
        {
            _mapper = mapper;
        }

        public async Task<bool> AddCardHistory(AddCardHistoryRequest request)
        {
            var cardHistory = UnitOfWork.Repository<CardHistory>();

            await cardHistory.InsertAsync(new CardHistory()
            {
                UserId = request.UserId,
                CardId = request.CardId,
                ActionType = request.ActionType.ToString(),
                Content = $"{request.UserName} {request.ActionType.ToLower()} {request.Content}"
            });

            var result = await UnitOfWork.SaveChangesAsync();

            return result > 0;
        }
    }
}
