using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Chat;

public partial class TwitchChatSettingsUpdated : RefCounted, ITwitcherSharp<TwitchChatSettingsUpdated>
{
    private Variant _data;
    public string BroadcasterId { get; set; } = null!;
    public bool EmoteMode { get; set; }
    public bool FollowerMode { get; set; }
    public int FollowerModeDuration { get; set; }
    public string? ModeratorId { get; set; }
    public bool NonModeratorChatDelay { get; set; }
    public int NonModeratorChatDelayDuration { get; set; }
    public bool SlowMode { get; set; }
    public int SlowModeWaitTime { get; set; }
    public bool SubscriberMode { get; set; }
    public bool UniqueChatMode { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChatSettingsUpdated object.
    /// </summary> 
    public static TwitchChatSettingsUpdated? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChatSettingsUpdated
        {
            BroadcasterId = data.ReadAsString("broadcaster_id"),
            EmoteMode = data.ReadAsBool("emote_mode"),
            FollowerMode = data.ReadAsBool("follower_mode"),
            FollowerModeDuration = data.ReadAsInt32("follower_mode_duration"),
            ModeratorId = data.ReadAsString("moderator_id"),
            NonModeratorChatDelay = data.ReadAsBool("non_moderator_chat_delay"),
            NonModeratorChatDelayDuration = data.ReadAsInt32("non_moderator_chat_delay_duration"),
            SlowMode = data.ReadAsBool("slow_mode"),
            SlowModeWaitTime = data.ReadAsInt32("slow_mode_wait_time"),
            SubscriberMode = data.ReadAsBool("subscriber_mode"),
            UniqueChatMode = data.ReadAsBool("unique_chat_mode"),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated/twitch_chat_settings_updated.gd");
        if(BroadcasterId != null) request.SetValue("broadcaster_id", BroadcasterId);
        request.SetValue("emote_mode", EmoteMode);
        request.SetValue("follower_mode", FollowerMode);
        request.SetValue("follower_mode_duration", FollowerModeDuration);
        if(ModeratorId != null) request.SetValue("moderator_id", ModeratorId);
        request.SetValue("non_moderator_chat_delay", NonModeratorChatDelay);
        request.SetValue("non_moderator_chat_delay_duration", NonModeratorChatDelayDuration);
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
