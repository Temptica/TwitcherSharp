using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchChannelChatUserMessageHoldEvent : Resource, ITwitcherSharpEventSub<TwitchChannelChatUserMessageHoldEvent>
{

	/// <summary> 
	/// The ID of the broadcaster specified in the request.
	/// </summary>
	public string BroadcasterUserId { get; set; }

	/// <summary> 
	/// The login of the broadcaster specified in the request.
	/// </summary>
	public string BroadcasterUserLogin { get; set; }

	/// <summary> 
	/// The user name of the broadcaster specified in the request.
	/// </summary>
	public string BroadcasterUserName { get; set; }

	/// <summary> 
	/// The User ID of the message sender.
	/// </summary>
	public string UserId { get; set; }

	/// <summary> 
	/// The message sender’s login.
	/// </summary>
	public string UserLogin { get; set; }

	/// <summary> 
	/// The message sender’s display name.
	/// </summary>
	public string UserName { get; set; }

	/// <summary> 
	/// The ID of the message that was flagged by automod.
	/// </summary>
	public string MessageId { get; set; }

	/// <summary> 
	/// The body of the message.
	/// </summary>
	public TwitchMessage Message { get; set; }

	public static TwitchChannelChatUserMessageHoldEvent FromData(Dictionary data)
	{
	    return new TwitchChannelChatUserMessageHoldEvent
	    {
			BroadcasterUserId = data["broadcaster_user_id"].AsString(),
			BroadcasterUserLogin = data["broadcaster_user_login"].AsString(),
			BroadcasterUserName = data["broadcaster_user_name"].AsString(),
			UserId = data["user_id"].AsString(),
			UserLogin = data["user_login"].AsString(),
			UserName = data["user_name"].AsString(),
			MessageId = data["message_id"].AsString(),
			Message = TwitchMessage.FromData(data["message"].AsGodotDictionary()),
		};
	}

public partial class TwitchMessage : Resource, ITwitcherSharpEventSub<TwitchMessage>
{

	/// <summary> 
	/// The contents of the message caught by automod.
	/// </summary>
	public string Text { get; set; }

	/// <summary> 
	/// Ordered list of chat message fragments.
	/// </summary>
	public TwitchFragments Fragments { get; set; }

	public static TwitchMessage FromData(Dictionary data)
	{
	    return new TwitchMessage
	    {
			Text = data["text"].AsString(),
			Fragments = TwitchFragments.FromData(data["fragments"].AsGodotDictionary()),
		};
	}

	public partial class TwitchFragments : Resource, ITwitcherSharpEventSub<TwitchFragments>
	{
	
		/// <summary> 
		/// Message text in a fragment.
		/// </summary>
		public string Text { get; set; }
	
		/// <summary> 
		/// Optional. Metadata pertaining to the emote.
		/// </summary>
		public TwitchEmote Emote { get; set; }
	
		/// <summary> 
		/// Optional. Metadata pertaining to the cheermote.
		/// </summary>
		public TwitchCheermote Cheermote { get; set; }
	
		public static TwitchFragments FromData(Dictionary data)
		{
		    return new TwitchFragments
		    {
				Text = data["text"].AsString(),
				Emote = TwitchEmote.FromData(data["emote"].AsGodotDictionary()),
				Cheermote = TwitchCheermote.FromData(data["cheermote"].AsGodotDictionary()),
			};
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
			public partial class TwitchCheermote : Resource, ITwitcherSharpEventSub<TwitchCheermote>
			{
			
				/// <summary> 
				/// The name portion of the Cheermote string that you use in chat to cheer Bits. The full Cheermote string is the concatenation of {prefix} + {number of Bits}.  For example, if the prefix is “Cheer” and you want to cheer 100 Bits, the full Cheermote string is Cheer100. When the Cheermote string is entered in chat, Twitch converts it to the image associated with the Bits tier that was cheered.
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

}
