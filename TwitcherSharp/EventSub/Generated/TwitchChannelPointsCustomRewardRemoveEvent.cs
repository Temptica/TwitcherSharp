using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchChannelPointsCustomRewardRemoveEvent : Resource, ITwitcherSharpEventSub<TwitchChannelPointsCustomRewardRemoveEvent>
{

	/// <summary> 
	/// The reward identifier.
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
	/// Is the reward currently enabled. If false, the reward won’t show up to viewers.
	/// </summary>
	public bool IsEnabled { get; set; }

	/// <summary> 
	/// Is the reward currently paused. If true, viewers can’t redeem.
	/// </summary>
	public bool IsPaused { get; set; }

	/// <summary> 
	/// Is the reward currently in stock. If false, viewers can’t redeem.
	/// </summary>
	public bool IsInStock { get; set; }

	/// <summary> 
	/// The reward title.
	/// </summary>
	public string Title { get; set; }

	/// <summary> 
	/// The reward cost.
	/// </summary>
	public int Cost { get; set; }

	/// <summary> 
	/// The reward description.
	/// </summary>
	public string Prompt { get; set; }

	/// <summary> 
	/// Does the viewer need to enter information when redeeming the reward.
	/// </summary>
	public bool IsUserInputRequired { get; set; }

	/// <summary> 
	/// Should redemptions be set to fulfilled status immediately when redeemed and skip the request queue instead of the normal unfulfilled status.
	/// </summary>
	public bool ShouldRedemptionsSkipRequestQueue { get; set; }

	/// <summary> 
	/// Whether a maximum per stream is enabled and what the maximum is.
	/// </summary>
	public max_per_stream MaxPerStream { get; set; }

	/// <summary> 
	/// Whether a maximum per user per stream is enabled and what the maximum is.
	/// </summary>
	public max_per_user_per_stream MaxPerUserPerStream { get; set; }

	/// <summary> 
	/// Custom background color for the reward. Format: Hex with # prefix. Example: #FA1ED2.
	/// </summary>
	public string BackgroundColor { get; set; }

	/// <summary> 
	/// Set of custom images of 1x, 2x and 4x sizes for the reward. Can be null if no images have been uploaded.
	/// </summary>
	public image Image { get; set; }

	/// <summary> 
	/// Set of default images of 1x, 2x and 4x sizes for the reward.
	/// </summary>
	public image DefaultImage { get; set; }

	/// <summary> 
	/// Whether a cooldown is enabled and what the cooldown is in seconds.
	/// </summary>
	public global_cooldown GlobalCooldown { get; set; }

	/// <summary> 
	/// Timestamp of the cooldown expiration. null if the reward isn’t on cooldown.
	/// </summary>
	public string CooldownExpiresAt { get; set; }

	/// <summary> 
	/// The number of redemptions redeemed during the current live stream. Counts against the max_per_stream limit. null if the broadcasters stream isn’t live or max_per_stream isn’t enabled.
	/// </summary>
	public int RedemptionsRedeemedCurrentStream { get; set; }

	public static TwitchChannelPointsCustomRewardRemoveEvent FromData(Dictionary data)
	{
	    return new TwitchChannelPointsCustomRewardRemoveEvent
	    {
			Id = data["id"].AsString(),
			BroadcasterUserId = data["broadcaster_user_id"].AsString(),
			BroadcasterUserLogin = data["broadcaster_user_login"].AsString(),
			BroadcasterUserName = data["broadcaster_user_name"].AsString(),
			IsEnabled = data["is_enabled"].AsBool(),
			IsPaused = data["is_paused"].AsBool(),
			IsInStock = data["is_in_stock"].AsBool(),
			Title = data["title"].AsString(),
			Cost = data["cost"].AsInt32(),
			Prompt = data["prompt"].AsString(),
			IsUserInputRequired = data["is_user_input_required"].AsBool(),
			ShouldRedemptionsSkipRequestQueue = data["should_redemptions_skip_request_queue"].AsBool(),
			MaxPerStream = data["max_per_stream"].As<max_per_stream>(),
			MaxPerUserPerStream = data["max_per_user_per_stream"].As<max_per_user_per_stream>(),
			BackgroundColor = data["background_color"].AsString(),
			Image = data["image"].As<image>(),
			DefaultImage = data["default_image"].As<image>(),
			GlobalCooldown = data["global_cooldown"].As<global_cooldown>(),
			CooldownExpiresAt = data["cooldown_expires_at"].AsString(),
			RedemptionsRedeemedCurrentStream = data["redemptions_redeemed_current_stream"].AsInt32(),
		};
	}

}
