using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.Chat;

public partial class TwitchCommandInfo : Resource, ITwitcherSharp<TwitchCommandInfo>
{
	private Variant _data;

	public TwitchCommand? Command
	{
		get => field ??= _data.Get<TwitchCommand>("command");
		set;
	}

	public string? ChannelName { get; set; }
	public string? Username { get; set; }
	public string? UserId { get; set; }
	public List<string>? Arguments { get; set; }

	/// <summary>
	/// The original received message as string
	/// </summary>
	public string? TextMessage { get; set; }

	/// <summary>
	/// The message as twitcher passes it: a TwitchChatMessage object, or the whisper data as Dictionary.
	/// The caller disposes the returned Variant.
	/// </summary>
	public Variant OriginalMessage => !_data.IsNil
		? _data.With(data => data.Get("original_message"))
		: (MessageType == TwitchChatMessageType.WhisperMessage
			? Variant.CreateFrom(WhisperMessage ?? [])
			: GodotObjectExtension.ToVariant(ChatMessage));

	public TwitchChatMessageType MessageType { get; set; }


	/// <summary>
	/// Only available if MessageType is ChatMessage
	/// </summary>
	public TwitchChatMessage? ChatMessage
	{
		get
		{
			if (field is not null || _data.IsNil || MessageType != TwitchChatMessageType.ChatMessage) return field;
			return field = _data.Get<TwitchChatMessage>("original_message");
		}
		set;
	}

	/// <summary>
	/// Only available if MessageType is WhisperMessage
	/// </summary>
	public Dictionary? WhisperMessage { get; set; }

	public static TwitchCommandInfo? FromObject(GodotObject? data)
	{
		if (data == null) return null;

		var info = new TwitchCommandInfo
		{
			ChannelName = data.Read("channel_name", static v => v.AsString()),
			Username = data.Read("username", static v => v.AsString()),
			UserId = data.Read("user_id", static v => v.AsString()),
			Arguments = data.Read("arguments", static v => v.AsStringArray()).ToList(),
			TextMessage = data.Read("text_message", static v => v.AsString()),
			_data = Variant.CreateFrom(data),
		};

		var whisper = data.Read("original_message",
			static v => v.VariantType == Variant.Type.Dictionary ? v.AsGodotDictionary() : null);
		if (whisper is not null)
		{
			info.MessageType = TwitchChatMessageType.WhisperMessage;
			info.WhisperMessage = whisper;
		}

		return info;
	}


	public GodotObject ToGodotObject()
	{
		using var original = OriginalMessage;
		// The command is a node of the scene: passed as it is.
		var instance = InteropExtension.NewObject("res://addons/twitcher/chat/twitch_command_info.gd",
			Command?.ToGodotObject() ?? new Variant(), ChannelName ?? "", Username ?? "", UserId ?? "", original,
			TextMessage ?? "");
		if (Arguments != null) instance.SetValue("arguments", Arguments.ToArray());
		return instance;
	}

	/// <summary> Releases the twitcher object this instance was mapped from. </summary>
	protected override void Dispose(bool disposing)
	{
		// Only when disposed explicitly: when finalized, the Variant is finalized on its own.
		if (disposing) _data.Dispose();
		base.Dispose(disposing);
	}
}