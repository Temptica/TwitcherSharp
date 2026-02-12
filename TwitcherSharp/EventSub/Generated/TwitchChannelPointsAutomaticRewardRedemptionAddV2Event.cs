using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchChannelPointsAutomaticRewardRedemptionAddV2Event : Resource, ITwitcherSharpEventSub<TwitchChannelPointsAutomaticRewardRedemptionAddV2Event>
{

	/// <summary> 
	/// The ID of the channel where the reward was redeemed.
	/// </summary>
	public string BroadcasterUserId { get; set; }

	/// <summary> 
	/// The login of the channel where the reward was redeemed.
	/// </summary>
	public string BroadcasterUserLogin { get; set; }

	/// <summary> 
	/// The display name of the channel where the reward was redeemed.
	/// </summary>
	public string BroadcasterUserName { get; set; }

	/// <summary> 
	/// The ID of the redeeming user.
	/// </summary>
	public string UserId { get; set; }

	/// <summary> 
	/// The login of the redeeming user.
	/// </summary>
	public string UserLogin { get; set; }

	/// <summary> 
	/// The display name of the redeeming user.
	/// </summary>
	public string UserName { get; set; }

	/// <summary> 
	/// The ID of the Redemption.
	/// </summary>
	public string Id { get; set; }

	/// <summary> 
	/// An object that contains the reward information.
	/// </summary>
	public object Reward { get; set; }

	/// <summary> 
	/// The type of reward. One of:  single_message_bypass_sub_modesend_highlighted_messagerandom_sub_emote_unlockchosen_sub_emote_unlockchosen_modified_sub_emote_unlock
	/// </summary>
	public string Type { get; set; }

	/// <summary> 
	/// Number of channel points used.
	/// </summary>
	public int ChannelPoints { get; set; }

	/// <summary> 
	/// Optional. Emote associated with the reward.
	/// </summary>
	public object Emote { get; set; }

	/// <summary> 
	/// The emote ID.
	/// </summary>
	public string Id { get; set; }

	/// <summary> 
	/// The human readable emote token.
	/// </summary>
	public string Name { get; set; }

	/// <summary> 
	/// Optional. An object that contains the user message and emote information needed to recreate the message.
	/// </summary>
	public object Message { get; set; }

	/// <summary> 
	/// The chat message in plain text.
	/// </summary>
	public string Text { get; set; }

	/// <summary> 
	/// The ordered list of chat message fragments.
	/// </summary>
	public array Fragments { get; set; }

	/// <summary> 
	/// The message text in fragment.
	/// </summary>
	public string Text { get; set; }

	/// <summary> 
	/// The type of message fragment. Possible values are: textemote
	/// </summary>
	public string Type { get; set; }

	/// <summary> 
	/// Optional. The metadata pertaining to the emote.
	/// </summary>
	public object Emote { get; set; }

	/// <summary> 
	/// The ID that uniquely identifies this emote.
	/// </summary>
	public string Id { get; set; }

	/// <summary> 
	/// The UTC date and time (in RFC3339 format) of when the reward was redeemed.
	/// </summary>
	public string RedeemedAt { get; set; }

	public static TwitchChannelPointsAutomaticRewardRedemptionAddV2Event FromData(Dictionary data)
	{
	    return new TwitchChannelPointsAutomaticRewardRedemptionAddV2Event
	    {
			BroadcasterUserId = data["broadcaster_user_id"].AsString(),
			BroadcasterUserLogin = data["broadcaster_user_login"].AsString(),
			BroadcasterUserName = data["broadcaster_user_name"].AsString(),
			UserId = data["user_id"].AsString(),
			UserLogin = data["user_login"].AsString(),
			UserName = data["user_name"].AsString(),
			Id = data["id"].AsString(),
			Reward = data["reward"].As<object>(),
			Type = data["type"].AsString(),
			ChannelPoints = data["channel_points"].AsInt32(),
			Emote = data["emote"].As<object>(),
			Id = data["id"].AsString(),
			Name = data["name"].AsString(),
			Message = data["message"].As<object>(),
			Text = data["text"].AsString(),
			Fragments = data["fragments"].As<array>(),
			Text = data["text"].AsString(),
			Type = data["type"].AsString(),
			Emote = data["emote"].As<object>(),
			Id = data["id"].AsString(),
			RedeemedAt = data["redeemed_at"].AsString(),
		};
	}

}
