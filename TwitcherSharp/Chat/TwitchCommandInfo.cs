using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.Chat;

public partial class TwitchCommandInfo : Resource, ITwitcherSharp<TwitchCommandInfo>
{
	private GodotObject _data;
	public TwitchCommand Command { get; set; }
	public string ChannelName { get; set; }
	public string Username { get; set; }
	public List<string> Arguments { get; set; }
	
	/// <summary>
	/// The original received message as string
	/// </summary>
	public string TextMessage { get; set; }
	
	public Variant OriginalMessage { get; set; }
	
	public TwitchChatMessageType MessageType { get; set; }
	
	
	/// <summary>
	/// Only available if MessageType is ChatMessage
	/// </summary>
	public TwitchChatMessage ChatMessage { get; set; }
	public Dictionary WhisperMessage { get; set; }
	
	public static TwitchCommandInfo FromObject(GodotObject data)
	{
		var info = new TwitchCommandInfo
		{
			ChannelName = data.Get("channel_name").AsString(),
			Username = data.Get("username").AsString(),
			Arguments = data.Get("arguments").AsGodotArray<string>().ToList(),
			OriginalMessage = data.Get("original_message"),
			TextMessage = data.Get("text_message").AsString(),
			Command = TwitchCommand.FromObject(data.Get("command").AsGodotObject()),
			_data = data,
		};

		if (info.OriginalMessage.VariantType == Variant.Type.Dictionary)
		{
			//whisper
			info.MessageType = TwitchChatMessageType.WhisperMessage;
			info.WhisperMessage = info.OriginalMessage.AsGodotDictionary();
		}
		else if(info.OriginalMessage.VariantType == Variant.Type.Object)
		{
			info.MessageType = TwitchChatMessageType.ChatMessage;
			info.ChatMessage = TwitchChatMessage.FromObject(info.OriginalMessage.AsGodotObject());
		}

		return info;
	}


	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_command_info.gd");
		var instance = script.New().AsGodotObject();
		instance.Set("channel_name", ChannelName);
		instance.Set("username", Username);
		instance.Set("arguments", Arguments.ToArray());
		instance.Set("original_message", OriginalMessage);
		instance.Set("text_message", TextMessage);
		instance.Set("command", Command.ToGodotObject());
		return instance;
	}
}