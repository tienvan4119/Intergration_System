using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TM.Domain.Interfaces.Database
{
    public interface IRepositoryBase<T> 
    {
        Task InsertAsync(T entity);
        Task InsertRangeAsync(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);
        Task<T> GetAsync(Expression<Func<T, bool>> expression);
        Task<List<T>> GetListAsync(Expression<Func<T, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);

    }

    public interface IEntityRepository<T> : IRepositoryBase<T>
        where T: class
    {
        IQueryable<T> GetList(Expression<Func<T, bool>> expression);
        IQueryable<T> GetAll();
    }

    public interface ITenantRepositoryBase<T> : IEntityRepository<T> 
        where T : class
    {
        IQueryable<T> GetList(Expression<Func<T, bool>> expression);
        IQueryable<T> GetAll();
    }
}
