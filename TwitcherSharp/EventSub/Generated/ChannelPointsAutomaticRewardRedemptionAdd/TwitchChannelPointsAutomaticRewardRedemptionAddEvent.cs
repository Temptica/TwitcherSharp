using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelPointsAutomaticRewardRedemptionAdd;

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


    /// <summary> 
    /// Transforms the godot data into a TwitchChannelPointsAutomaticRewardRedemptionAddEvent object.
    /// </summary> 
    public static TwitchChannelPointsAutomaticRewardRedemptionAddEvent FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchChannelPointsAutomaticRewardRedemptionAddEvent
		{
			BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
			BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
			BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
			UserId = data.Get("user_id").AsString(),
			UserLogin = data.Get("user_login").AsString(),
			UserName = data.Get("user_name").AsString(),
			Id = data.Get("id").AsString(),
			Reward = data.Get("reward").As<TwitchReward>(),
			Message = data.Get("message").As<TwitchMessage>(),
			UserInput = data.Get("user_input").AsString(),
			RedeemedAt = data.Get("redeemed_at").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_points_automatic_reward_redemption_add.gd");
		var eventClass = script.Get("Event").AsGodotObject();
		var request = eventClass.Call("new").AsGodotObject();
		request.Set("broadcaster_user_id", BroadcasterUserId);
		request.Set("broadcaster_user_login", BroadcasterUserLogin);
		request.Set("broadcaster_user_name", BroadcasterUserName);
		request.Set("user_id", UserId);
		request.Set("user_login", UserLogin);
		request.Set("user_name", UserName);
		request.Set("id", Id);
		request.Set("reward", Reward);
		request.Set("message", Message);
		request.Set("user_input", UserInput);
		request.Set("redeemed_at", RedeemedAt);
		return request;
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
	
	
	    /// <summary> 
	    /// Transforms the godot data into a TwitchReward object.
	    /// </summary> 
	    public static TwitchReward FromObject(GodotObject data)
	    {
	        if(data == null) return null;
			return new TwitchReward
			{
				Type = data.Get("type").AsString(),
				Cost = data.Get("cost").AsInt32(),
				UnlockedEmote = data.Get("unlocked_emote").As<TwitchUnlockedEmote>(),
			};
		}
	
		public GodotObject ToGodotObject()
		{
			var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_points_automatic_reward_redemption_add.gd");
			var rewardClass = script.Get("Reward").AsGodotObject();
			var request = rewardClass.Call("new").AsGodotObject();
			request.Set("type", Type);
			request.Set("cost", Cost);
			request.Set("unlocked_emote", UnlockedEmote);
			return request;
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
		
		
		    /// <summary> 
		    /// Transforms the godot data into a TwitchUnlockedEmote object.
		    /// </summary> 
		    public static TwitchUnlockedEmote FromObject(GodotObject data)
		    {
		        if(data == null) return null;
				return new TwitchUnlockedEmote
				{
					Id = data.Get("id").AsString(),
					Name = data.Get("name").AsString(),
				};
			}
		
			public GodotObject ToGodotObject()
			{
				var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_points_automatic_reward_redemption_add.gd");
				var unlockedEmoteClass = script.Get("UnlockedEmote").AsGodotObject();
				var request = unlockedEmoteClass.Call("new").AsGodotObject();
				request.Set("id", Id);
				request.Set("name", Name);
				return request;
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
	
	
	    /// <summary> 
	    /// Transforms the godot data into a TwitchMessage object.
	    /// </summary> 
	    public static TwitchMessage FromObject(GodotObject data)
	    {
	        if(data == null) return null;
			var emotesArray = data.Get("emotes").AsGodotArray<GodotObject>();
			return new TwitchMessage
			{
				Text = data.Get("text").AsString(),
				Emotes = emotesArray.Select(TwitchEmotes.FromObject).ToArray(),
			};
		}
	
		public GodotObject ToGodotObject()
		{
			var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_points_automatic_reward_redemption_add.gd");
			var messageClass = script.Get("Message").AsGodotObject();
			var request = messageClass.Call("new").AsGodotObject();
			request.Set("text", Text);
			request.Set("emotes", Emotes);
			return request;
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
		
		
		    /// <summary> 
		    /// Transforms the godot data into a TwitchEmotes object.
		    /// </summary> 
		    public static TwitchEmotes FromObject(GodotObject data)
		    {
		        if(data == null) return null;
				return new TwitchEmotes
				{
					Id = data.Get("id").AsString(),
					Begin = data.Get("begin").AsInt32(),
					End = data.Get("end").AsInt32(),
				};
			}
		
			public GodotObject ToGodotObject()
			{
				var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_points_automatic_reward_redemption_add.gd");
				var emotesClass = script.Get("Emotes").AsGodotObject();
				var request = emotesClass.Call("new").AsGodotObject();
				request.Set("id", Id);
				request.Set("begin", Begin);
				request.Set("end", End);
				return request;
			}
		
		}
	
	}

}
