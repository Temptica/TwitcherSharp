using Godot;
using TwitcherSharp.Api.Generated.Users;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.Chat;

public partial class TwitchCommandHelp: TwitchCommand, ITwitcherSharp<TwitchCommandHelp>
{
	/// <summary>
	/// Sender User that will send the answers on the command. Can be empty then the current user will be used
	/// </summary>
	public TwitchUser? SenderUser
	{
		get => IsLinked ? Data.Get<TwitchUser>("sender_user") : field;
		set
		{
			if (IsLinked) Data.SetObject("sender_user", value);
			field = value;
		}
	}

	/// <summary>
	/// Kept here only: twitcher 2.5.1's help command has no current user.
	/// </summary>
	public TwitchUser? CurrentUser { get; set; }

	public void CleanupRedundantCommands() => Data.Invoke("cleanup_redundant_commands");

	public new static TwitchCommandHelp? FromObject(GodotObject? data)
	{
		if (data == null) return null;
		// The properties are read from the node.
		var command = new TwitchCommandHelp { Data = data };
        
		command.SetBaseProperties();
		return command;
	}

	public override GodotObject ToGodotObject()
	{
		var data = InteropExtension.NewObject("res://addons/twitcher/chat/twitch_command_help.gd");
		data.SetValue("command_prefixes", CommandPrefixes.ToVariantArray());
		data.SetValue("aliases", Aliases.ToVariantArray());
		data.SetValue("args_min", ArgsMin);
		data.SetValue("args_max", ArgsMax);
		data.SetObject("sender_user", SenderUser);
		GetBaseProperties(data);
		return data;
	}
}