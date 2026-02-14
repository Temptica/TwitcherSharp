using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchChannelPointsCustomRewardRedemptionAddEvent : Resource, ITwitcherSharpEventSub<TwitchChannelPointsCustomRewardRedemptionAddEvent>
{

	/// <summary> 
	/// The redemption identifier.
	/// </summary>
	public string Id { get; set; }

	/// <summary> 
	/// The requested broadcaster ID.
	/// </summary>
	public string BroadcasterUserId { get; set; }

	/// <summary> 
	/// The requested broadcaster login.
	/// </summary>
	public string BroadcasterUserLogin { get; set; }

	/// <summary> 
	/// The requested broadcaster display name.
	/// </summary>
	public string BroadcasterUserName { get; set; }

	/// <summary> 
	/// User ID of the user that redeemed the reward.
	/// </summary>
	public string UserId { get; set; }

	/// <summary> 
	/// Login of the user that redeemed the reward.
	/// </summary>
	public string UserLogin { get; set; }

	/// <summary> 
	/// Display name of the user that redeemed the reward.
	/// </summary>
	public string UserName { get; set; }

	/// <summary> 
	/// The user input provided. Empty string if not provided.
	/// </summary>
	public string UserInput { get; set; }

	/// <summary> 
	/// Defaults to unfulfilled. Possible values are unknown, unfulfilled, fulfilled, and canceled.
	/// </summary>
	public string Status { get; set; }

	/// <summary> 
	/// 
	/// </summary>
	public TwitchReward Reward { get; set; }

	/// <summary> 
	/// RFC3339 timestamp of when the reward was redeemed.
	/// </summary>
	public string RedeemedAt { get; set; }

	public static TwitchChannelPointsCustomRewardRedemptionAddEvent FromData(Dictionary data)
	{
	    return new TwitchChannelPointsCustomRewardRedemptionAddEvent
	    {
			Id = data["id"].AsString(),
			BroadcasterUserId = data["broadcaster_user_id"].AsString(),
			BroadcasterUserLogin = data["broadcaster_user_login"].AsString(),
			BroadcasterUserName = data["broadcaster_user_name"].AsString(),
			UserId = data["user_id"].AsString(),
			UserLogin = data["user_login"].AsString(),
			UserName = data["user_name"].AsString(),
			UserInput = data["user_input"].AsString(),
			Status = data["status"].AsString(),
			Reward = TwitchReward.FromData(data["reward"].AsGodotDictionary()),
			RedeemedAt = data["redeemed_at"].AsString(),
		};
	}

}
