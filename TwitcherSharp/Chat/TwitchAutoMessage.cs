using Godot;
using TwitcherSharp.Api.Generated.Users;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.Chat;

/// <summary>
/// A message sent automatically. When linked to a twitcher node (from <see cref="FromObject"/>), the properties are
/// read from the node and written to it.
/// </summary>
public partial class TwitchAutoMessage : RefCounted, ITwitcherSharp<TwitchAutoMessage>
{
    private GodotObject? _data;

    /// <summary>
    /// The colors in the order of twitcher's <c>TwitchAnnouncementColor.Enum</c>, which the node stores.
    /// </summary>
    private static readonly string[] AnnouncementColors = ["blue", "green", "orange", "purple", "primary"];

    public bool UseBot
    {
        get => _data?.Read("use_bot", static v => v.AsBool()) ?? field;
        set
        {
            _data?.SetValue("use_bot", value);
            field = value;
        }
    }

    public bool Announcement
    {
        get => _data?.Read("announcement", static v => v.AsBool()) ?? field;
        set
        {
            _data?.SetValue("announcement", value);
            field = value;
        }
    }

    public TwitchAnnouncementColor AnnouncementColor
    {
        get => _data?.Read("announcement_color", static v => ToColor(v.AsInt32())) ?? field;
        set
        {
            _data?.SetValue("announcement_color", ToEnum(value));
            field = value;
        }
    } = TwitchAnnouncementColor.Primary;

    public string Message
    {
        get => _data?.Read("message", static v => v.AsString()) ?? field;
        set
        {
            _data?.SetValue("message", value);
            field = value;
        }
    } = "";

    public bool SourceOnly
    {
        get => _data?.Read("source_only", static v => v.AsBool()) ?? field;
        set
        {
            _data?.SetValue("source_only", value);
            field = value;
        }
    } = true;

    public int Weight
    {
        get => _data?.Read("weight", static v => v.AsInt32()) ?? field;
        set
        {
            _data?.SetValue("weight", value);
            field = value;
        }
    } = 1;

    public TwitchUser? Broadcaster
    {
        get => _data is null ? field : _data.Get<TwitchUser>("broadcaster");
        set
        {
            _data?.SetObject("broadcaster", value);
            field = value;
        }
    }

    public TwitchUser? Sender
    {
        get => _data is null ? field : _data.Get<TwitchUser>("sender");
        set
        {
            _data?.SetObject("sender", value);
            field = value;
        }
    }

    private static TwitchAnnouncementColor ToColor(int index) =>
        index >= 0 && index < AnnouncementColors.Length ? AnnouncementColors[index] : TwitchAnnouncementColor.Primary;

    private static int ToEnum(TwitchAnnouncementColor? color)
    {
        var index = System.Array.IndexOf(AnnouncementColors, color?.Value);
        return index < 0 ? System.Array.IndexOf(AnnouncementColors, "primary") : index;
    }

    public static TwitchAutoMessage? FromObject(GodotObject? data)
    {
        // The properties are read from the node.
        return data == null ? null : new TwitchAutoMessage { _data = data };
    }

    public GodotObject ToGodotObject()
    {
        var instances = InteropExtension.NewObject("res://addons/twitcher/chat/twitch_auto_message.gd");
        instances.SetValue("use_bot", UseBot);
        instances.SetValue("announcement", Announcement);
        instances.SetValue("announcement_color", ToEnum(AnnouncementColor));
        instances.SetValue("message", Message);
        instances.SetValue("source_only", SourceOnly);
        instances.SetValue("weight", Weight);
        instances.SetObject("broadcaster", Broadcaster);
        instances.SetObject("sender", Sender);

        return instances;
    }

    public async Task Send()
    {
        await _data!.InvokeAsync("send");
    }
}
