using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchChannelChatSettingsUpdateEvent : Resource, ITwitcherSharpEventSub<TwitchChannelChatSettingsUpdateEvent>
{

	/// <summary> 
	/// The ID of the broadcaster specified in the request.
	/// </summary>
	public string BroadcasterUserId { get; set; }

	/// <summary> 
	/// The login of the broadcaster specified in the request.
	/// </summary>
	public string BroadcasterUserLogin { get; set; }

	/// <summary> 
	/// The user name of the broadcaster specified in the request.
	/// </summary>
	public string BroadcasterUserName { get; set; }

	/// <summary> 
	/// A Boolean value that determines whether chat messages must contain only emotes. True if only messages that are 100% emotes are allowed; otherwise false.
	/// </summary>
	public bool EmoteMode { get; set; }

	/// <summary> 
	/// A Boolean value that determines whether the broadcaster restricts the chat room to followers only, based on how long they’ve followed.True if the broadcaster restricts the chat room to followers only; otherwise false.See follower_mode_duration_minutes for how long the followers must have followed the broadcaster to participate in the chat room.
	/// </summary>
	public bool FollowerMode { get; set; }

	/// <summary> 
	/// The length of time, in minutes, that the followers must have followed the broadcaster to participate in the chat room. See follower_mode.Null if follower_mode is false.
	/// </summary>
	public int FollowerModeDurationMinutes { get; set; }

	/// <summary> 
	/// A Boolean value that determines whether the broadcaster limits how often users in the chat room are allowed to send messages.Is true, if the broadcaster applies a delay; otherwise, false.See slow_mode_wait_time_seconds for the delay.
	/// </summary>
	public bool SlowMode { get; set; }

	/// <summary> 
	/// The amount of time, in seconds, that users need to wait between sending messages. See slow_mode.Null if slow_mode is false.
	/// </summary>
	public int SlowModeWaitTimeSeconds { get; set; }

	/// <summary> 
	/// A Boolean value that determines whether only users that subscribe to the broadcaster’s channel can talk in the chat room.True if the broadcaster restricts the chat room to subscribers only; otherwise false.
	/// </summary>
	public bool SubscriberMode { get; set; }

	/// <summary> 
	/// A Boolean value that determines whether the broadcaster requires users to post only unique messages in the chat room.True if the broadcaster requires unique messages only; otherwise false.
	/// </summary>
	public bool UniqueChatMode { get; set; }

	public static TwitchChannelChatSettingsUpdateEvent FromData(Dictionary data)
	{
	    return new TwitchChannelChatSettingsUpdateEvent
	    {
			BroadcasterUserId = data["broadcaster_user_id"].AsString(),
			BroadcasterUserLogin = data["broadcaster_user_login"].AsString(),
			BroadcasterUserName = data["broadcaster_user_name"].AsString(),
			EmoteMode = data["emote_mode"].AsBool(),
			FollowerMode = data["follower_mode"].AsBool(),
			FollowerModeDurationMinutes = data["follower_mode_duration_minutes"].AsInt32(),
			SlowMode = data["slow_mode"].AsBool(),
			SlowModeWaitTimeSeconds = data["slow_mode_wait_time_seconds"].AsInt32(),
			SubscriberMode = data["subscriber_mode"].AsBool(),
			UniqueChatMode = data["unique_chat_mode"].AsBool(),
		};
	}

}
