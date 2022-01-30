//using ELDesk.Hub.Domain.Interfaces;
//using ELDesk.Shared.Domain.MongoDb.Base;
//using ELDesk.Shared.Domain.MongoDb.Entities.Base;
//using ELDesk.Shared.Infrastructure;
//using ELDesk.Shared.Infrastructure.Repositories;
//using System;

//namespace ELDesk.Hub.Infrastructure.Repositories
//{
//	public class HubRepository<T> : MongoRepository<T>
//		, IHubRepository<T>
//		where T : IMongoEntity
//	{
//		public HubRepository(HubMongoDatabaseOptions options
//			, IServiceProvider serviceProvider
//			) : base(options.Database, serviceProvider)
//		{
//		}
//	}

//	public class HubTenantRepository<T> : MongoTenantRepository<T>
//		, IHubTenantRepository<T>
//		where T : IMongoTenantEntity
//	{
//		public HubTenantRepository(HubMongoDatabaseOptions options
//			, IServiceProvider serviceProvider
//			) : base(options.Database, serviceProvider)
//		{
//		}
//	}
//}
