using Godot;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.Chat;

public partial class TwitchAnnouncementColor(string color) : RefCounted, ITwitcherSharp<TwitchAnnouncementColor>
{
    private GodotObject _data;
    public string Value { get; set; } = color;

    public static readonly TwitchAnnouncementColor Blue = new("blue");
    public static readonly TwitchAnnouncementColor Green = new("green");
    public static readonly TwitchAnnouncementColor Orange = new("orange");
    public static readonly TwitchAnnouncementColor Purple = new("purple");
    public static readonly TwitchAnnouncementColor Primary = new("primary");

    public static TwitchAnnouncementColor FromObject(GodotObject data)
    {
        return new TwitchAnnouncementColor(data.Get("value").AsString());
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/chat/twitch_announcement_color.gd");
        return script.New(Value).AsGodotObject();
    }

    public static implicit operator TwitchAnnouncementColor(string color)
    {
        return new TwitchAnnouncementColor(color);
    }
}