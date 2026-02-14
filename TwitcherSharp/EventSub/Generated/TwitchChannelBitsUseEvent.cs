using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchChannelBitsUseEvent : Resource, ITwitcherSharpEventSub<TwitchChannelBitsUseEvent>
{

	/// <summary> 
	/// The User ID of the channel where the Bits were redeemed.
	/// </summary>
	public string BroadcasterUserId { get; set; }

	/// <summary> 
	/// The login of the channel where the Bits were used.
	/// </summary>
	public string BroadcasterUserLogin { get; set; }

	/// <summary> 
	/// The display name of the channel where the Bits were used.
	/// </summary>
	public string BroadcasterUserName { get; set; }

	/// <summary> 
	/// The User ID of the redeeming user.
	/// </summary>
	public string UserId { get; set; }

	/// <summary> 
	/// The login name of the redeeming user.
	/// </summary>
	public string UserLogin { get; set; }

	/// <summary> 
	/// The display name of the redeeming user.
	/// </summary>
	public string UserName { get; set; }

	/// <summary> 
	/// The number of Bits used.
	/// </summary>
	public int Bits { get; set; }

	/// <summary> 
	/// Possible values are: cheerpower_up
	/// </summary>
	public string Type { get; set; }

	/// <summary> 
	/// Optional. An object that contains the user message and emote information needed to recreate the message.
	/// </summary>
	public TwitchMessage Message { get; set; }

	/// <summary> 
	/// Optional. Data about Power-up.
	/// </summary>
	public TwitchPowerUp PowerUp { get; set; }

	public static TwitchChannelBitsUseEvent FromData(Dictionary data)
	{
	    return new TwitchChannelBitsUseEvent
	    {
			BroadcasterUserId = data["broadcaster_user_id"].AsString(),
			BroadcasterUserLogin = data["broadcaster_user_login"].AsString(),
			BroadcasterUserName = data["broadcaster_user_name"].AsString(),
			UserId = data["user_id"].AsString(),
			UserLogin = data["user_login"].AsString(),
			UserName = data["user_name"].AsString(),
			Bits = data["bits"].AsInt32(),
			Type = data["type"].AsString(),
			Message = TwitchMessage.FromData(data["message"].AsGodotDictionary()),
			PowerUp = TwitchPowerUp.FromData(data["power_up"].AsGodotDictionary()),
		};
	}

public partial class TwitchMessage : Resource, ITwitcherSharpEventSub<TwitchMessage>
{

	/// <summary> 
	/// The chat message in plain text.
	/// </summary>
	public string Text { get; set; }

	/// <summary> 
	/// The ordered list of chat message fragments.
	/// </summary>
	public TwitchFragments[] Fragments { get; set; }

	public static TwitchMessage FromData(Dictionary data)
	{
	    return new TwitchMessage
	    {
			Text = data["text"].AsString(),
			Fragments = data["fragments"].AsGodotArray().Select(x => TwitchFragments.FromData(x.AsGodotDictionary())).ToArray(),
		};
	}

	public partial class TwitchFragments : Resource, ITwitcherSharpEventSub<TwitchFragments>
	{
	
		/// <summary> 
		/// The message text in fragment.
		/// </summary>
		public string Text { get; set; }
	
		/// <summary> 
		/// The type of message fragment. Possible values are: textcheermoteemote
		/// </summary>
		public string Type { get; set; }
	
		/// <summary> 
		/// Optional. The metadata pertaining to the emote.
		/// </summary>
		public TwitchEmote Emote { get; set; }
	
		/// <summary> 
		/// Optional. The metadata pertaining to the cheermote.
		/// </summary>
		public TwitchCheermote Cheermote { get; set; }
	
		public static TwitchFragments FromData(Dictionary data)
		{
		    return new TwitchFragments
		    {
				Text = data["text"].AsString(),
				Type = data["type"].AsString(),
				Emote = TwitchEmote.FromData(data["emote"].AsGodotDictionary()),
				Cheermote = TwitchCheermote.FromData(data["cheermote"].AsGodotDictionary()),
			};
		}
	
			public partial class TwitchEmote : Resource, ITwitcherSharpEventSub<TwitchEmote>
			{
			
				/// <summary> 
				/// The ID that uniquely identifies this emote.
				/// </summary>
				public string Id { get; set; }
			
				/// <summary> 
				/// The ID that identifies the emote set that the emote belongs to.
				/// </summary>
				public string EmoteSetId { get; set; }
			
				/// <summary> 
				/// The ID of the broadcaster who owns the emote.
				/// </summary>
				public string OwnerId { get; set; }
			
				public static TwitchEmote FromData(Dictionary data)
				{
				    return new TwitchEmote
				    {
						Id = data["id"].AsString(),
						EmoteSetId = data["emote_set_id"].AsString(),
						OwnerId = data["owner_id"].AsString(),
					};
				}
			
	}
			public partial class TwitchCheermote : Resource, ITwitcherSharpEventSub<TwitchCheermote>
			{
			
				/// <summary> 
				/// The name portion of the Cheermote string that you use in chat to cheer Bits. The full Cheermote string is the concatenation of {prefix} + {number of Bits}. For example, if the prefix is “Cheer” and you want to cheer 100 Bits, the full Cheermote string is Cheer100. When the Cheermote string is entered in chat, Twitch converts it to the image associated with the Bits tier that was cheered.
				/// </summary>
				public string Prefix { get; set; }
			
				/// <summary> 
				/// The amount of Bits cheered.
				/// </summary>
				public int Bits { get; set; }
			
				/// <summary> 
				/// The tier level of the cheermote.
				/// </summary>
				public int Tier { get; set; }
			
				public static TwitchCheermote FromData(Dictionary data)
				{
				    return new TwitchCheermote
				    {
						Prefix = data["prefix"].AsString(),
						Bits = data["bits"].AsInt32(),
						Tier = data["tier"].AsInt32(),
					};
				}
			
	}
	
}

}
public partial class TwitchPowerUp : Resource, ITwitcherSharpEventSub<TwitchPowerUp>
{

	/// <summary> 
	/// Possible values: message_effectcelebrationgigantify_an_emote
	/// </summary>
	public string Type { get; set; }

	/// <summary> 
	/// Optional. Emote associated with the reward.
	/// </summary>
	public TwitchEmote Emote { get; set; }

	/// <summary> 
	/// Optional. The ID of the message effect.
	/// </summary>
	public string MessageEffectId { get; set; }

	public static TwitchPowerUp FromData(Dictionary data)
	{
	    return new TwitchPowerUp
	    {
			Type = data["type"].AsString(),
			Emote = TwitchEmote.FromData(data["emote"].AsGodotDictionary()),
			MessageEffectId = data["message_effect_id"].AsString(),
		};
	}

	public partial class TwitchEmote : Resource, ITwitcherSharpEventSub<TwitchEmote>
	{
	
		/// <summary> 
		/// The ID that uniquely identifies this emote.
		/// </summary>
		public string Id { get; set; }
	
		/// <summary> 
		/// The human readable emote token.
		/// </summary>
		public string Name { get; set; }
	
		public static TwitchEmote FromData(Dictionary data)
		{
		    return new TwitchEmote
		    {
				Id = data["id"].AsString(),
				Name = data["name"].AsString(),
			};
		}
	
}

}

}
