using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchChannelSubscriptionGiftEvent : Resource, ITwitcherSharpEventSub<TwitchChannelSubscriptionGiftEvent>
{

	/// <summary> 
	/// The user ID of the user who sent the subscription gift. Set to null if it was an anonymous subscription gift.
	/// </summary>
	public string UserId { get; set; }

	/// <summary> 
	/// The user login of the user who sent the gift. Set to null if it was an anonymous subscription gift.
	/// </summary>
	public string UserLogin { get; set; }

	/// <summary> 
	/// The user display name of the user who sent the gift. Set to null if it was an anonymous subscription gift.
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
	/// The number of subscriptions in the subscription gift.
	/// </summary>
	public int Total { get; set; }

	/// <summary> 
	/// The tier of subscriptions in the subscription gift.
	/// </summary>
	public string Tier { get; set; }

	/// <summary> 
	/// The number of subscriptions gifted by this user in the channel. This value is null for anonymous gifts or if the gifter has opted out of sharing this information.
	/// </summary>
	public int CumulativeTotal { get; set; }

	/// <summary> 
	/// Whether the subscription gift was anonymous.
	/// </summary>
	public bool IsAnonymous { get; set; }

	public static TwitchChannelSubscriptionGiftEvent FromData(Dictionary data)
	{
	    return new TwitchChannelSubscriptionGiftEvent
	    {
			UserId = data["user_id"].AsString(),
			UserLogin = data["user_login"].AsString(),
			UserName = data["user_name"].AsString(),
			BroadcasterUserId = data["broadcaster_user_id"].AsString(),
			BroadcasterUserLogin = data["broadcaster_user_login"].AsString(),
			BroadcasterUserName = data["broadcaster_user_name"].AsString(),
			Total = data["total"].AsInt32(),
			Tier = data["tier"].AsString(),
			CumulativeTotal = data["cumulative_total"].AsInt32(),
			IsAnonymous = data["is_anonymous"].AsBool(),
		};
	}

}
