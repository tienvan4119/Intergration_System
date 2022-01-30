using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TM.Domain.DTOs;
using TM.Domain.Entities.Base;
using TM.Domain.Interfaces.Database;

namespace TM.Infrastructure.Data.Repositories.Base
{
    public class TenantRepositoryBase<T> : RepositoryBase<T>
        , ITenantRepositoryBase<T>
        where T : class, ITenantEntity
    {
        private readonly IUserInfor _userInfor;
        private int _tenantId;
        public TenantRepositoryBase(IDbFactory dbFactory
            , IServiceProvider serviceProvider) : base(dbFactory)
        {
            _userInfor = serviceProvider.GetService<IUserInfor>();
        }

        public virtual int TenantId
        {
            get
            {
                if (_tenantId == default)
                    _tenantId = _userInfor.TenantId;
                return _tenantId;
            }
            set => _tenantId = value;
        }

        public override Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            return GetAsync(TenantId, expression);
        }

        public virtual Task<T> GetAsync(int tenantId, Expression<Func<T, bool>> expression)
        {
            return DbSet.Where(e => e.TenantId == tenantId).FirstOrDefaultAsync(expression);
        }

        public override IQueryable<T> GetList(Expression<Func<T, bool>> expression)
        {
            return GetList(TenantId, expression);
        }

        public virtual IQueryable<T> GetList(int tenantId, Expression<Func<T, bool>> expression)
        {
            return DbSet.Where(e=>e.TenantId == tenantId).Where(expression);
        }

        public override Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return DbSet.Where(e=>e.TenantId == TenantId).AnyAsync(expression);
        }

        public Task<List<T>> GetListAsync(int tenantId, Expression<Func<T, bool>> expression)
        {
            return GetList(tenantId, expression).ToListAsync();
        }
    }
}
