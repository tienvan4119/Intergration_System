//using ELDesk.Hub.Domain.Conversations;
//using ELDesk.Hub.Domain.Entities;
//using ELDesk.Shared.Infrastructure;
//using MongoDB.Driver;
//using MongoDB.Driver.Linq;
//using System;
//using System.Linq;
//using System.Threading.Tasks;

//namespace ELDesk.Hub.Infrastructure.Repositories
//{
//	public class MessageRepository : HubRepository<Message>
//		, IMessageRepository
//	{
//		public MessageRepository(
//			HubMongoDatabaseOptions options
//			, IServiceProvider serviceProvider
//			) : base(options, serviceProvider)
//		{
//		}

//		public Task<bool> ExistCodeAsync(string messageCode)
//		{
//			return AnyAsync(_ => _.MessageCode == messageCode);
//		}

//		public Task<Message> GetLatestMessageAsync(Guid conversationId)
//		{
//			return this.Collection.Find(_ => _.Conversation.Id == conversationId)
//				.SortByDescending(_ => _.CreatedOn)
//				.FirstOrDefaultAsync();
//		}

//		public IMongoQueryable<Message> ListByConversation(Guid conversationId)
//		{
//			return Collection
//				.AsQueryable()
//				.Where(_ => _.Conversation.Id == conversationId);
//		}
//	}
//}
