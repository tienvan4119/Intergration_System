//using ELDesk.Hub.Domain.Contacts;
//using ELDesk.Hub.Domain.Conversations;
//using ELDesk.Hub.Domain.Emails;
//using ELDesk.Hub.Domain.UserLogins;
//using ELDesk.Shared.Infrastructure;
//using Microsoft.Extensions.DependencyInjection;
//using MongoDB.Driver;
//using MongoDB.Driver.Linq;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using static ELDesk.Hub.Domain.Enums.ConversationEnum;

//namespace ELDesk.Hub.Infrastructure.Repositories
//{
//	public class UserLoginRepository : HubRepository<UserLogin>
//		, IUserLoginRepository
//	{
//		public UserLoginRepository(HubMongoDatabaseOptions options
//			, IServiceProvider serviceProvider
//			) : base(options, serviceProvider)
//		{
//		}

//		public Task<List<UserLogin>> ListByUserAsync(int userId)
//		{
//			return GetListAsync(_ => _.Users.Any(u => u.UserId == userId));
//		}

//		public IMongoQueryable<UserLogin> ListByUser(int userId)
//		{
//			return GetList(_ => _.Users.Any(u => u.UserId == userId));
//		}

//		public Task<UserLogin> GetLoginAsync(int userId
//			, ConversationType type)
//		{
//			return GetAsync(_ => _.Users.Any(u => u.UserId == userId)
//				&& _.Type == type
//			);
//		}

//		public async Task<UserLoginToken> GetCredentialAsync(int userId
//			, ConversationType type)
//		{
//			var login = await GetLoginAsync(userId, type);
//			if (login != null)
//			{
//				return login.Users.First(_ => _.UserId == userId);
//			}

//			return default;
//		}

//		public Task<UserLogin> GetLoginAsync(int userId
//			, ConversationType type
//			, Guid settingId)
//		{
//			return GetAsync(_ =>
//				_.Type == type
//				&& _.SettingId == settingId
//				&& _.Users.Any(u => u.UserId == userId)
//			);
//		}

//		public IMongoQueryable<UserLogin> ListByContacts(List<string> contactCodes)
//		{
//			var contactRepo = ServiceProvider.GetService<IConversationContactRepository>();
//			var getLoginIds = contactRepo
//				.ListByContactCodes(contactCodes.ToArray())
//				.Select(_ => _.LoginId)
//				.Distinct()
//				.ToListAsync();

//			getLoginIds.Wait();
//			var loginIds = getLoginIds.Result;

//			return this
//				.GetList(_ => loginIds.Contains(_.Id));
//		}

//		public Task<bool> IsChannelAuthorizedAsync(int userId
//			, ConversationType type
//			, Guid settingId)
//		{
//			return AnyAsync(_ =>
//				_.Type == type
//				&& _.SettingId == settingId
//				&& _.Users.Any(u => u.UserId == userId)
//			);
//		}

//		public Task<UserLogin> GetLoginAsync(Guid settingId, ConversationType type)
//		{
//			return GetAsync(_ => _.SettingId == settingId
//					&& _.Type == type
//				);
//		}

//		public async Task<UserLogin> GetEmailLoginAsync(string domain)
//		{
//			var emailServerRepo = ServiceProvider.GetService<IEmailServerRepository>();
//			var setting = await emailServerRepo.GetAsync(_ => _.Domain == domain);
//			return await GetAsync(_ => _.SettingId == setting.Id && _.Type == ConversationType.Email);
//		}

//		public IMongoQueryable<UserLogin> ListByConversation(Guid conversationId)
//		{
//			var conversationRepo = ServiceProvider.GetService<IConversationRepository>();
//			var conversation = conversationRepo.GetAsync(_ => _.Id == conversationId).Result;
//			var contacts = conversation.ContactCodes ?? new List<string>();
//			return ListByContacts(contacts);
//		}
//	}
//}
