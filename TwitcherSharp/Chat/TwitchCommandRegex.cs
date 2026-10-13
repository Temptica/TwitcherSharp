using Godot;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.Chat;

/// <summary>
/// A command that applies a regex to every message (be careful with the performance of regex as it can be slow)
/// </summary>
public partial class TwitchCommandRegex : TwitchCommandBase, ITwitcherSharp<TwitchCommandRegex>
{
    /// <summary>
    /// Regex it listens for and triggers on
    /// </summary>
    public string RegexToListen
    {
        get => LinkedRead(field, "regex_to_listen", static v => v.AsString());
        set => LinkedWrite(ref field, value, "regex_to_listen", value);
    } = null!;

    public static TwitchCommandRegex? FromObject(GodotObject? data)
    {
        if (data == null) return null;
        // The properties are read from the node.
        var regex = new TwitchCommandRegex { Data = data };
        regex.SetBaseProperties();
        
        return regex;
    }

    public override GodotObject ToGodotObject()
    {
        var data = InteropExtension.NewObject("res://addons/twitcher/chat/twitch_command_regex.gd");
        data.SetValue("regex_to_listen", RegexToListen);
        GetBaseProperties(data);
        return data;
    }
}