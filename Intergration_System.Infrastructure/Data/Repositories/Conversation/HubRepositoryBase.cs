//using ELDesk.Shared.Domain.Entities.Base;
//using ELDesk.Shared.Infrastructure;
//using ELDesk.Utilities.EFCore;
//using Microsoft.AspNetCore.Http;
//using System;

//namespace ELDesk.Hub.Infrastructure.Repositories
//{
//	public class HubRepositoryBase<T> : RepositoryBase<T> where T : class, IEntityBase
//	{
//		public HubRepositoryBase(IDbFactory dbFactory, IHttpContextAccessor httpContextAccessor)
//			: base(dbFactory)
//		{
//		}
//	}

//	public class HubTenantRepositoryBase<T> : TenantRepositoryBase<T> where T : class, ITenantEntity
//	{
//		public HubTenantRepositoryBase(IDbFactory dbFactory, IServiceProvider serviceProvider)
//			: base(dbFactory, serviceProvider)
//		{
//		}
//	}
//}
