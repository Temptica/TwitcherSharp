using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.AutomodMessageHold;

public partial class TwitchAutomodMessageHoldEvent : Resource, ITwitcherSharpEventSub<TwitchAutomodMessageHoldEvent>
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
	/// The ID of the message that was flagged by automod.
	/// </summary>
	public string MessageId { get; set; }

	/// <summary> 
	/// The body of the message.
	/// </summary>
	public TwitchMessage Message { get; set; }

	/// <summary> 
	/// The category of the message.
	/// </summary>
	public string Category { get; set; }

	/// <summary> 
	/// The level of severity. Measured between 1 to 4.
	/// </summary>
	public int Level { get; set; }

	/// <summary> 
	/// The timestamp of when automod saved the message.
	/// </summary>
	public string HeldAt { get; set; }


    /// <summary> 
    /// Transforms the godot data into a TwitchAutomodMessageHoldEvent object.
    /// </summary> 
    public static TwitchAutomodMessageHoldEvent FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchAutomodMessageHoldEvent
		{
			BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
			BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
			BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
			UserId = data.Get("user_id").AsString(),
			UserLogin = data.Get("user_login").AsString(),
			UserName = data.Get("user_name").AsString(),
			MessageId = data.Get("message_id").AsString(),
			Message = data.Get("message").As<TwitchMessage>(),
			Category = data.Get("category").AsString(),
			Level = data.Get("level").AsInt32(),
			HeldAt = data.Get("held_at").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_automod_message_hold.gd");
		var eventClass = script.Get("Event").AsGodotObject();
		var request = eventClass.Call("new").AsGodotObject();
		request.Set("broadcaster_user_id", BroadcasterUserId);
		request.Set("broadcaster_user_login", BroadcasterUserLogin);
		request.Set("broadcaster_user_name", BroadcasterUserName);
		request.Set("user_id", UserId);
		request.Set("user_login", UserLogin);
		request.Set("user_name", UserName);
		request.Set("message_id", MessageId);
		request.Set("message", Message);
		request.Set("category", Category);
		request.Set("level", Level);
		request.Set("held_at", HeldAt);
		return request;
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
		public TwitchFragments[] Fragments { get; set; }
	
	
	    /// <summary> 
	    /// Transforms the godot data into a TwitchMessage object.
	    /// </summary> 
	    public static TwitchMessage FromObject(GodotObject data)
	    {
	        if(data == null) return null;
			var fragmentsArray = data.Get("fragments").AsGodotArray<GodotObject>();
			return new TwitchMessage
			{
				Text = data.Get("text").AsString(),
				Fragments = fragmentsArray.Select(TwitchFragments.FromObject).ToArray(),
			};
		}
	
		public GodotObject ToGodotObject()
		{
			var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_automod_message_hold.gd");
			var messageClass = script.Get("Message").AsGodotObject();
			var request = messageClass.Call("new").AsGodotObject();
			request.Set("text", Text);
			request.Set("fragments", Fragments);
			return request;
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
		
		
		    /// <summary> 
		    /// Transforms the godot data into a TwitchFragments object.
		    /// </summary> 
		    public static TwitchFragments FromObject(GodotObject data)
		    {
		        if(data == null) return null;
				return new TwitchFragments
				{
					Text = data.Get("text").AsString(),
					Emote = data.Get("emote").As<TwitchEmote>(),
					Cheermote = data.Get("cheermote").As<TwitchCheermote>(),
				};
			}
		
			public GodotObject ToGodotObject()
			{
				var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_automod_message_hold.gd");
				var fragmentsClass = script.Get("Fragments").AsGodotObject();
				var request = fragmentsClass.Call("new").AsGodotObject();
				request.Set("text", Text);
				request.Set("emote", Emote);
				request.Set("cheermote", Cheermote);
				return request;
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
			
			
			    /// <summary> 
			    /// Transforms the godot data into a TwitchEmote object.
			    /// </summary> 
			    public static TwitchEmote FromObject(GodotObject data)
			    {
			        if(data == null) return null;
					return new TwitchEmote
					{
						Id = data.Get("id").AsString(),
						EmoteSetId = data.Get("emote_set_id").AsString(),
					};
				}
			
				public GodotObject ToGodotObject()
				{
					var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_automod_message_hold.gd");
					var emoteClass = script.Get("Emote").AsGodotObject();
					var request = emoteClass.Call("new").AsGodotObject();
					request.Set("id", Id);
					request.Set("emote_set_id", EmoteSetId);
					return request;
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
			
			
			    /// <summary> 
			    /// Transforms the godot data into a TwitchCheermote object.
			    /// </summary> 
			    public static TwitchCheermote FromObject(GodotObject data)
			    {
			        if(data == null) return null;
					return new TwitchCheermote
					{
						Prefix = data.Get("prefix").AsString(),
						Bits = data.Get("bits").AsInt32(),
						Tier = data.Get("tier").AsInt32(),
					};
				}
			
				public GodotObject ToGodotObject()
				{
					var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_automod_message_hold.gd");
					var cheermoteClass = script.Get("Cheermote").AsGodotObject();
					var request = cheermoteClass.Call("new").AsGodotObject();
					request.Set("prefix", Prefix);
					request.Set("bits", Bits);
					request.Set("tier", Tier);
					return request;
				}
			
			}
		
		}
	
	}

}
