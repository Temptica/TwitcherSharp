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
	public TwitchUser SenderUser { get; set; }
	
	public TwitchUser CurrentUser { get; set; }

	public void CleanupRedundantCommands() => Data.Call("cleanup_redundant_commands");
	
	public new static TwitchCommandHelp FromObject(GodotObject data)
	{
		var command = new TwitchCommandHelp
		{
			Data = data,
			CommandPrefixes = data.Get("command_prefixes").AsStringArray().ToList(),
			Aliases = data.Get("aliases").AsStringArray().ToList(),
			ArgsMin = data.Get("args_min").AsInt32(),
			ArgsMax = data.Get("args_max").AsInt32(),
			SenderUser = TwitchUser.FromObject(data.Get("sender_user").AsGodotObject()),
			CurrentUser = TwitchUser.FromObject(data.Get("current_user").AsGodotObject()),
		};
        
		command.SetBaseProperties();
		return command;
	}

	public new GodotObject ToGodotObject()
	{
		var data = GD.Load<GDScript>("res://addons/twitcher/chat/twitch_command_help.gd").New().AsGodotObject();
		data.Set("command_prefixes", CommandPrefixes.ToVariantArray());
		data.Set("aliases", Aliases.ToVariantArray());
		data.Set("args_min", ArgsMin);
		data.Set("args_max", ArgsMax);
		data.Set("sender_user", SenderUser?.ToGodotObject() ?? new Variant());
		data.Set("current_user", CurrentUser?.ToGodotObject() ?? new Variant());
		GetBaseProperties(data);
		return data;
	}
}