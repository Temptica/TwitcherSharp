using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchChannelPointsAutomaticRewardRedemptionAddEvent : Resource, ITwitcherSharpEventSub<TwitchChannelPointsAutomaticRewardRedemptionAddEvent>
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
	public TwitchReward Reward { get; set; }

	/// <summary> 
	/// An object that contains the user message and emote information needed to recreate the message.
	/// </summary>
	public TwitchMessage Message { get; set; }

	/// <summary> 
	/// Optional. A string that the user entered if the reward requires input.
	/// </summary>
	public string UserInput { get; set; }

	/// <summary> 
	/// The UTC date and time (in RFC3339 format) of when the reward was redeemed.
	/// </summary>
	public string RedeemedAt { get; set; }

	public static TwitchChannelPointsAutomaticRewardRedemptionAddEvent FromData(Dictionary data)
	{
	    return new TwitchChannelPointsAutomaticRewardRedemptionAddEvent
	    {
			BroadcasterUserId = data["broadcaster_user_id"].AsString(),
			BroadcasterUserLogin = data["broadcaster_user_login"].AsString(),
			BroadcasterUserName = data["broadcaster_user_name"].AsString(),
			UserId = data["user_id"].AsString(),
			UserLogin = data["user_login"].AsString(),
			UserName = data["user_name"].AsString(),
			Id = data["id"].AsString(),
			Reward = TwitchReward.FromData(data["reward"].AsGodotDictionary()),
			Message = TwitchMessage.FromData(data["message"].AsGodotDictionary()),
			UserInput = data["user_input"].AsString(),
			RedeemedAt = data["redeemed_at"].AsString(),
		};
	}

public partial class TwitchReward : Resource, ITwitcherSharpEventSub<TwitchReward>
{

	/// <summary> 
	/// The type of reward. One of: single_message_bypass_sub_modesend_highlighted_messagerandom_sub_emote_unlockchosen_sub_emote_unlockchosen_modified_sub_emote_unlockmessage_effectgigantify_an_emotecelebration
	/// </summary>
	public string Type { get; set; }

	/// <summary> 
	/// The reward cost.
	/// </summary>
	public int Cost { get; set; }

	/// <summary> 
	/// Optional. Emote that was unlocked.
	/// </summary>
	public TwitchUnlockedEmote UnlockedEmote { get; set; }

	public static TwitchReward FromData(Dictionary data)
	{
	    return new TwitchReward
	    {
			Type = data["type"].AsString(),
			Cost = data["cost"].AsInt32(),
			UnlockedEmote = TwitchUnlockedEmote.FromData(data["unlocked_emote"].AsGodotDictionary()),
		};
	}

	public partial class TwitchUnlockedEmote : Resource, ITwitcherSharpEventSub<TwitchUnlockedEmote>
	{
	
		/// <summary> 
		/// The emote ID.
		/// </summary>
		public string Id { get; set; }
	
		/// <summary> 
		/// The human readable emote token.
		/// </summary>
		public string Name { get; set; }
	
		public static TwitchUnlockedEmote FromData(Dictionary data)
		{
		    return new TwitchUnlockedEmote
		    {
				Id = data["id"].AsString(),
				Name = data["name"].AsString(),
			};
		}
	
}

}
public partial class TwitchMessage : Resource, ITwitcherSharpEventSub<TwitchMessage>
{

	/// <summary> 
	/// The text of the chat message.
	/// </summary>
	public string Text { get; set; }

	/// <summary> 
	/// An array that includes the emote ID and start and end positions for where the emote appears in the text.
	/// </summary>
	public TwitchEmotes[] Emotes { get; set; }

	public static TwitchMessage FromData(Dictionary data)
	{
	    return new TwitchMessage
	    {
			Text = data["text"].AsString(),
			Emotes = data["emotes"].AsGodotArray().Select(x => TwitchEmotes.FromData(x.AsGodotDictionary())).ToArray(),
		};
	}

	public partial class TwitchEmotes : Resource, ITwitcherSharpEventSub<TwitchEmotes>
	{
	
		/// <summary> 
		/// The emote ID.
		/// </summary>
		public string Id { get; set; }
	
		/// <summary> 
		/// The index of where the Emote starts in the text.
		/// </summary>
		public int Begin { get; set; }
	
		/// <summary> 
		/// The index of where the Emote ends in the text.
		/// </summary>
		public int End { get; set; }
	
		public static TwitchEmotes FromData(Dictionary data)
		{
		    return new TwitchEmotes
		    {
				Id = data["id"].AsString(),
				Begin = data["begin"].AsInt32(),
				End = data["end"].AsInt32(),
			};
		}
	
}

}

}
