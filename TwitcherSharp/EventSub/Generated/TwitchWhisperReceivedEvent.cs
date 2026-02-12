using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchWhisperReceivedEvent : Resource, ITwitcherSharpEventSub<TwitchWhisperReceivedEvent>
{

	/// <summary> 
	/// The ID of the user sending the message.
	/// </summary>
	public string FromUserId { get; set; }

	/// <summary> 
	/// The name of the user sending the message.
	/// </summary>
	public string FromUserName { get; set; }

	/// <summary> 
	/// The login of the user sending the message.
	/// </summary>
	public string FromUserLogin { get; set; }

	/// <summary> 
	/// The ID of the user receiving the message.
	/// </summary>
	public string ToUserId { get; set; }

	/// <summary> 
	/// The name of the user receiving the message.
	/// </summary>
	public string ToUserName { get; set; }

	/// <summary> 
	/// The login of the user receiving the message.
	/// </summary>
	public string ToUserLogin { get; set; }

	/// <summary> 
	/// The whisper ID.
	/// </summary>
	public string WhisperId { get; set; }

	/// <summary> 
	/// Object containing whisper information.
	/// </summary>
	public TwitchWhisper Whisper { get; set; }

	public static TwitchWhisperReceivedEvent FromData(Dictionary data)
	{
	    return new TwitchWhisperReceivedEvent
	    {
			FromUserId = data["from_user_id"].AsString(),
			FromUserName = data["from_user_name"].AsString(),
			FromUserLogin = data["from_user_login"].AsString(),
			ToUserId = data["to_user_id"].AsString(),
			ToUserName = data["to_user_name"].AsString(),
			ToUserLogin = data["to_user_login"].AsString(),
			WhisperId = data["whisper_id"].AsString(),
			Whisper = TwitchWhisper.FromData(data["whisper"].AsGodotDictionary()),
		};
	}

public partial class TwitchWhisper : Resource, ITwitcherSharpEventSub<TwitchWhisper>
{

	/// <summary> 
	/// The body of the whisper message.
	/// </summary>
	public string Text { get; set; }

	public static TwitchWhisper FromData(Dictionary data)
	{
	    return new TwitchWhisper
	    {
			Text = data["text"].AsString(),
		};
	}

}

}
