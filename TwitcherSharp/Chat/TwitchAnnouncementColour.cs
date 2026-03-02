using Godot;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.Chat;

public partial class TwitchAnnouncementColour : RefCounted, ITwitcherSharp<TwitchAnnouncementColour>
{
    private GodotObject _data;
    public string Value { get; set; }

    private TwitchAnnouncementColour(string color)
    {
        Value = color;
    }

    public static readonly TwitchAnnouncementColour Blue = new("blue");
    public static readonly TwitchAnnouncementColour Green = new("green");
    public static readonly TwitchAnnouncementColour Orange = new("orange");
    public static readonly TwitchAnnouncementColour Purple = new("purple");
    public static readonly TwitchAnnouncementColour Primary = new("primary");

    public static TwitchAnnouncementColour FromObject(GodotObject data)
    {
        return new TwitchAnnouncementColour(data.Get("value").AsString());
    }


    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/chat/twitch_announcement_colour.gd");
        var data = script.New().AsGodotObject();
        data.Set("value", Value);
        return data;
    }
}