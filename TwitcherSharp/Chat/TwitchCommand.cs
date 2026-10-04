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
        Data.Invoke("add_alias", alias);
        Aliases = Data.Read("aliases", static v => v.AsStringArray()).ToList();
    }

    public void RemoveAlias(string alias)
    {
        // twitcher has add_alias but no remove_alias: edit the aliases array it holds.
        using var aliases = Data.Get("aliases");
        using var array = aliases.AsGodotArray();
        array.Remove(alias);
        Aliases = aliases.AsStringArray().ToList();
    }

    public override string ToString() => $"{CommandPrefixes[0]}{Command}";

    public static TwitchCommand? FromObject(GodotObject? data)
    {
        if (data == null) return null;
        var command = new TwitchCommand
        {
            Data = data,
            CommandPrefixes = data.Read("command_prefixes", static v => v.AsStringArray()).ToList(),
            Aliases = data.Read("aliases", static v => v.AsStringArray()).ToList(),
            ArgsMin = data.Read("args_min", static v => v.AsInt32()),
            ArgsMax = data.Read("args_max", static v => v.AsInt32()),
        };

        command.SetBaseProperties();
        return command;
    }


    public override GodotObject ToGodotObject()
    {
        var data = InteropExtension.NewObject("res://addons/twitcher/chat/twitch_command.gd");
        data.SetValue("command_prefixes", CommandPrefixes.ToVariantArray());
        data.SetValue("aliases", Aliases.ToVariantArray());
        data.SetValue("args_min", ArgsMin);
        data.SetValue("args_max", ArgsMax);
        GetBaseProperties(data);
        Data = data;
        ConnectSignals();
        return data;
    }
}