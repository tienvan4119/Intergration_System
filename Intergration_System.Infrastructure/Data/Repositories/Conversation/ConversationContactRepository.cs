//using ELDesk.Hub.Domain.Contacts;
//using ELDesk.Hub.Domain.Interfaces;
//using ELDesk.Hub.Domain.UserLogins;
//using ELDesk.Shared.Infrastructure;
//using Microsoft.Extensions.DependencyInjection;
//using MongoDB.Driver;
//using MongoDB.Driver.Linq;
//using System;
//using System.Linq;
//using System.Threading.Tasks;
//using static ELDesk.Hub.Domain.Enums.ConversationEnum;

//namespace ELDesk.Hub.Infrastructure.Repositories
//{
//	public class ConversationContactRepository : HubRepository<ConversationContact>
//		, IConversationContactRepository
//	{
//		public ConversationContactRepository(
//			HubMongoDatabaseOptions options
//			, IServiceProvider serviceProvider
//			) : base(options, serviceProvider)
//		{
//		}

//		public Task<ConversationContact> FindByContactAsync(string contactCode)
//		{
//			return GetAsync(_ => _.Contacts.Any(c => c.Code == contactCode));
//		}

//		public IMongoQueryable<ConversationContact> GetThreads(string contactCode
//			, string search
//			, Guid loginId)
//		{
//			search = search ?? "";
//			bool isSearch = !string.IsNullOrEmpty(search);
//			return GetList(_ => _.LoginId == loginId
//				&& _.Contacts.Any(_ => _.Code.Contains(contactCode))
//				&& (
//					!isSearch
//					|| _.LatestConversation.Name.Contains(search)
//				)
//			);
//		}

//		public Task<bool> IsContactExistAsync(string contactCode)
//		{
//			return this.AnyAsync(_ => _.Contacts.Any(c => c.Code == contactCode));
//		}

//		public Task<bool> IsUserAuthorizedAsync(string contactCode
//			, int userId
//			, ConversationType type)
//		{
//			var loginRepo = this.ServiceProvider.GetService<IUserLoginRepository>();

//			var find = (from c in this.AsQueryable()
//						join l in loginRepo.AsQueryable() on c.LoginId equals l.Id
//						where
//							c.Type == type
//							&& c.Contacts.Any(c => c.Code == contactCode)
//							&& l.Type == type
//							&& l.Users.Any(u => u.UserId == userId)
//						select c.Id);
//			return find.AnyAsync();
//		}

//		public Task<bool> IsUserAuthorizedAsync(Guid id
//			, int userId
//			, ConversationType type)
//		{
//			var loginRepo = this.ServiceProvider.GetService<IUserLoginRepository>();

//			var find = (from c in this.AsQueryable()
//						join l in loginRepo.AsQueryable() on c.LoginId equals l.Id
//						where
//							c.Id == id
//							&& c.Type == type
//							&& l.Type == type
//							&& l.Users.Any(u => u.UserId == userId)
//						select c.Id);

//			return find.AnyAsync();
//		}

//		public IMongoQueryable<ConversationContact> ListByContactCodes(params string[] contactCodes)
//		{
//			bool hasCodes = contactCodes?.Any() == true;
//			return GetList(_ => hasCodes && _.Contacts.Any(c => contactCodes.Contains(c.Code)));
//		}

//		public IMongoQueryable<ConversationContact> ListByUser(int userId
//			, bool? isArchived
//			, ConversationType? type
//			, string search)
//		{
//			search = search?.ToLower() ?? string.Empty;
//			bool searchType = type.HasValue;
//			bool searchText = !string.IsNullOrEmpty(search);
//			bool searchArchived = isArchived.HasValue;

//			var loginRepo = ServiceProvider.GetService<IHubRepository<UserLogin>>();
//			var loginIds = loginRepo
//				.GetList(_ => _.Users.Any(u => u.UserId == userId))
//				.Select(_ => _.Id)
//				.ToList();

//			return GetList(_ =>
//				(
//					!searchType
//					|| _.Type == type
//				)
//				&& (
//					!searchText
//					|| _.Contacts.Any(c => c.DisplayName.ToLower().Contains(search))
//				)
//				&& loginIds.Contains(_.LoginId)
//				&& (
//					!searchArchived
//					|| _.LatestConversation.IsArchived == isArchived
//				));
//		}
//	}
//}
