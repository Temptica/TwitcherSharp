using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchChannelSubscriptionMessageEvent : Resource, ITwitcherSharpEventSub<TwitchChannelSubscriptionMessageEvent>
{

	/// <summary> 
	/// The user ID of the user who sent a resubscription chat message.
	/// </summary>
	public string UserId { get; set; }

	/// <summary> 
	/// The user login of the user who sent a resubscription chat message.
	/// </summary>
	public string UserLogin { get; set; }

	/// <summary> 
	/// The user display name of the user who a resubscription chat message.
	/// </summary>
	public string UserName { get; set; }

	/// <summary> 
	/// The broadcaster user ID.
	/// </summary>
	public string BroadcasterUserId { get; set; }

	/// <summary> 
	/// The broadcaster login.
	/// </summary>
	public string BroadcasterUserLogin { get; set; }

	/// <summary> 
	/// The broadcaster display name.
	/// </summary>
	public string BroadcasterUserName { get; set; }

	/// <summary> 
	/// The tier of the user’s subscription.
	/// </summary>
	public string Tier { get; set; }

	/// <summary> 
	/// An object that contains the resubscription message and emote information needed to recreate the message.
	/// </summary>
	public message Message { get; set; }

	/// <summary> 
	/// The total number of months the user has been subscribed to the channel.
	/// </summary>
	public int CumulativeMonths { get; set; }

	/// <summary> 
	/// The number of consecutive months the user’s current subscription has been active. This value is null if the user has opted out of sharing this information.
	/// </summary>
	public int StreakMonths { get; set; }

	/// <summary> 
	/// The month duration of the subscription.
	/// </summary>
	public int DurationMonths { get; set; }

	public static TwitchChannelSubscriptionMessageEvent FromData(Dictionary data)
	{
	    return new TwitchChannelSubscriptionMessageEvent
	    {
			UserId = data["user_id"].AsString(),
			UserLogin = data["user_login"].AsString(),
			UserName = data["user_name"].AsString(),
			BroadcasterUserId = data["broadcaster_user_id"].AsString(),
			BroadcasterUserLogin = data["broadcaster_user_login"].AsString(),
			BroadcasterUserName = data["broadcaster_user_name"].AsString(),
			Tier = data["tier"].AsString(),
			Message = data["message"].As<message>(),
			CumulativeMonths = data["cumulative_months"].AsInt32(),
			StreakMonths = data["streak_months"].AsInt32(),
			DurationMonths = data["duration_months"].AsInt32(),
		};
	}

}
