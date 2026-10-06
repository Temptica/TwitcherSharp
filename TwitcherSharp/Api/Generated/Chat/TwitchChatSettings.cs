using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Chat;

public partial class TwitchChatSettings : RefCounted, ITwitcherSharp<TwitchChatSettings>
{
    private Variant _data;
    public string BroadcasterId { get; set; } = null!;
    public bool EmoteMode { get; set; }
    public bool FollowerMode { get; set; }
    public int FollowerModeDuration { get; set; }
    public string? ModeratorId { get; set; }
    public bool? NonModeratorChatDelay { get; set; }
    public int? NonModeratorChatDelayDuration { get; set; }
    public bool SlowMode { get; set; }
    public int SlowModeWaitTime { get; set; }
    public bool SubscriberMode { get; set; }
    public bool UniqueChatMode { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChatSettings object.
    /// </summary> 
    public static TwitchChatSettings? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChatSettings
        {
            BroadcasterId = data.Read("broadcaster_id", static v => v.AsString()),
            EmoteMode = data.Read("emote_mode", static v => v.AsBool()),
            FollowerMode = data.Read("follower_mode", static v => v.AsBool()),
            FollowerModeDuration = data.Read("follower_mode_duration", static v => v.AsInt32()),
            ModeratorId = data.Read("moderator_id", static v => v.AsString()),
            NonModeratorChatDelay = data.Read("non_moderator_chat_delay", static v => v.AsBool()),
            NonModeratorChatDelayDuration = data.Read("non_moderator_chat_delay_duration", static v => v.AsInt32()),
            SlowMode = data.Read("slow_mode", static v => v.AsBool()),
            SlowModeWaitTime = data.Read("slow_mode_wait_time", static v => v.AsInt32()),
            SubscriberMode = data.Read("subscriber_mode", static v => v.AsBool()),
            UniqueChatMode = data.Read("unique_chat_mode", static v => v.AsBool()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated/twitch_chat_settings.gd");
        if(BroadcasterId != null) request.SetValue("broadcaster_id", BroadcasterId);
        request.SetValue("emote_mode", EmoteMode);
        request.SetValue("follower_mode", FollowerMode);
        request.SetValue("follower_mode_duration", FollowerModeDuration);
        if(ModeratorId != null) request.SetValue("moderator_id", ModeratorId);
        if(NonModeratorChatDelay.HasValue) request.SetValue("non_moderator_chat_delay", NonModeratorChatDelay.Value);
        if(NonModeratorChatDelayDuration.HasValue) request.SetValue("non_moderator_chat_delay_duration", NonModeratorChatDelayDuration.Value);
        request.SetValue("slow_mode", SlowMode);
        request.SetValue("slow_mode_wait_time", SlowModeWaitTime);
        request.SetValue("subscriber_mode", SubscriberMode);
        request.SetValue("unique_chat_mode", UniqueChatMode);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
