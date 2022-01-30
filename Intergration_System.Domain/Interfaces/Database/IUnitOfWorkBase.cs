using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TM.Domain.Interfaces.Database
{
    public interface IUnitOfWorkBase
    {
        IServiceProvider GetServiceProvider();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        IEntityRepository<T> Repository<T>() where T : class;
        ITenantRepositoryBase<T> TenantRepository<T>() where T : class;

    }

    public interface IUnitOfWorkBase<T> : IUnitOfWorkBase
        where T : DbContext
    {
        T DbContext { get; }
    }
}
