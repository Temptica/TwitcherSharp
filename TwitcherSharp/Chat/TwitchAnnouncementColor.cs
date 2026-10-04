using Godot;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.Chat;

public partial class TwitchAnnouncementColor(string color) : RefCounted, ITwitcherSharp<TwitchAnnouncementColor>
{
    public string Value { get; set; } = color;

    public static readonly TwitchAnnouncementColor Blue = new("blue");
    public static readonly TwitchAnnouncementColor Green = new("green");
    public static readonly TwitchAnnouncementColor Orange = new("orange");
    public static readonly TwitchAnnouncementColor Purple = new("purple");
    public static readonly TwitchAnnouncementColor Primary = new("primary");

    public static TwitchAnnouncementColor? FromObject(GodotObject? data)
    {
        return data == null ? null : new TwitchAnnouncementColor(data.Read("value", static v => v.AsString()));
    }

    public GodotObject ToGodotObject()
    {
        return InteropExtension.NewObject("res://addons/twitcher/chat/twitch_announcement_color.gd", Value);
    }

    public static implicit operator TwitchAnnouncementColor(string color)
    {
        return new TwitchAnnouncementColor(color);
    }
}