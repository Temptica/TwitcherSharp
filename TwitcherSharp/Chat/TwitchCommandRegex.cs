using Godot;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.Chat;

/// <summary>
/// A command that applies a regex to every message (be careful with the performance of regex as it can be slow)
/// </summary>
public partial class TwitchCommandRegex : TwitchCommandBase, ITwitcherSharp<TwitchCommandRegex>
{
    const string MetaRegexResult = "twitch_command_regex_regex_result";
    public string RegexToListen { get; set; }


    public static TwitchCommandRegex FromObject(GodotObject data)
    {
        var regex = new TwitchCommandRegex();
        regex.RegexToListen = data.Get("regex_to_listen").AsString();
        regex.SetBaseProperties();
        
        return regex;
    }

    public override GodotObject ToGodotObject()
    {
        var data = GD.Load<GDScript>("res://addons/twitcher/chat/twitch_command_regex.gd").New().AsGodotObject();
        data.Set("regex_to_listen", RegexToListen);
        GetBaseProperties(data);
        return data;
    }
}