//using ELDesk.Hub.Domain.Entities;
//using ELDesk.Hub.Domain.Messengers;
//using ELDesk.Hub.Domain.UserLogins;
//using Microsoft.Extensions.DependencyInjection;
//using System;
//using System.Threading.Tasks;
//using static ELDesk.Hub.Domain.Enums.ConversationEnum;

//namespace ELDesk.Hub.Infrastructure.Repositories
//{
//	public class MessengerPageRepository : HubRepository<MessengerPage>
//		, IMessengerPageRepository
//	{
//		public MessengerPageRepository(HubMongoDatabaseOptions options
//			, IServiceProvider serviceProvider
//			) : base(options, serviceProvider)
//		{
//		}

//		public async Task<MessengerPage> GetByUserAsync(int userId)
//		{
//			var loginRepo = ServiceProvider.GetService<IUserLoginRepository>();
//			var login = await loginRepo.GetLoginAsync(userId, ConversationType.Messenger);
//			if (login != null)
//			{
//				return await GetAsync(_ => _.Id == login.SettingId);
//			}

//			return default;
//		}
//	}
//}
