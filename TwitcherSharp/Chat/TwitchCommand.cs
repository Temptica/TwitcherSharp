using Godot;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;
using Array = System.Array;

namespace TwitcherSharp.Chat;

public partial class TwitchCommand : TwitchCommandBase, ITwitcherSharp<TwitchCommand>
{
    public List<string> CommandPrefixes { get; set; } = ["!"];

    /// <summary>
    /// Optional names of commands
    /// </summary>
    public List<string> Aliases { get; set; } = [];

    /// <summary>
    /// Minimal amount of argument 0 means no argument needed
    /// </summary>
    public int ArgsMin { get; set; }

    /// <summary>
    /// Max amount of arguments -1 means infinite
    /// </summary>
    public int ArgsMax { get; set; } = -1;

    public void AddAlias(string alias)
    {
        Data.Call("add_alias", alias);
        Aliases = Data.Get("aliases").AsStringArray().ToList();
    }

    public void RemoveAlias(string alias)
    {
        Data.Call("remove_alias", alias);
        Aliases = Data.Get("aliases").AsStringArray().ToList();
    }

    public override string ToString() => $"{CommandPrefixes[0]}{Command}";

    public static TwitchCommand? FromObject(GodotObject? data)
    {
        if (data == null) return null;
        var command = new TwitchCommand
        {
            Data = data,
            CommandPrefixes = data.Get("command_prefixes").AsStringArray().ToList(),
            Aliases = data.Get("aliases").AsStringArray().ToList(),
            ArgsMin = data.Get("args_min").AsInt32(),
            ArgsMax = data.Get("args_max").AsInt32(),
        };

        command.SetBaseProperties();
        return command;
    }


    public override GodotObject ToGodotObject()
    {
        var data = GD.Load<GDScript>("res://addons/twitcher/chat/twitch_command.gd").New().AsGodotObject();
        data.Set("command_prefixes", CommandPrefixes.ToVariantArray());
        data.Set("aliases", Aliases.ToVariantArray());
        data.Set("args_min", ArgsMin);
        data.Set("args_max", ArgsMax);
        GetBaseProperties(data);
        Data = data;
        ConnectSignals();
        return data;
    }
}