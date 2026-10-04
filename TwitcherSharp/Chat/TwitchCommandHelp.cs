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
	public TwitchUser? SenderUser { get; set; }

	public TwitchUser? CurrentUser { get; set; }

	public void CleanupRedundantCommands() => Data.Invoke("cleanup_redundant_commands");

	public new static TwitchCommandHelp? FromObject(GodotObject? data)
	{
		if (data == null) return null;
		var command = new TwitchCommandHelp
		{
			Data = data,
			CommandPrefixes = data.Read("command_prefixes", static v => v.AsStringArray()).ToList(),
			Aliases = data.Read("aliases", static v => v.AsStringArray()).ToList(),
			ArgsMin = data.Read("args_min", static v => v.AsInt32()),
			ArgsMax = data.Read("args_max", static v => v.AsInt32()),
			SenderUser = data.Get<TwitchUser>("sender_user"),
			CurrentUser = data.Get<TwitchUser>("current_user"),
		};
        
		command.SetBaseProperties();
		return command;
	}

	public new GodotObject ToGodotObject()
	{
		var data = InteropExtension.NewObject("res://addons/twitcher/chat/twitch_command_help.gd");
		data.SetValue("command_prefixes", CommandPrefixes.ToVariantArray());
		data.SetValue("aliases", Aliases.ToVariantArray());
		data.SetValue("args_min", ArgsMin);
		data.SetValue("args_max", ArgsMax);
		data.SetObject("sender_user", SenderUser);
		data.SetObject("current_user", CurrentUser);
		GetBaseProperties(data);
		return data;
	}
}