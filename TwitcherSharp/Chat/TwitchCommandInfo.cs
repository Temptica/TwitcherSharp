using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;
using TwitcherSharp.Reward;

namespace TwitcherSharp.Chat;

public partial class TwitchCommandInfo : Resource, ITwitcherSharp<TwitchCommandInfo>
{
	private GodotObject _data;
	public TwitchCommand Command { get; set; }
	public string ChannelName { get; set; }
	public string Username { get; set; }
	public Array<string> Arguments { get; set; }
	
	public ChatMessageType MessageType { get; set; } //Message has a type

	public enum ChatMessageType
	{
		ChatMessage,
		WhisperMessage
	}
	public Variant OriginalMessage { get; set; }
	/// <summary>
	/// Only available if MessageType is ChatMessage
	/// </summary>
	public TwitchChatMessage ChatMessage { get; set; }
	public string GetCommandMessage
	{
		get
		{
			var msg = ChatMessage?.Content.Text.Replace(Command.Command, "", StringComparison.InvariantCultureIgnoreCase);
			if(string.IsNullOrWhiteSpace(msg)) return "";

			var itemsToFilter = Command.CommandPrefixes.ToList();
			itemsToFilter.AddRange(Command.Aliases);
			foreach (var commandAlias in itemsToFilter)
			{
				msg = msg.Replace(commandAlias, "", StringComparison.InvariantCultureIgnoreCase);
			}
			
			return msg.Trim();
		}
	}

	public static TwitchCommandInfo FromObject(GodotObject data)
	{
		var info = new TwitchCommandInfo
		{
			ChannelName = data.Get("channel_name").AsString(),
			Username = data.Get("username").AsString(),
			Arguments = data.Get("arguments").AsGodotArray<string>(),
			OriginalMessage = data.Get("original_message"),
			_data = data,
			Command = TwitchCommand.FromObject(data.Get("command").AsGodotObject())
			
		};

		if (info.OriginalMessage.VariantType == Variant.Type.Dictionary)
		{
			//whisper
			info.MessageType = ChatMessageType.WhisperMessage;
		}
		else if(info.OriginalMessage.VariantType == Variant.Type.Object)
		{
			info.MessageType = ChatMessageType.ChatMessage;
			info.ChatMessage = TwitchChatMessage.FromObject(info.OriginalMessage.AsGodotObject());
		}

		return info;
	}

	public GodotObject ToGodotObject()
	{
		throw new NotImplementedException();
	}
}