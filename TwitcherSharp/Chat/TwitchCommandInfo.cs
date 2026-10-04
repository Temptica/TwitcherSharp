using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.Chat;

public partial class TwitchCommandInfo : Resource, ITwitcherSharp<TwitchCommandInfo>
{
	private GodotObject? _data;

	public TwitchCommand? Command
	{
		get => field ??= TwitchCommand.FromObject(_data?.Get("command").AsGodotObject());
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
	public Variant OriginalMessage => _data?.Get("original_message")
		?? (MessageType == TwitchChatMessageType.WhisperMessage
			? Variant.CreateFrom(WhisperMessage ?? [])
			: Variant.CreateFrom(ChatMessage?.ToGodotObject()));

	public TwitchChatMessageType MessageType { get; set; }


	/// <summary>
	/// Only available if MessageType is ChatMessage
	/// </summary>
	public TwitchChatMessage? ChatMessage
	{
		get
		{
			if (field is not null || _data is null || MessageType != TwitchChatMessageType.ChatMessage) return field;
			using var original = _data.Get("original_message");
			return field = TwitchChatMessage.FromObject(original.AsGodotObject());
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
			ChannelName = data.Get("channel_name").AsString(),
			Username = data.Get("username").AsString(),
			UserId = data.Get("user_id").AsString(),
			Arguments = data.Get("arguments").AsStringArray().ToList(),
			TextMessage = data.Get("text_message").AsString(),
			_data = data,
		};

		using var original = data.Get("original_message");
		if (original.VariantType == Variant.Type.Dictionary)
		{
			//whisper
			info.MessageType = TwitchChatMessageType.WhisperMessage;
			info.WhisperMessage = original.AsGodotDictionary();
		}

		return info;
	}


	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/chat/twitch_command_info.gd");
		using var original = OriginalMessage;
		var instance = script.New(Command?.ToGodotObject() ?? new Variant(), ChannelName ?? "", Username ?? "",
			UserId ?? "", original, TextMessage ?? "").AsGodotObject();
		if (Arguments != null) instance.Set("arguments", Arguments.ToArray());
		return instance;
	}
}