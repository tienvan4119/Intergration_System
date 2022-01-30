//using ELDesk.Hub.Domain.Emails;
//using ELDesk.Hub.Domain.Entities;
//using System;
//using System.Threading.Tasks;

//namespace ELDesk.Hub.Infrastructure.Repositories
//{
//	public class EmailServerRepository : HubRepository<EmailServer>
//		, IEmailServerRepository
//	{
//		public EmailServerRepository(
//			HubMongoDatabaseOptions options
//			, IServiceProvider serviceProvider
//			) : base(options, serviceProvider)
//		{
//		}

//		public Task<EmailServer> GetAsync(string domain
//			, string replyToEmail
//			)
//		{
//			return this.GetAsync(s =>
//				s.Domain == domain
//			);
//		}
//	}
//}
