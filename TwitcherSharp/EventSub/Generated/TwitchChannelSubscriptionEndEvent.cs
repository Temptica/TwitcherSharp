using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchChannelSubscriptionEndEvent : Resource, ITwitcherSharpEventSub<TwitchChannelSubscriptionEndEvent>
{

	/// <summary> 
	/// The user ID for the user whose subscription ended.
	/// </summary>
	public string UserId { get; set; }

	/// <summary> 
	/// The user login for the user whose subscription ended.
	/// </summary>
	public string UserLogin { get; set; }

	/// <summary> 
	/// The user display name for the user whose subscription ended.
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
	/// The tier of the subscription that ended. Valid values are 1000, 2000, and 3000.
	/// </summary>
	public string Tier { get; set; }

	/// <summary> 
	/// Whether the subscription was a gift.
	/// </summary>
	public bool IsGift { get; set; }

	public static TwitchChannelSubscriptionEndEvent FromData(Dictionary data)
	{
	    return new TwitchChannelSubscriptionEndEvent
	    {
			UserId = data["user_id"].AsString(),
			UserLogin = data["user_login"].AsString(),
			UserName = data["user_name"].AsString(),
			BroadcasterUserId = data["broadcaster_user_id"].AsString(),
			BroadcasterUserLogin = data["broadcaster_user_login"].AsString(),
			BroadcasterUserName = data["broadcaster_user_name"].AsString(),
			Tier = data["tier"].AsString(),
			IsGift = data["is_gift"].AsBool(),
		};
	}

}
