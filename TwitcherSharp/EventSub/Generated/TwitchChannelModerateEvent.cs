using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchChannelModerateEvent : Resource, ITwitcherSharpEventSub<TwitchChannelModerateEvent>
{

	/// <summary> 
	/// The ID of the broadcaster.
	/// </summary>
	public string BroadcasterUserId { get; set; }

	/// <summary> 
	/// The login of the broadcaster.
	/// </summary>
	public string BroadcasterUserLogin { get; set; }

	/// <summary> 
	/// The user name of the broadcaster.
	/// </summary>
	public string BroadcasterUserName { get; set; }

	/// <summary> 
	/// The channel in which the action originally occurred. Is the same as the broadcaster_user_id if not in shared chat.
	/// </summary>
	public string SourceBroadcasterUserId { get; set; }

	/// <summary> 
	/// The channel in which the action originally occurred. Is the same as the broadcaster_user_login if not in shared chat.
	/// </summary>
	public string SourceBroadcasterUserLogin { get; set; }

	/// <summary> 
	/// The channel in which the action originally occurred. Is null when the moderator action happens in the same channel as the broadcaster. Is not null when in a shared chat session, and the action happens in the channel of a participant other than the broadcaster.
	/// </summary>
	public string SourceBroadcasterUserName { get; set; }

	/// <summary> 
	/// The ID of the moderator who performed the action.
	/// </summary>
	public string ModeratorUserId { get; set; }

	/// <summary> 
	/// The login of the moderator.
	/// </summary>
	public string ModeratorUserLogin { get; set; }

	/// <summary> 
	/// The user name of the moderator.
	/// </summary>
	public string ModeratorUserName { get; set; }

	/// <summary> 
	/// The type of action: Possible values are: bantimeoutunbanuntimeoutclearemoteonlyemoteonlyofffollowersfollowersoffuniquechatuniquechatoffslowslowoffsubscriberssubscribersoffunraiddeleteunvipvipraidadd_blocked_termadd_permitted_termremove_blocked_termremove_permitted_termmodunmodapprove_unban_requestdeny_unban_requestshared_chat_banshared_chat_timeoutshared_chat_untimeoutshared_chat_unbanshared_chat_delete
	/// </summary>
	public string Action { get; set; }

	/// <summary> 
	/// Optional.. Metadata associated with the followers command.
	/// </summary>
	public object Followers { get; set; }

	/// <summary> 
	/// The length of time, in minutes, that the followers must have followed the broadcaster to participate in the chat room.
	/// </summary>
	public int FollowDurationMinutes { get; set; }

	/// <summary> 
	/// Optional. Metadata associated with the slow command.
	/// </summary>
	public object Slow { get; set; }

	/// <summary> 
	/// The amount of time, in seconds, that users need to wait between sending messages.
	/// </summary>
	public int WaitTimeSeconds { get; set; }

	/// <summary> 
	/// Optional. Metadata associated with the vip command.
	/// </summary>
	public object Vip { get; set; }

	/// <summary> 
	/// The ID of the user gaining VIP status.
	/// </summary>
	public string UserId { get; set; }

	/// <summary> 
	/// The login of the user gaining VIP status.
	/// </summary>
	public string UserLogin { get; set; }

	/// <summary> 
	/// The user name of the user gaining VIP status.
	/// </summary>
	public string UserName { get; set; }

	/// <summary> 
	/// Optional. Metadata associated with the unvip command.
	/// </summary>
	public object Unvip { get; set; }

	/// <summary> 
	/// The ID of the user losing VIP status.
	/// </summary>
	public string UserId { get; set; }

	/// <summary> 
	/// The login of the user losing VIP status.
	/// </summary>
	public string UserLogin { get; set; }

	/// <summary> 
	/// The user name of the user losing VIP status.
	/// </summary>
	public string UserName { get; set; }

	/// <summary> 
	/// Optional. Metadata associated with the mod command.
	/// </summary>
	public object Mod { get; set; }

	/// <summary> 
	/// The ID of the user gaining mod status.
	/// </summary>
	public string UserId { get; set; }

	/// <summary> 
	/// The login of the user gaining mod status.
	/// </summary>
	public string UserLogin { get; set; }

	/// <summary> 
	/// The user name of the user gaining mod status.
	/// </summary>
	public string UserName { get; set; }

	/// <summary> 
	/// Optional. Metadata associated with the unmod command.
	/// </summary>
	public object Unmod { get; set; }

	/// <summary> 
	/// The ID of the user losing mod status.
	/// </summary>
	public string UserId { get; set; }

	/// <summary> 
	/// The login of the user losing mod status.
	/// </summary>
	public string UserLogin { get; set; }

	/// <summary> 
	/// The user name of the user losing mod status.
	/// </summary>
	public string UserName { get; set; }

	/// <summary> 
	/// Optional. Metadata associated with the ban command.
	/// </summary>
	public object Ban { get; set; }

	/// <summary> 
	/// The ID of the user being banned.
	/// </summary>
	public string UserId { get; set; }

	/// <summary> 
	/// The login of the user being banned.
	/// </summary>
	public string UserLogin { get; set; }

	/// <summary> 
	/// The user name of the user being banned.
	/// </summary>
	public string UserName { get; set; }

	/// <summary> 
	/// Optional. Reason given for the ban.
	/// </summary>
	public string Reason { get; set; }

	/// <summary> 
	/// Optional. Metadata associated with the unban command.
	/// </summary>
	public object Unban { get; set; }

	/// <summary> 
	/// The ID of the user being unbanned.
	/// </summary>
	public string UserId { get; set; }

	/// <summary> 
	/// The login of the user being unbanned.
	/// </summary>
	public string UserLogin { get; set; }

	/// <summary> 
	/// The user name of the user being unbanned.
	/// </summary>
	public string UserName { get; set; }

	/// <summary> 
	/// Optional.. Metadata associated with the timeout command.
	/// </summary>
	public object Timeout { get; set; }

	/// <summary> 
	/// The ID of the user being timed out.
	/// </summary>
	public string UserId { get; set; }

	/// <summary> 
	/// The login of the user being timed out.
	/// </summary>
	public string UserLogin { get; set; }

	/// <summary> 
	/// The user name of the user being timed out.
	/// </summary>
	public string UserName { get; set; }

	/// <summary> 
	/// Optional.. The reason given for the timeout.
	/// </summary>
	public string Reason { get; set; }

	/// <summary> 
	/// The time at which the timeout ends.
	/// </summary>
	public string ExpiresAt { get; set; }

	/// <summary> 
	/// Optional. Metadata associated with the untimeout command.
	/// </summary>
	public object Untimeout { get; set; }

	/// <summary> 
	/// The ID of the user being untimed out.
	/// </summary>
	public string UserId { get; set; }

	/// <summary> 
	/// The login of the user being untimed out.
	/// </summary>
	public string UserLogin { get; set; }

	/// <summary> 
	/// The user name of the user untimed out.
	/// </summary>
	public string UserName { get; set; }

	/// <summary> 
	/// Optional.. Metadata associated with the raid command.
	/// </summary>
	public object Raid { get; set; }

	/// <summary> 
	/// The ID of the user being raided.
	/// </summary>
	public string UserId { get; set; }

	/// <summary> 
	/// The login of the user being raided.
	/// </summary>
	public string UserLogin { get; set; }

	/// <summary> 
	/// The user name of the user raided.
	/// </summary>
	public string UserName { get; set; }

	/// <summary> 
	/// The user name of the user raided.
	/// </summary>
	public string UserName { get; set; }

	/// <summary> 
	/// The viewer count.
	/// </summary>
	public int ViewerCount { get; set; }

	/// <summary> 
	/// Optional. Metadata associated with the unraid command.
	/// </summary>
	public object Unraid { get; set; }

	/// <summary> 
	/// The ID of the user no longer being raided.
	/// </summary>
	public string UserId { get; set; }

	/// <summary> 
	/// The login of the user no longer being raided.
	/// </summary>
	public string UserLogin { get; set; }

	/// <summary> 
	/// The user name of the no longer user raided.
	/// </summary>
	public string UserName { get; set; }

	/// <summary> 
	/// Optional. Metadata associated with the delete command.
	/// </summary>
	public object Delete { get; set; }

	/// <summary> 
	/// The ID of the user whose message is being deleted.
	/// </summary>
	public string UserId { get; set; }

	/// <summary> 
	/// The login of the user.
	/// </summary>
	public string UserLogin { get; set; }

	/// <summary> 
	/// The user name of the user.
	/// </summary>
	public string UserName { get; set; }

	/// <summary> 
	/// The ID of the message being deleted.
	/// </summary>
	public string MessageId { get; set; }

	/// <summary> 
	/// The message body of the message being deleted.
	/// </summary>
	public string MessageBody { get; set; }

	/// <summary> 
	/// Optional. Metadata associated with the automod terms changes.
	/// </summary>
	public object AutomodTerms { get; set; }

	/// <summary> 
	/// Either “add” or “remove”.
	/// </summary>
	public string Action { get; set; }

	/// <summary> 
	/// Either “blocked” or “permitted”.
	/// </summary>
	public string List { get; set; }

	/// <summary> 
	/// Whether the terms were added due to an Automod message approve/deny action.
	/// </summary>
	public bool FromAutomod { get; set; }

	/// <summary> 
	/// Optional. Metadata associated with an unban request.
	/// </summary>
	public object UnbanRequest { get; set; }

	/// <summary> 
	/// Whether or not the unban request was approved or denied.
	/// </summary>
	public bool IsApproved { get; set; }

	/// <summary> 
	/// The ID of the banned user.
	/// </summary>
	public string UserId { get; set; }

	/// <summary> 
	/// The login of the user.
	/// </summary>
	public string UserLogin { get; set; }

	/// <summary> 
	/// The user name of the user.
	/// </summary>
	public string UserName { get; set; }

	/// <summary> 
	/// The message included by the moderator explaining their approval or denial.
	/// </summary>
	public string ModeratorMessage { get; set; }

	/// <summary> 
	/// Optional. Information about the shared_chat_ban event. Is null if action is not shared_chat_ban. This field has the same information as the ban field but for a action that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
	/// </summary>
	public object SharedChatBan { get; set; }

	/// <summary> 
	/// Optional. Information about the shared_chat_unban event. Is null if action is not shared_chat_unban. This field has the same information as the unban field but for a action that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
	/// </summary>
	public object SharedChatUnban { get; set; }

	/// <summary> 
	/// Optional. Information about the shared_chat_timeout event. Is null if action is not shared_chat_timeout. This field has the same information as the timeout field but for a action that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
	/// </summary>
	public object SharedChatTimeout { get; set; }

	/// <summary> 
	/// Optional. Information about the shared_chat_untimeout event. Is null if action is not shared_chat_untimeout. This field has the same information as the untimeout field but for a action that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
	/// </summary>
	public object SharedChatUntimeout { get; set; }

	/// <summary> 
	/// Optional. Information about the shared_chat_delete event. Is null if action is not shared_chat_delete. This field has the same information as the delete field but for a action that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
	/// </summary>
	public object SharedChatDelete { get; set; }

	public static TwitchChannelModerateEvent FromData(Dictionary data)
	{
	    return new TwitchChannelModerateEvent
	    {
			BroadcasterUserId = data["broadcaster_user_id"].AsString(),
			BroadcasterUserLogin = data["broadcaster_user_login"].AsString(),
			BroadcasterUserName = data["broadcaster_user_name"].AsString(),
			SourceBroadcasterUserId = data["source_broadcaster_user_id"].AsString(),
			SourceBroadcasterUserLogin = data["source_broadcaster_user_login"].AsString(),
			SourceBroadcasterUserName = data["source_broadcaster_user_name"].AsString(),
			ModeratorUserId = data["moderator_user_id"].AsString(),
			ModeratorUserLogin = data["moderator_user_login"].AsString(),
			ModeratorUserName = data["moderator_user_name"].AsString(),
			Action = data["action"].AsString(),
			Followers = data["followers"].As<object>(),
			FollowDurationMinutes = data["follow_duration_minutes"].AsInt32(),
			Slow = data["slow"].As<object>(),
			WaitTimeSeconds = data["wait_time_seconds"].AsInt32(),
			Vip = data["vip"].As<object>(),
			UserId = data["user_id"].AsString(),
			UserLogin = data["user_login"].AsString(),
			UserName = data["user_name"].AsString(),
			Unvip = data["unvip"].As<object>(),
			UserId = data["user_id"].AsString(),
			UserLogin = data["user_login"].AsString(),
			UserName = data["user_name"].AsString(),
			Mod = data["mod"].As<object>(),
			UserId = data["user_id"].AsString(),
			UserLogin = data["user_login"].AsString(),
			UserName = data["user_name"].AsString(),
			Unmod = data["unmod"].As<object>(),
			UserId = data["user_id"].AsString(),
			UserLogin = data["user_login"].AsString(),
			UserName = data["user_name"].AsString(),
			Ban = data["ban"].As<object>(),
			UserId = data["user_id"].AsString(),
			UserLogin = data["user_login"].AsString(),
			UserName = data["user_name"].AsString(),
			Reason = data["reason"].AsString(),
			Unban = data["unban"].As<object>(),
			UserId = data["user_id"].AsString(),
			UserLogin = data["user_login"].AsString(),
			UserName = data["user_name"].AsString(),
			Timeout = data["timeout"].As<object>(),
			UserId = data["user_id"].AsString(),
			UserLogin = data["user_login"].AsString(),
			UserName = data["user_name"].AsString(),
			Reason = data["reason"].AsString(),
			ExpiresAt = data["expires_at"].AsString(),
			Untimeout = data["untimeout"].As<object>(),
			UserId = data["user_id"].AsString(),
			UserLogin = data["user_login"].AsString(),
			UserName = data["user_name"].AsString(),
			Raid = data["raid"].As<object>(),
			UserId = data["user_id"].AsString(),
			UserLogin = data["user_login"].AsString(),
			UserName = data["user_name"].AsString(),
			UserName = data["user_name"].AsString(),
			ViewerCount = data["viewer_count"].AsInt32(),
			Unraid = data["unraid"].As<object>(),
			UserId = data["user_id"].AsString(),
			UserLogin = data["user_login"].AsString(),
			UserName = data["user_name"].AsString(),
			Delete = data["delete"].As<object>(),
			UserId = data["user_id"].AsString(),
			UserLogin = data["user_login"].AsString(),
			UserName = data["user_name"].AsString(),
			MessageId = data["message_id"].AsString(),
			MessageBody = data["message_body"].AsString(),
			AutomodTerms = data["automod_terms"].As<object>(),
			Action = data["action"].AsString(),
			List = data["list"].AsString(),
			FromAutomod = data["from_automod"].AsBool(),
			UnbanRequest = data["unban_request"].As<object>(),
			IsApproved = data["is_approved"].AsBool(),
			UserId = data["user_id"].AsString(),
			UserLogin = data["user_login"].AsString(),
			UserName = data["user_name"].AsString(),
			ModeratorMessage = data["moderator_message"].AsString(),
			SharedChatBan = data["shared_chat_ban"].As<object>(),
			SharedChatUnban = data["shared_chat_unban"].As<object>(),
			SharedChatTimeout = data["shared_chat_timeout"].As<object>(),
			SharedChatUntimeout = data["shared_chat_untimeout"].As<object>(),
			SharedChatDelete = data["shared_chat_delete"].As<object>(),
		};
	}

}
