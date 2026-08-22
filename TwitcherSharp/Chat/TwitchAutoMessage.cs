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
            UseBot = data.Get("use_bot").AsBool(),
            Announcement = data.Get("announcement").AsBool(),
            AnnouncementColor = data.Get("announcement_color").AsTwitcherObject<TwitchAnnouncementColor>(),
            Message = data.Get("message").AsString(),
            SourceOnly = data.Get("source_only").AsBool(),
            Weight = data.Get("weight").AsInt32(),
            Broadcaster = data.Get("user").AsTwitcherObject<TwitchUser>(),
            Sender = data.Get("sender").AsTwitcherObject<TwitchUser>(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/chat/twitch_auto_message.gd");
        var instances = script.New().AsGodotObject();
        instances.Set("use_bot", UseBot);
        instances.Set("announcement", Announcement);
        instances.Set("announcement_color", AnnouncementColor.ToGodotObject());
        instances.Set("message", Message);
        instances.Set("source_only", SourceOnly);
        instances.Set("weight", Weight);
        instances.Set("user", Broadcaster?.ToGodotObject() ?? new Variant());
        instances.Set("sender", Sender?.ToGodotObject() ?? new Variant());

        return instances;
    }

    public async Task Send()
    {
        await _data!.CallAsync("send");
    }
}