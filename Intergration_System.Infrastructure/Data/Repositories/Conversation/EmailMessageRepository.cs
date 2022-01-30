//using ELDesk.Hub.Domain.Emails;
//using ELDesk.Hub.Domain.Entities;
//using ELDesk.Hub.Domain.Interfaces;
//using Microsoft.Extensions.DependencyInjection;
//using System;
//using System.Threading.Tasks;
//using static ELDesk.Hub.Domain.Enums.ConversationEnum;

//namespace ELDesk.Hub.Infrastructure.Repositories
//{
//	public class EmailMessageRepository : HubRepository<EmailMessage>
//		, IEmailMessageRepository
//	{
//		public EmailMessageRepository(
//			HubMongoDatabaseOptions options
//			, IServiceProvider serviceProvider
//			) : base(options, serviceProvider)
//		{
//		}

//		public async Task<Guid?> GetMainReplyIdAsync(string conversationCode)
//		{
//			var message = await ServiceProvider.GetService<IHubRepository<Message>>()
//							.GetAsync(_ => _.Conversation.ConversationCode == conversationCode
//									&& _.Conversation.Type == ConversationType.Email
//									&& _.ReferenceId == null);

//			return message == null ? (Guid?)null : message.Id;
//		}
//	}
//}
