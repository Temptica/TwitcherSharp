using Godot;
using TwitcherSharp.Api.Generated.Users;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.Chat;

public partial class TwitchAutoMessage : RefCounted, ITwitcherSharp<TwitchAutoMessage>
{
    private GodotObject? _data;
    public bool UseBot { get; set; }
    public bool Announcement { get; set; }

    public TwitchAnnouncementColor AnnouncementColor
    {
        get => field ??= _data?.Get<TwitchAnnouncementColor>("announcement_color") ?? TwitchAnnouncementColor.Primary ;
        set;
    }

    public string Message { get; set; } = "";
    public bool SourceOnly { get; set; } = true;
    public int Weight { get; set; } = 1;

    public TwitchUser? Broadcaster { get => field ??= _data?.Get<TwitchUser>("broadcaster"); set; }
    public TwitchUser? Sender { get => field ??= _data?.Get<TwitchUser>("sender"); set; }

    public static TwitchAutoMessage? FromObject(GodotObject? data)
    {
        if (data == null) return null;
        return new TwitchAutoMessage
        {
            _data = data,
            UseBot = data.Read("use_bot", static v => v.AsBool()),
            Announcement = data.Read("announcement", static v => v.AsBool()),
            AnnouncementColor = data.Read("announcement_color", static v => v.AsTwitcherObject<TwitchAnnouncementColor>()),
            Message = data.Read("message", static v => v.AsString()),
            SourceOnly = data.Read("source_only", static v => v.AsBool()),
            Weight = data.Read("weight", static v => v.AsInt32()),
            Broadcaster = data.Read("user", static v => v.AsTwitcherObject<TwitchUser>()),
            Sender = data.Read("sender", static v => v.AsTwitcherObject<TwitchUser>()),
        };
    }

    public GodotObject ToGodotObject()
    {
        var instances = InteropExtension.NewObject("res://addons/twitcher/chat/twitch_auto_message.gd");
        instances.SetValue("use_bot", UseBot);
        instances.SetValue("announcement", Announcement);
        instances.SetObject("announcement_color", AnnouncementColor);
        instances.SetValue("message", Message);
        instances.SetValue("source_only", SourceOnly);
        instances.SetValue("weight", Weight);
        instances.SetObject("user", Broadcaster);
        instances.SetObject("sender", Sender);

        return instances;
    }

    public async Task Send()
    {
        await _data!.InvokeAsync("send");
    }
}