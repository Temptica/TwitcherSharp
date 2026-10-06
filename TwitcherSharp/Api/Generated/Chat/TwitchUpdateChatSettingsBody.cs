using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Chat;

public partial class TwitchUpdateChatSettingsBody : RefCounted, ITwitcherSharp<TwitchUpdateChatSettingsBody>
{
    private Variant _data;
    public bool? EmoteMode { get; set; }
    public bool? FollowerMode { get; set; }
    public int? FollowerModeDuration { get; set; }
    public bool? NonModeratorChatDelay { get; set; }
    public int? NonModeratorChatDelayDuration { get; set; }
    public bool? SlowMode { get; set; }
    public int? SlowModeWaitTime { get; set; }
    public bool? SubscriberMode { get; set; }
    public bool? UniqueChatMode { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateChatSettingsBody object.
    /// </summary> 
    public static TwitchUpdateChatSettingsBody? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchUpdateChatSettingsBody
        {
            EmoteMode = data.Read("emote_mode", static v => v.AsBool()),
            FollowerMode = data.Read("follower_mode", static v => v.AsBool()),
            FollowerModeDuration = data.Read("follower_mode_duration", static v => v.AsInt32()),
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
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_update_chat_settings.gd", "Body");
        if(EmoteMode.HasValue) request.SetValue("emote_mode", EmoteMode.Value);
        if(FollowerMode.HasValue) request.SetValue("follower_mode", FollowerMode.Value);
        if(FollowerModeDuration.HasValue) request.SetValue("follower_mode_duration", FollowerModeDuration.Value);
        if(NonModeratorChatDelay.HasValue) request.SetValue("non_moderator_chat_delay", NonModeratorChatDelay.Value);
        if(NonModeratorChatDelayDuration.HasValue) request.SetValue("non_moderator_chat_delay_duration", NonModeratorChatDelayDuration.Value);
        if(SlowMode.HasValue) request.SetValue("slow_mode", SlowMode.Value);
        if(SlowModeWaitTime.HasValue) request.SetValue("slow_mode_wait_time", SlowModeWaitTime.Value);
        if(SubscriberMode.HasValue) request.SetValue("subscriber_mode", SubscriberMode.Value);
        if(UniqueChatMode.HasValue) request.SetValue("unique_chat_mode", UniqueChatMode.Value);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
