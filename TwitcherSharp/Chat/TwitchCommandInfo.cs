using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.Chat;

public partial class TwitchCommandInfo : Resource, ITwitcherSharp<TwitchCommandInfo>
{
	private GodotObject _data;

	public TwitchCommand Command
	{
		get => field ??= TwitchCommand.FromObject(_data?.Get("command").AsGodotObject());
		set;
	}

	public string ChannelName { get; set; }
	public string Username { get; set; }
	public List<string> Arguments { get; set; }
	
	/// <summary>
	/// The original received message as string
	/// </summary>
	public string TextMessage { get; set; }
	
	public Variant OriginalMessage => _data.Get("original_message");

	public TwitchChatMessageType MessageType { get; set; }


	/// <summary>
	/// Only available if MessageType is ChatMessage
	/// </summary>
	public TwitchChatMessage ChatMessage
	{
		get => field ??= TwitchChatMessage.FromObject(OriginalMessage.AsGodotObject());
		set;
	}

	public Dictionary WhisperMessage { get => field ??= OriginalMessage.AsGodotDictionary(); set; }
	
	public static TwitchCommandInfo FromObject(GodotObject data)
	{
		var info = new TwitchCommandInfo
		{
			ChannelName = data.Get("channel_name").AsString(),
			Username = data.Get("username").AsString(),
			Arguments = data.Get("arguments").AsGodotArray<string>().ToList(),
			TextMessage = data.Get("text_message").AsString(),
			_data = data,
		};

		if (info.OriginalMessage.VariantType == Variant.Type.Dictionary)
		{
			//whisper
			info.MessageType = TwitchChatMessageType.WhisperMessage;
			info.WhisperMessage = info.OriginalMessage.AsGodotDictionary();
		}

		return info;
	}


	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/chat/twitch_command_info.gd");
		var instance = script.New(Command?.ToGodotObject(),ChannelName, Username, OriginalMessage, TextMessage).AsGodotObject();
		instance.Set("arguments", Arguments?.ToVariantArray());
		return instance;
	}
}