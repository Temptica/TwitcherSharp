using Godot;
using System;
using TwitcherSharp.Chat;
using TwitcherSharp.Extensions;

public partial class GenericCommands : Node
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.GetTwitcherNode<TwitchCommand>("TwitcherCommand").CommandReceived += async (username, info, args) =>
		{
			await TwitchBot.SendMessage("https://github.com/kanimaru/twitcher", info.ChatMessage.MessageId);
		};
		this.GetTwitcherNode<TwitchCommand>("TwitcherSharpCommand").CommandReceived += async (username, info, args) =>
		{
			await TwitchBot.SendMessage("https://github.com/Temptica/TwitcherSharp", info.ChatMessage.MessageId);
		};
		this.GetTwitcherNode<TwitchCommand>("DiscordCommand").CommandReceived += async (username, info, args) =>
		{
			await TwitchBot.SendMessage("https://discord.gg/jgxgVB4v2S", info.ChatMessage.MessageId);
		};
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
