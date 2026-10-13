using Godot;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.Chat;

public partial class TwitchCommandContains : TwitchCommandBase, ITwitcherSharp<TwitchCommandContains>
{
    /// <summary>
    /// Words or phrases that triggers this command. Assign a new list to change it: changing the returned list does
    /// not reach the twitcher node.
    /// </summary>
    public List<string> Contains
    {
        get => LinkedRead(field, "contains", ReadStrings);
        set => LinkedWrite(ref field, value, "contains", value.ToVariantArray());
    } = [];

    /// <summary>
    /// When all words / phrases from contains should match
    /// </summary>
    public bool MatchAll
    {
        get => LinkedRead(field, "match_all", static v => v.AsBool());
        set => LinkedWrite(ref field, value, "match_all", value);
    }

    /// <summary>
    /// Matches on full words instead of somewhere in the string
    /// </summary>
    public bool MatchWord
    {
        get => LinkedRead(field, "match_word", static v => v.AsBool());
        set => LinkedWrite(ref field, value, "match_word", value);
    }

    public static TwitchCommandContains? FromObject(GodotObject? data)
    {
        if (data == null) return null;
        // The properties are read from the node.
        var command = new TwitchCommandContains { Data = data };

        command.SetBaseProperties();
        return command;
    }

    public override GodotObject ToGodotObject()
    {
        var data = InteropExtension.NewObject("res://addons/twitcher/chat/twitch_command_contains.gd");
        data.SetValue("contains", Contains.ToVariantArray());
        data.SetValue("match_all", MatchAll);
        data.SetValue("match_word", MatchWord);
        GetBaseProperties(data);
        return data;
    }
}