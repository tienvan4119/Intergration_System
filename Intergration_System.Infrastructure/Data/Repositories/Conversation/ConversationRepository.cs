//using Dasync.Collections;
//using ELDesk.Hub.Domain.Contacts;
//using ELDesk.Hub.Domain.Conversations;
//using ELDesk.Hub.Domain.Entities;
//using ELDesk.Hub.Domain.Interfaces;
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
//	public class ConversationRepository : HubRepository<Conversation>
//		, IConversationRepository
//	{
//		public ConversationRepository(HubMongoDatabaseOptions options
//			, IServiceProvider serviceProvider
//			) : base(options, serviceProvider)
//		{
//		}

//		public async Task<long> GetUnReadAsync(int userId
//			, ConversationType? messageType = default)
//		{
//			var contactRepo = ServiceProvider.GetService<IConversationContactRepository>();

//			var contactCodes = await contactRepo
//				.ListByUser(userId
//					, null
//					, messageType
//					, default
//				)
//				.SelectMany(_ => _.Contacts)
//				.Select(_ => _.Code)
//				.ToListAsync();

//			return await this.Collection
//				.AsQueryable()
//				.LongCountAsync(_ =>
//					!_.IsRead
//					&& _.ContactCodes.Any(c => contactCodes.Contains(c))
//				);
//		}

//		public async Task<bool> IsExistAsync(string conversationCode
//			, ConversationType conversationType
//			)
//		{
//			return await AnyAsync(c =>
//					c.ConversationCode == conversationCode
//					&& c.Type == conversationType
//				);
//		}

//		public async Task<bool> ExistGroupAsync(string code
//			, string groupCode)
//		{
//			var any = await AnyAsync(_ =>
//				_.ConversationCode == code
//				&& _.GroupCodes.Contains(groupCode)
//			);

//			return any;
//		}

//		public IMongoQueryable<Conversation> ListByGroupCode(string groupCode)
//		{
//			return GetList(_ => _.GroupCodes.Contains(groupCode));
//		}

//		public IMongoQueryable<Conversation> ListByGroupCode(string groupCode, int userId)
//		{
//			var contactRepo = ServiceProvider.GetService<IConversationContactRepository>();
//			var contactCodes = contactRepo
//				.ListByUser(userId
//					, null
//					, null
//					, default
//				)
//				.SelectMany(_ => _.Contacts)
//				.Select(_ => _.Code)
//				.ToList();

//			return GetList(_ => _.GroupCodes.Contains(groupCode) && _.ContactCodes.Any(c => contactCodes.Contains(c)));
//		}

//		public IMongoQueryable<Conversation> GetThreads(string contactCode
//			, string search
//			, Guid loginId)
//		{
//			search = search ?? "";
//			bool isSearch = !string.IsNullOrEmpty(search);
//			return GetList(_ => _.LoginId == loginId
//			&& _.ContactCodes.Contains(contactCode)
//				&& (
//					!isSearch
//					|| _.Name.Contains(search)
//				)
//			);
//		}

//		public async Task<List<Conversation>> GetConversationForArchiveAsync(List<string> contactCode
//			, int userId)
//		{
//			var loginRepo = ServiceProvider.GetService<IUserLoginRepository>();
//			var login = await loginRepo.GetLoginAsync(userId, ConversationType.Email);
//			var contactRepo = ServiceProvider.GetService<IHubRepository<ConversationContact>>();
//			var any = await contactRepo.AnyAsync(_ => _.Contacts.Any(c => contactCode.Contains(c.Code)) && _.LoginId == login.Id);
//			if (any)
//				return await GetList(_ => _.ContactCodes.Any(c => contactCode.Contains(c))).ToListAsync();

//			return default;
//		}

//		public Task<Conversation> GetAsync(string code
//			, ConversationType type)
//		{
//			return GetAsync(_ => _.ConversationCode == code && _.Type == type);
//		}

//		public Task<bool> AnyAsync(string code
//			, ConversationType type)
//		{
//			return AnyAsync(_ => _.ConversationCode == code && _.Type == type);
//		}

//		public async Task<bool> AuthorizedAsync(
//			Guid id
//			, int userId)
//		{
//			var contactRepo = ServiceProvider.GetService<IConversationContactRepository>();

//			var contactCodes = await contactRepo
//				.ListByUser(userId, null, null, null)
//				.SelectMany(_ => _.Contacts)
//				.Select(_ => _.Code)
//				.ToListAsync();

//			return await AnyAsync(_ =>
//				_.Id == id
//				&& _.ContactCodes.Any(c => contactCodes.Contains(c))
//			);
//		}

//		public async Task<List<Conversation>> LisByUserAsync(int userId
//			, bool? isArchived
//			, ConversationType? type = default
//			)
//		{
//			bool isSearchType = type.HasValue;
//			bool isSearchArchived = isArchived.HasValue;

//			var contactRepo = ServiceProvider.GetService<IConversationContactRepository>();

//			var contactCodes = await contactRepo
//				.ListByUser(userId, isArchived, type, null)
//				.SelectMany(_ => _.Contacts)
//				.Select(_ => _.Code)
//				.ToListAsync();

//			return await GetListAsync(_ =>
//				(
//					!isSearchType
//					|| _.Type == type
//				)
//				&& (
//					!isSearchArchived
//					|| _.Archived == isArchived
//				)
//				&& _.ContactCodes.Any(c => contactCodes.Contains(c))
//			);
//		}

//		public async Task<bool> AuthorizedAsync(string conversationCode
//			, int userId)
//		{
//			var contactRepo = ServiceProvider.GetService<IConversationContactRepository>();

//			var contactCodes = await contactRepo
//				.ListByUser(userId, null, null, null)
//				.SelectMany(_ => _.Contacts)
//				.Select(_ => _.Code)
//				.ToListAsync();

//			return await AnyAsync(_ =>
//				_.ConversationCode == conversationCode
//				&& _.ContactCodes.Any(c => contactCodes.Contains(c))
//			);
//		}

//		public Task<List<Conversation>> ListByContactAsync(string contactCode)
//		{
//			return GetListAsync(_ => _.ContactCodes.Contains(contactCode));
//		}

//		public Task<Guid> GetIdAsync(string code)
//		{
//			return this.GetList(_ => _.ConversationCode == code)
//				.Select(_ => _.Id)
//				.FirstOrDefaultAsync();
//		}

//		public Task<bool> IsArchivedAsync(Guid id)
//		{
//			return AnyAsync(c =>
//					c.Id == id
//					&& c.Archived
//				);
//		}

//		public Task<List<Conversation>> ListByContactCodesAsync(List<string> contactCodes)
//		{
//			return this.GetListAsync(_ =>
//				_.ContactCodes.Any(c => contactCodes.Contains(c))
//			);
//		}
//	}
//}
