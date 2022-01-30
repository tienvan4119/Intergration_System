using Microsoft.EntityFrameworkCore;
using TM.Domain.DTOs;
using TM.Domain.Entities.Base;

namespace TM.Domain.Interfaces.Database
{
    public interface IRepository<T> where T : Entity
    {
        DbSet<T> Entites { get; }
        DbContext DbContext { get; }
        IUserInfor UserInfor { get; }
        int TenantId { get; }
        int UserId { get; }
    }
}
