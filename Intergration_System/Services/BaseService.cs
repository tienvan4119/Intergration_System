using TM.Domain.Interfaces.Database;

namespace TM.API.Services
{
    public class BaseService
    {
        protected readonly IUnitOfWorkBase UnitOfWork;
        public BaseService(IUnitOfWorkBase unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

	}
}
