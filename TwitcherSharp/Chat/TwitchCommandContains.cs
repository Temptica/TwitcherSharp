using Godot;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.Chat;

public partial class TwitchCommandContains : TwitchCommandBase, ITwitcherSharp<TwitchCommandContains>
{
    /// <summary>
    /// Words or phrases that triggers this command
    /// </summary>
    public List<string> Contains { get; set; }

    /// <summary>
    /// When all words / phrases from contains should match
    /// </summary>
    public bool MatchAll { get; set; }

    /// <summary>
    /// Matches on full words instead of somewhere in the string
    /// </summary>
    public bool MatchWord { get; set; }

    public static TwitchCommandContains FromObject(GodotObject data)
    {
        var command = new TwitchCommandContains
        {
            Data = data,
            MatchAll = data.Get("match_all").AsBool(),
            Contains = data.Get("contains").AsGodotArray<string>().ToList(),
            MatchWord = data.Get("match_word").AsBool(),
        };

        command.SetBaseProperties();
        return command;
    }

    public override GodotObject ToGodotObject()
    {
        var data = GD.Load<GDScript>("res://addons/twitcher/chat/twitch_command_contains.gd").New().AsGodotObject();
        data.Set("contains", Contains?.ToArray());
        data.Set("match_all", MatchAll);
        data.Set("match_word", MatchWord);
        GetBaseProperties(data);
        return data;
    }
}