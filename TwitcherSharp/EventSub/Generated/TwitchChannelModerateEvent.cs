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
	public TwitchFollowers Followers { get; set; }

	/// <summary> 
	/// Optional. Metadata associated with the slow command.
	/// </summary>
	public TwitchSlow Slow { get; set; }

	/// <summary> 
	/// Optional. Metadata associated with the vip command.
	/// </summary>
	public TwitchVip Vip { get; set; }

	/// <summary> 
	/// Optional. Metadata associated with the unvip command.
	/// </summary>
	public TwitchUnvip Unvip { get; set; }

	/// <summary> 
	/// Optional. Metadata associated with the mod command.
	/// </summary>
	public TwitchMod Mod { get; set; }

	/// <summary> 
	/// Optional. Metadata associated with the unmod command.
	/// </summary>
	public TwitchUnmod Unmod { get; set; }

	/// <summary> 
	/// Optional. Metadata associated with the ban command.
	/// </summary>
	public TwitchBan Ban { get; set; }

	/// <summary> 
	/// Optional. Metadata associated with the unban command.
	/// </summary>
	public TwitchUnban Unban { get; set; }

	/// <summary> 
	/// Optional.. Metadata associated with the timeout command.
	/// </summary>
	public TwitchTimeout Timeout { get; set; }

	/// <summary> 
	/// Optional. Metadata associated with the untimeout command.
	/// </summary>
	public TwitchUntimeout Untimeout { get; set; }

	/// <summary> 
	/// Optional.. Metadata associated with the raid command.
	/// </summary>
	public TwitchRaid Raid { get; set; }

	/// <summary> 
	/// Optional. Metadata associated with the unraid command.
	/// </summary>
	public TwitchUnraid Unraid { get; set; }

	/// <summary> 
	/// Optional. Metadata associated with the delete command.
	/// </summary>
	public TwitchDelete Delete { get; set; }

	/// <summary> 
	/// Optional. Metadata associated with the automod terms changes.
	/// </summary>
	public TwitchAutomodTerms AutomodTerms { get; set; }

	/// <summary> 
	/// Optional. Metadata associated with an unban request.
	/// </summary>
	public TwitchUnbanRequest UnbanRequest { get; set; }

	/// <summary> 
	/// Optional. Information about the shared_chat_ban event. Is null if action is not shared_chat_ban. This field has the same information as the ban field but for a action that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
	/// </summary>
	public TwitchSharedChatBan SharedChatBan { get; set; }

	/// <summary> 
	/// Optional. Information about the shared_chat_unban event. Is null if action is not shared_chat_unban. This field has the same information as the unban field but for a action that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
	/// </summary>
	public TwitchSharedChatUnban SharedChatUnban { get; set; }

	/// <summary> 
	/// Optional. Information about the shared_chat_timeout event. Is null if action is not shared_chat_timeout. This field has the same information as the timeout field but for a action that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
	/// </summary>
	public TwitchSharedChatTimeout SharedChatTimeout { get; set; }

	/// <summary> 
	/// Optional. Information about the shared_chat_untimeout event. Is null if action is not shared_chat_untimeout. This field has the same information as the untimeout field but for a action that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
	/// </summary>
	public TwitchSharedChatUntimeout SharedChatUntimeout { get; set; }

	/// <summary> 
	/// Optional. Information about the shared_chat_delete event. Is null if action is not shared_chat_delete. This field has the same information as the delete field but for a action that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
	/// </summary>
	public TwitchSharedChatDelete SharedChatDelete { get; set; }

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
			Followers = TwitchFollowers.FromData(data["followers"].AsGodotDictionary()),
			Slow = TwitchSlow.FromData(data["slow"].AsGodotDictionary()),
			Vip = TwitchVip.FromData(data["vip"].AsGodotDictionary()),
			Unvip = TwitchUnvip.FromData(data["unvip"].AsGodotDictionary()),
			Mod = TwitchMod.FromData(data["mod"].AsGodotDictionary()),
			Unmod = TwitchUnmod.FromData(data["unmod"].AsGodotDictionary()),
			Ban = TwitchBan.FromData(data["ban"].AsGodotDictionary()),
			Unban = TwitchUnban.FromData(data["unban"].AsGodotDictionary()),
			Timeout = TwitchTimeout.FromData(data["timeout"].AsGodotDictionary()),
			Untimeout = TwitchUntimeout.FromData(data["untimeout"].AsGodotDictionary()),
			Raid = TwitchRaid.FromData(data["raid"].AsGodotDictionary()),
			Unraid = TwitchUnraid.FromData(data["unraid"].AsGodotDictionary()),
			Delete = TwitchDelete.FromData(data["delete"].AsGodotDictionary()),
			AutomodTerms = TwitchAutomodTerms.FromData(data["automod_terms"].AsGodotDictionary()),
			UnbanRequest = TwitchUnbanRequest.FromData(data["unban_request"].AsGodotDictionary()),
			SharedChatBan = TwitchSharedChatBan.FromData(data["shared_chat_ban"].AsGodotDictionary()),
			SharedChatUnban = TwitchSharedChatUnban.FromData(data["shared_chat_unban"].AsGodotDictionary()),
			SharedChatTimeout = TwitchSharedChatTimeout.FromData(data["shared_chat_timeout"].AsGodotDictionary()),
			SharedChatUntimeout = TwitchSharedChatUntimeout.FromData(data["shared_chat_untimeout"].AsGodotDictionary()),
			SharedChatDelete = TwitchSharedChatDelete.FromData(data["shared_chat_delete"].AsGodotDictionary()),
		};
	}

public partial class TwitchFollowers : Resource, ITwitcherSharpEventSub<TwitchFollowers>
{

	/// <summary> 
	/// The length of time, in minutes, that the followers must have followed the broadcaster to participate in the chat room.
	/// </summary>
	public int FollowDurationMinutes { get; set; }

	public static TwitchFollowers FromData(Dictionary data)
	{
	    return new TwitchFollowers
	    {
			FollowDurationMinutes = data["follow_duration_minutes"].AsInt32(),
		};
	}

}
public partial class TwitchSlow : Resource, ITwitcherSharpEventSub<TwitchSlow>
{

	/// <summary> 
	/// The amount of time, in seconds, that users need to wait between sending messages.
	/// </summary>
	public int WaitTimeSeconds { get; set; }

	public static TwitchSlow FromData(Dictionary data)
	{
	    return new TwitchSlow
	    {
			WaitTimeSeconds = data["wait_time_seconds"].AsInt32(),
		};
	}

}
public partial class TwitchVip : Resource, ITwitcherSharpEventSub<TwitchVip>
{

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

	public static TwitchVip FromData(Dictionary data)
	{
	    return new TwitchVip
	    {
			UserId = data["user_id"].AsString(),
			UserLogin = data["user_login"].AsString(),
			UserName = data["user_name"].AsString(),
		};
	}

}
public partial class TwitchUnvip : Resource, ITwitcherSharpEventSub<TwitchUnvip>
{

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

	public static TwitchUnvip FromData(Dictionary data)
	{
	    return new TwitchUnvip
	    {
			UserId = data["user_id"].AsString(),
			UserLogin = data["user_login"].AsString(),
			UserName = data["user_name"].AsString(),
		};
	}

}
public partial class TwitchMod : Resource, ITwitcherSharpEventSub<TwitchMod>
{

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

	public static TwitchMod FromData(Dictionary data)
	{
	    return new TwitchMod
	    {
			UserId = data["user_id"].AsString(),
			UserLogin = data["user_login"].AsString(),
			UserName = data["user_name"].AsString(),
		};
	}

}
public partial class TwitchUnmod : Resource, ITwitcherSharpEventSub<TwitchUnmod>
{

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

	public static TwitchUnmod FromData(Dictionary data)
	{
	    return new TwitchUnmod
	    {
			UserId = data["user_id"].AsString(),
			UserLogin = data["user_login"].AsString(),
			UserName = data["user_name"].AsString(),
		};
	}

}
public partial class TwitchBan : Resource, ITwitcherSharpEventSub<TwitchBan>
{

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

	public static TwitchBan FromData(Dictionary data)
	{
	    return new TwitchBan
	    {
			UserId = data["user_id"].AsString(),
			UserLogin = data["user_login"].AsString(),
			UserName = data["user_name"].AsString(),
			Reason = data["reason"].AsString(),
		};
	}

}
public partial class TwitchUnban : Resource, ITwitcherSharpEventSub<TwitchUnban>
{

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

	public static TwitchUnban FromData(Dictionary data)
	{
	    return new TwitchUnban
	    {
			UserId = data["user_id"].AsString(),
			UserLogin = data["user_login"].AsString(),
			UserName = data["user_name"].AsString(),
		};
	}

}
public partial class TwitchTimeout : Resource, ITwitcherSharpEventSub<TwitchTimeout>
{

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

	public static TwitchTimeout FromData(Dictionary data)
	{
	    return new TwitchTimeout
	    {
			UserId = data["user_id"].AsString(),
			UserLogin = data["user_login"].AsString(),
			UserName = data["user_name"].AsString(),
			Reason = data["reason"].AsString(),
			ExpiresAt = data["expires_at"].AsString(),
		};
	}

}
public partial class TwitchUntimeout : Resource, ITwitcherSharpEventSub<TwitchUntimeout>
{

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

	public static TwitchUntimeout FromData(Dictionary data)
	{
	    return new TwitchUntimeout
	    {
			UserId = data["user_id"].AsString(),
			UserLogin = data["user_login"].AsString(),
			UserName = data["user_name"].AsString(),
		};
	}

}
public partial class TwitchRaid : Resource, ITwitcherSharpEventSub<TwitchRaid>
{

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
	/// The viewer count.
	/// </summary>
	public int ViewerCount { get; set; }

	public static TwitchRaid FromData(Dictionary data)
	{
	    return new TwitchRaid
	    {
			UserId = data["user_id"].AsString(),
			UserLogin = data["user_login"].AsString(),
			UserName = data["user_name"].AsString(),
			ViewerCount = data["viewer_count"].AsInt32(),
		};
	}

}
public partial class TwitchUnraid : Resource, ITwitcherSharpEventSub<TwitchUnraid>
{

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

	public static TwitchUnraid FromData(Dictionary data)
	{
	    return new TwitchUnraid
	    {
			UserId = data["user_id"].AsString(),
			UserLogin = data["user_login"].AsString(),
			UserName = data["user_name"].AsString(),
		};
	}

}
public partial class TwitchDelete : Resource, ITwitcherSharpEventSub<TwitchDelete>
{

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

	public static TwitchDelete FromData(Dictionary data)
	{
	    return new TwitchDelete
	    {
			UserId = data["user_id"].AsString(),
			UserLogin = data["user_login"].AsString(),
			UserName = data["user_name"].AsString(),
			MessageId = data["message_id"].AsString(),
			MessageBody = data["message_body"].AsString(),
		};
	}

}
public partial class TwitchAutomodTerms : Resource, ITwitcherSharpEventSub<TwitchAutomodTerms>
{

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

	public static TwitchAutomodTerms FromData(Dictionary data)
	{
	    return new TwitchAutomodTerms
	    {
			Action = data["action"].AsString(),
			List = data["list"].AsString(),
			FromAutomod = data["from_automod"].AsBool(),
		};
	}

}
public partial class TwitchUnbanRequest : Resource, ITwitcherSharpEventSub<TwitchUnbanRequest>
{

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

	public static TwitchUnbanRequest FromData(Dictionary data)
	{
	    return new TwitchUnbanRequest
	    {
			IsApproved = data["is_approved"].AsBool(),
			UserId = data["user_id"].AsString(),
			UserLogin = data["user_login"].AsString(),
			UserName = data["user_name"].AsString(),
			ModeratorMessage = data["moderator_message"].AsString(),
		};
	}

}
public partial class TwitchSharedChatBan : Resource, ITwitcherSharpEventSub<TwitchSharedChatBan>
{

	public static TwitchSharedChatBan FromData(Dictionary data)
	{
	    return new TwitchSharedChatBan
	    {
		};
	}

}
public partial class TwitchSharedChatUnban : Resource, ITwitcherSharpEventSub<TwitchSharedChatUnban>
{

	public static TwitchSharedChatUnban FromData(Dictionary data)
	{
	    return new TwitchSharedChatUnban
	    {
		};
	}

}
public partial class TwitchSharedChatTimeout : Resource, ITwitcherSharpEventSub<TwitchSharedChatTimeout>
{

	public static TwitchSharedChatTimeout FromData(Dictionary data)
	{
	    return new TwitchSharedChatTimeout
	    {
		};
	}

}
public partial class TwitchSharedChatUntimeout : Resource, ITwitcherSharpEventSub<TwitchSharedChatUntimeout>
{

	public static TwitchSharedChatUntimeout FromData(Dictionary data)
	{
	    return new TwitchSharedChatUntimeout
	    {
		};
	}

}
public partial class TwitchSharedChatDelete : Resource, ITwitcherSharpEventSub<TwitchSharedChatDelete>
{

	public static TwitchSharedChatDelete FromData(Dictionary data)
	{
	    return new TwitchSharedChatDelete
	    {
		};
	}

}

}
