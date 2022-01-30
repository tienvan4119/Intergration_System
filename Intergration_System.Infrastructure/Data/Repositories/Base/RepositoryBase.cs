using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TM.Domain.Interfaces.Database;

namespace TM.Infrastructure.Data.Repositories.Base
{
    public class RepositoryBase<T> : IEntityRepository<T>
        where T : class
    {
        private readonly IDbFactory _dbFactory;
        private DbSet<T> _dbSet;
        protected DbSet<T> DbSet => _dbSet ?? (_dbSet = _dbFactory.Set<T>());
        public RepositoryBase(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public virtual IQueryable<T> GetList(Expression<Func<T, bool>> expression)
        {
            return DbSet.Where(expression);
        }

        public IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public virtual Task InsertAsync(T entity)
        {
            return DbSet.AddAsync(entity).AsTask();
        }

        public virtual async Task InsertRangeAsync(IEnumerable<T> entities)
        {
            if(entities?.Any() == true)
            {
                await DbSet.AddRangeAsync(entities);
            }
        }

        public virtual void Remove(T entity)
        {
            DbSet.Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<T> entities)
        {
            if (entities?.Any() == true)
            {
                DbSet.RemoveRange(entities);
            }
        }

        public virtual void Update(T entity)
        {
            DbSet.Update(entity);
        }

        public virtual void UpdateRange(IEnumerable<T> entities)
        {
            if(entities?.Any() == true)
                DbSet.UpdateRange(entities);
        }

        public virtual Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            return DbSet.FirstOrDefaultAsync(expression);
        }

        public Task<List<T>> GetListAsync(Expression<Func<T, bool>> expression)
        {
           return GetList(expression).ToListAsync();
        }

        public virtual Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return DbSet.AnyAsync(expression);
        }
    }
}
