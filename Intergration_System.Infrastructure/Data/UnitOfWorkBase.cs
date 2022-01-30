using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;
using TM.Domain.DTOs;
using TM.Domain.Entities.Base;
using TM.Domain.Interfaces.Database;

namespace TM.Infrastructure.Data
{
    public class UnitOfWorkBase<T> : IUnitOfWorkBase<T> where T : DbContext
    {
        protected readonly IServiceProvider ServiceProvider;
        private readonly IUserInfor _userInfo;
        private readonly IDbFactory<T> _dbFactory;
        
        public UnitOfWorkBase(IDbFactory<T> db, IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
            _dbFactory = db;
            _userInfo = serviceProvider.GetService<IUserInfor>();
        }
        public T DbContext => _dbFactory.DbContext;

        public IServiceProvider GetServiceProvider()
        {
            return ServiceProvider;
        }

        public virtual IEntityRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            return ServiceProvider.GetService<IEntityRepository<TEntity>>();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = DbContext.ChangeTracker.Entries();

            foreach(var entry in entries)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        OnEntryAdded(entry);
                        break;
                    case EntityState.Modified:
                        OnEntryUpdated(entry);
                        break;
                    case EntityState.Deleted:
                    case EntityState.Detached:
                    case EntityState.Unchanged:
                        break;
                   
                }
            }

            var saved = await DbContext.SaveChangesAsync(cancellationToken);
            return saved;
        }

        private void OnEntryUpdated(Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry entry)
        {
        }

        private void OnEntryAdded(Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry entry)
        {
            int tenantId = _userInfo.TenantId;
            int createdBy = _userInfo.Id;

            var entity = entry.Entity;
            var entityType = entity.GetType();

            if (typeof(IAuditEntity).IsAssignableFrom(entityType))
            {
                var auditEntity = (entity as IAuditEntity);
                if (auditEntity?.CreatedBy == default)
                    auditEntity.UpdateAudit(createdBy, DateTime.UtcNow);
            }

            if (typeof(ITenantEntity).IsAssignableFrom(entityType))
            {
                var auditEntity = (entity as ITenantEntity);
                if (auditEntity?.TenantId == default)
                    (entity as ITenantEntity)?.UpdateTenant(tenantId);
            }
        }

        public virtual ITenantRepositoryBase<T1> TenantRepository<T1>() where T1 : class
        {
            return ServiceProvider.GetService<ITenantRepositoryBase<T1>>();
        }
    }
}
