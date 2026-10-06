using Godot;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;
using Array = System.Array;

namespace TwitcherSharp.Chat;

public partial class TwitchCommand : TwitchCommandBase, ITwitcherSharp<TwitchCommand>
{
    /// <summary>
    /// Prefixes the command is called with. Assign a new list to change it: changing the returned list does not
    /// reach the twitcher node.
    /// </summary>
    public List<string> CommandPrefixes
    {
        get => LinkedRead(field, "command_prefixes", ReadStrings);
        set => LinkedWrite(ref field, value, "command_prefixes", value.ToVariantArray());
    } = ["!"];

    /// <summary>
    /// Optional names of commands. Use <see cref="AddAlias"/> and <see cref="RemoveAlias"/>, or assign a new list:
    /// changing the returned list does not reach the twitcher node.
    /// </summary>
    public List<string> Aliases
    {
        get => LinkedRead(field, "aliases", ReadStrings);
        set => LinkedWrite(ref field, value, "aliases", value.ToVariantArray());
    } = [];

    /// <summary>
    /// Minimal amount of argument 0 means no argument needed
    /// </summary>
    public int ArgsMin
    {
        get => LinkedRead(field, "args_min", static v => v.AsInt32());
        set => LinkedWrite(ref field, value, "args_min", value);
    }

    /// <summary>
    /// Max amount of arguments -1 means infinite
    /// </summary>
    public int ArgsMax
    {
        get => LinkedRead(field, "args_max", static v => v.AsInt32());
        set => LinkedWrite(ref field, value, "args_max", value);
    } = -1;

    public void AddAlias(string alias) => Data.Invoke("add_alias", alias);

    public void RemoveAlias(string alias)
    {
        // twitcher has add_alias but no remove_alias: edit the aliases array it holds.
        using var aliases = Data.Get("aliases");
        using var array = aliases.AsGodotArray();
        array.Remove(alias);
    }

    public override string ToString() => $"{CommandPrefixes[0]}{Command}";

    public static TwitchCommand? FromObject(GodotObject? data)
    {
        if (data == null) return null;
        // The properties are read from the node.
        var command = new TwitchCommand { Data = data };

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
        ConnectSignals();
        return data;
    }
}