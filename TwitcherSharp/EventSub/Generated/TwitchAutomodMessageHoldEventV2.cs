using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchAutomodMessageHoldEventV2 : Resource, ITwitcherSharpEventSub<TwitchAutomodMessageHoldEventV2>
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
	/// The message sender’s user ID.
	/// </summary>
	public string UserId { get; set; }

	/// <summary> 
	/// The message sender’s login name.
	/// </summary>
	public string UserLogin { get; set; }

	/// <summary> 
	/// The message sender’s display name.
	/// </summary>
	public string UserName { get; set; }

	/// <summary> 
	/// The ID of the held message.
	/// </summary>
	public string MessageId { get; set; }

	/// <summary> 
	/// The body of the message.
	/// </summary>
	public TwitchMessage Message { get; set; }

	/// <summary> 
	/// The timestamp of when automod saved the message.
	/// </summary>
	public string HeldAt { get; set; }

	/// <summary> 
	/// Possible values are: automodblocked_term
	/// </summary>
	public string Reason { get; set; }

	/// <summary> 
	/// Optional. If the message was caught by automod, this will be populated.
	/// </summary>
	public TwitchAutomod Automod { get; set; }

	/// <summary> 
	/// Optional. If the message was caught due to a blocked term, this will be populated.
	/// </summary>
	public TwitchBlockedTerm BlockedTerm { get; set; }

	public static TwitchAutomodMessageHoldEventV2 FromData(Dictionary data)
	{
	    return new TwitchAutomodMessageHoldEventV2
	    {
			BroadcasterUserId = data["broadcaster_user_id"].AsString(),
			BroadcasterUserLogin = data["broadcaster_user_login"].AsString(),
			BroadcasterUserName = data["broadcaster_user_name"].AsString(),
			UserId = data["user_id"].AsString(),
			UserLogin = data["user_login"].AsString(),
			UserName = data["user_name"].AsString(),
			MessageId = data["message_id"].AsString(),
			Message = TwitchMessage.FromData(data["message"].AsGodotDictionary()),
			HeldAt = data["held_at"].AsString(),
			Reason = data["reason"].AsString(),
			Automod = TwitchAutomod.FromData(data["automod"].AsGodotDictionary()),
			BlockedTerm = TwitchBlockedTerm.FromData(data["blocked_term"].AsGodotDictionary()),
		};
	}

public partial class TwitchMessage : Resource, ITwitcherSharpEventSub<TwitchMessage>
{

	/// <summary> 
	/// The contents of the message caught by automod.
	/// </summary>
	public string Text { get; set; }

	/// <summary> 
	/// Metadata surrounding the potential inappropriate fragments of the message.
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
		/// One of three options:textemotecheermote
		/// </summary>
		public string Type { get; set; }
	
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
				Type = data["type"].AsString(),
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
public partial class TwitchAutomod : Resource, ITwitcherSharpEventSub<TwitchAutomod>
{

	/// <summary> 
	/// The category of the caught message.
	/// </summary>
	public string Category { get; set; }

	/// <summary> 
	/// The level of severity (1-4).
	/// </summary>
	public int Level { get; set; }

	/// <summary> 
	/// The bounds of the text that caused the message to be caught.
	/// </summary>
	public TwitchBoundaries Boundaries { get; set; }

	public static TwitchAutomod FromData(Dictionary data)
	{
	    return new TwitchAutomod
	    {
			Category = data["category"].AsString(),
			Level = data["level"].AsInt32(),
			Boundaries = TwitchBoundaries.FromData(data["boundaries"].AsGodotDictionary()),
		};
	}

	public partial class TwitchBoundaries : Resource, ITwitcherSharpEventSub<TwitchBoundaries>
	{
	
		/// <summary> 
		/// Index in the message for the start of the problem (0 indexed, inclusive).
		/// </summary>
		public int StartPos { get; set; }
	
		/// <summary> 
		/// Index in the message for the end of the problem (0 indexed, inclusive).
		/// </summary>
		public int EndPos { get; set; }
	
		public static TwitchBoundaries FromData(Dictionary data)
		{
		    return new TwitchBoundaries
		    {
				StartPos = data["start_pos"].AsInt32(),
				EndPos = data["end_pos"].AsInt32(),
			};
		}
	
}

}
public partial class TwitchBlockedTerm : Resource, ITwitcherSharpEventSub<TwitchBlockedTerm>
{

	/// <summary> 
	/// The list of blocked terms found in the message.
	/// </summary>
	public TwitchTermsFound TermsFound { get; set; }

	public static TwitchBlockedTerm FromData(Dictionary data)
	{
	    return new TwitchBlockedTerm
	    {
			TermsFound = TwitchTermsFound.FromData(data["terms_found"].AsGodotDictionary()),
		};
	}

	public partial class TwitchTermsFound : Resource, ITwitcherSharpEventSub<TwitchTermsFound>
	{
	
		/// <summary> 
		/// The id of the blocked term found.
		/// </summary>
		public string TermId { get; set; }
	
		/// <summary> 
		/// The bounds of the text that caused the message to be caught.
		/// </summary>
		public TwitchBoundary Boundary { get; set; }
	
		/// <summary> 
		/// The id of the broadcaster that owns the blocked term.
		/// </summary>
		public string OwnerBroadcasterUserId { get; set; }
	
		/// <summary> 
		/// The login of the broadcaster that owns the blocked term.
		/// </summary>
		public string OwnerBroadcasterUserLogin { get; set; }
	
		/// <summary> 
		/// The username of the broadcaster that owns the blocked term.
		/// </summary>
		public string OwnerBroadcasterUserName { get; set; }
	
		public static TwitchTermsFound FromData(Dictionary data)
		{
		    return new TwitchTermsFound
		    {
				TermId = data["term_id"].AsString(),
				Boundary = TwitchBoundary.FromData(data["boundary"].AsGodotDictionary()),
				OwnerBroadcasterUserId = data["owner_broadcaster_user_id"].AsString(),
				OwnerBroadcasterUserLogin = data["owner_broadcaster_user_login"].AsString(),
				OwnerBroadcasterUserName = data["owner_broadcaster_user_name"].AsString(),
			};
		}
	
			public partial class TwitchBoundary : Resource, ITwitcherSharpEventSub<TwitchBoundary>
			{
			
				/// <summary> 
				/// Index in the message for the start of the problem (0 indexed, inclusive).
				/// </summary>
				public int StartPos { get; set; }
			
				/// <summary> 
				/// Index in the message for the end of the problem (0 indexed, inclusive).
				/// </summary>
				public int EndPos { get; set; }
			
				public static TwitchBoundary FromData(Dictionary data)
				{
				    return new TwitchBoundary
				    {
						StartPos = data["start_pos"].AsInt32(),
						EndPos = data["end_pos"].AsInt32(),
					};
				}
			
	}
	
}

}

}
