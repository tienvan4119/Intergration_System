namespace Intergration_System
{
	public struct HubConstants
	{
		public struct InvokeEvents
		{
			public struct Notifications
			{
				public const string PUSH_NOTIFICATION = "PushNotification";
			}

			public struct Conversations
			{
				public const string ON_MESSAGE_RECEIVED = "OnMessage_Received";
				public const string ON_UNREAD_CONVERSATIONS_COUNT_CHANGED = "OnUnreadConversationsCount_Changed";
			}
		}

		public struct Http
		{
			public const string JWT_QUERY_KEY = "access_token";
			public const string JWT_ITEM_KEY = "idsrv4:tokenvalidation:token";
		}

		public struct ClaimNames
		{
			public const string USER_ID = "UserId";
			public const string TENANT_ID = "OwnerTenantId";
		}

		public struct EmailTemplateName
		{
			public const string EMAIL_MESSAGE_BODY = "Email_Message_Body";
			public const string EMAIL_MESSAGE_QUOTE = "Email_Message_Quote";
		}

		public struct RouteConstant
		{
			public struct Notification
			{
				public const string PREFIX = "api/hub/notifications";
				public const string USER_NOTIFICATIONS = "user-notifications/{pageNo:int}/{pageSize:int}";
				public const string READ_ALL_NOTIFICATIONS = "read-all-notifications";
				public const string READ_NOTIFICATION = "read-notification";
			}

			public struct Email
			{
				public const string PREFIX = "api/hub/emails";
				public const string SEND_EMAIL = "send";
				public const string MAILGUN_INBOUND = "inbound-webhook";
				public const string SAVE_SETTINGS = "settings/save";
				public const string DELETE_SETTINGS = "settings/remove";
				public const string VERIFY_SETTINGS = "settings/verify";
				public const string THREADS = "threads";
				public const string ARCHIVE = "archive";
			}

			public struct Messenger
			{
				public const string PREFIX = "api/hub/messenger";
				public const string SEND_MESSAGE = "send-text";
				public const string SEND_IMAGE_MESSAGE = "send-image";
				public const string SEND_FILE_MESSAGE = "send-file";
				public const string SAVE_PAGE = "page/save";
				public const string DELETE_PAGE = "page/delete";
			}

			public struct Zalo
			{
				public const string PREFIX = "api/hub/zalo";
				public const string SEND_TEXT = "send-text-message";
				public const string SEND_FILE = "send-attach-message";
				public const string SEND_IMAGE = "send-image-message";
				public const string SEND_GIF = "send-gif-message";
				public const string OA_CONNECT = "connect";
				public const string DELETE_OA = "oa/delete";
			}

			public struct Conversation
			{
				public const string PREFIX = "api/hub/conversations";
				public const string GROUP_MESSAGES = "group-messages";
				public const string CONVERSATION_MESSAGES = "{code}/messages";
				public const string CONVERSATION_THREADS = "conversation-threads";
				public const string USER_SETTINGS = "user-settings";
				public const string USER_CONVERSATIONS = "list";
				public const string IN_USE_GROUP = "{code}/get-in-use-group";
				public const string UNREAD_COUNT = "unread-count";
				public const string MARK_READ = "{code}/mark-read";
				public const string ARCHIVE = "{code}/archive";
				public const string ARCHIVE_ALL = "archive-all";
				public const string CONTACT_SEARCH = "contacts";
			}

			public struct Webhook
			{
				public const string PREFIX = "api/hub/webhooks";
				public const string MESSENGER_INBOUND_MESSAGE = "messenger-inbound-message";
				public const string MESSENGER_VERIFICATION = "messenger-verification";
				public const string MAILGUN_INBOUND_MESSAGE = "mailgun-inbound-message";
				public const string ZALO_INBOUND_MESSAGE = "zalo-inbound-message";
				public const string ZALO_OAUTH_CODE = "zalo-oauth-code";
			}

			public struct Headline
			{
				public const string PREFIX = "api/hub/headlines";
				public const string CURRENT_DATE = "current";
			}

			public struct Reminder
			{
				public const string PREFIX = "api/hub/reminders";
				public const string MARK_READ = "{id}/mark-read";
				public const string PROCESS = "{id}/process";
				public const string SCHEDULE = "{id}/schedule";
				public const string LOOK_UP_TYPES = "types/look-up";
				public const string CALENDAR = "calendar-items";
				public const string READ_OVERVIEW = "types/read-overview";
				public const string MARK_READ_GROUPS = "groups/{id}/mark-read";
				public const string COMPLETE = "{id}/complete";
			}
			public struct Widget
			{
				public const string PREFIX = "api/hub/widgets";
				public const string CURRENT = "current";
			}
		}
	}
}
