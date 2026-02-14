using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchChannelSuspiciousUserMessageEvent : Resource, ITwitcherSharpEventSub<TwitchChannelSuspiciousUserMessageEvent>
{

	/// <summary> 
	/// The ID of the channel where the treatment for a suspicious user was updated.
	/// </summary>
	public string BroadcasterUserId { get; set; }

	/// <summary> 
	/// The display name of the channel where the treatment for a suspicious user was updated.
	/// </summary>
	public string BroadcasterUserName { get; set; }

	/// <summary> 
	/// The login of the channel where the treatment for a suspicious user was updated.
	/// </summary>
	public string BroadcasterUserLogin { get; set; }

	/// <summary> 
	/// The user ID of the user that sent the message.
	/// </summary>
	public string UserId { get; set; }

	/// <summary> 
	/// The user name of the user that sent the message.
	/// </summary>
	public string UserName { get; set; }

	/// <summary> 
	/// The user login of the user that sent the message.
	/// </summary>
	public string UserLogin { get; set; }

	/// <summary> 
	/// The status set for the suspicious user. Can be the following: “none”, “active_monitoring”, or “restricted”
	/// </summary>
	public string LowTrustStatus { get; set; }

	/// <summary> 
	/// A list of channel IDs where the suspicious user is also banned.
	/// </summary>
	public string[] SharedBanChannelIds { get; set; }

	/// <summary> 
	/// User types (if any) that apply to the suspicious user, can be “manually_added”, “ban_evader”, or “banned_in_shared_channel”.
	/// </summary>
	public string[] Types { get; set; }

	/// <summary> 
	/// A ban evasion likelihood value (if any) that as been applied to the user automatically by Twitch, can be “unknown”, “possible”, or “likely”.
	/// </summary>
	public string BanEvasionEvaluation { get; set; }

	/// <summary> 
	/// The structured chat message.
	/// </summary>
	public TwitchMessage Message { get; set; }

	public static TwitchChannelSuspiciousUserMessageEvent FromData(Dictionary data)
	{
	    return new TwitchChannelSuspiciousUserMessageEvent
	    {
			BroadcasterUserId = data["broadcaster_user_id"].AsString(),
			BroadcasterUserName = data["broadcaster_user_name"].AsString(),
			BroadcasterUserLogin = data["broadcaster_user_login"].AsString(),
			UserId = data["user_id"].AsString(),
			UserName = data["user_name"].AsString(),
			UserLogin = data["user_login"].AsString(),
			LowTrustStatus = data["low_trust_status"].AsString(),
			SharedBanChannelIds = data["shared_ban_channel_ids"].AsStringArray(),
			Types = data["types"].AsStringArray(),
			BanEvasionEvaluation = data["ban_evasion_evaluation"].AsString(),
			Message = TwitchMessage.FromData(data["message"].AsGodotDictionary()),
		};
	}

public partial class TwitchMessage : Resource, ITwitcherSharpEventSub<TwitchMessage>
{

	/// <summary> 
	/// The UUID that identifies the message.
	/// </summary>
	public string MessageId { get; set; }

	/// <summary> 
	/// The chat message in plain text.
	/// </summary>
	public string Text { get; set; }

	/// <summary> 
	/// Ordered list of chat message fragments.
	/// </summary>
	public TwitchFragments[] Fragments { get; set; }

	public static TwitchMessage FromData(Dictionary data)
	{
	    return new TwitchMessage
	    {
			MessageId = data["message_id"].AsString(),
			Text = data["text"].AsString(),
			Fragments = data["fragments"].AsGodotArray().Select(x => TwitchFragments.FromData(x.AsGodotDictionary())).ToArray(),
		};
	}

	public partial class TwitchFragments : Resource, ITwitcherSharpEventSub<TwitchFragments>
	{
	
		/// <summary> 
		/// The type of message fragment. Possible values: -text -cheermote -emote
		/// </summary>
		public string Type { get; set; }
	
		/// <summary> 
		/// Message text in fragment.
		/// </summary>
		public string Text { get; set; }
	
		/// <summary> 
		/// Optional. Metadata pertaining to the cheermote.
		/// </summary>
		public TwitchCheermote Cheermote { get; set; }
	
		/// <summary> 
		/// Optional. Metadata pertaining to the emote.
		/// </summary>
		public TwitchEmote Emote { get; set; }
	
		public static TwitchFragments FromData(Dictionary data)
		{
		    return new TwitchFragments
		    {
				Type = data["type"].AsString(),
				Text = data["text"].AsString(),
				Cheermote = TwitchCheermote.FromData(data["cheermote"].AsGodotDictionary()),
				Emote = TwitchEmote.FromData(data["emote"].AsGodotDictionary()),
			};
		}
	
			public partial class TwitchCheermote : Resource, ITwitcherSharpEventSub<TwitchCheermote>
			{
			
				/// <summary> 
				/// The name portion of the Cheermote string that you use in chat to cheer Bits. The full Cheermote string is the concatenation of {prefix} + {number of Bits}.   For example, if the prefix is “Cheer” and you want to cheer 100 Bits, the full Cheermote string is Cheer100. When the Cheermote string is entered in chat, Twitch converts it to the image associated with the Bits tier that was cheered.
				/// </summary>
				public string Prefix { get; set; }
			
				/// <summary> 
				/// The amount of Bits cheered.
				/// </summary>
				public string Bits { get; set; }
			
				/// <summary> 
				/// The tier level of the cheermote.
				/// </summary>
				public string Tier { get; set; }
			
				public static TwitchCheermote FromData(Dictionary data)
				{
				    return new TwitchCheermote
				    {
						Prefix = data["prefix"].AsString(),
						Bits = data["bits"].AsString(),
						Tier = data["tier"].AsString(),
					};
				}
			
	}
			public partial class TwitchEmote : Resource, ITwitcherSharpEventSub<TwitchEmote>
			{
			
				/// <summary> 
				/// An ID that uniquely identifies this emote.
				/// </summary>
				public string Id { get; set; }
			
				/// <summary> 
				/// An ID that identifies the emote set that the emote belongs to.
				/// </summary>
				public string EmoteSetId { get; set; }
			
				public static TwitchEmote FromData(Dictionary data)
				{
				    return new TwitchEmote
				    {
						Id = data["id"].AsString(),
						EmoteSetId = data["emote_set_id"].AsString(),
					};
				}
			
	}
	
}

}

}
