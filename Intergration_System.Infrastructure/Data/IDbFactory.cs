using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TM.Infrastructure.Data
{
    public interface IDbFactory
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }

    public interface IDbFactory<T> : IDbFactory
        where T : DbContext
    {
        T DbContext { get; }
    }

    public class DbFactory<T> : IDbFactory<T>, IDisposable
        where T : DbContext
    {
        private readonly IServiceProvider _serviceProvider;
        private bool _isDisposed;
        private T _dbContext;


        public T DbContext => _dbContext ??
            (_dbContext = _serviceProvider.GetRequiredService<T>());

        public void Dispose()
        {
            if(_isDisposed && _dbContext != null)
            {
                _isDisposed = true;
                DbContext.Dispose();
            }
        }

        public DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
           return DbContext.Set<TEntity>();
        }
    }
}
