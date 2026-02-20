using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelGuestStarSettingsUpdate;

public partial class TwitchChannelGuestStarSettingsUpdateEvent : Resource, ITwitcherSharpEventSub<TwitchChannelGuestStarSettingsUpdateEvent>
{
    /// <summary> 
    /// User ID of the host channel.
    /// </summary>
    public string BroadcasterUserId { get; set; }

    /// <summary> 
    /// The broadcaster display name
    /// </summary>
    public string BroadcasterUserName { get; set; }

    /// <summary> 
    /// he broadcaster login.
    /// </summary>
    public string BroadcasterUserLogin { get; set; }

    /// <summary> 
    /// Flag determining if Guest Star moderators have access to control whether a guest is live once assigned to a slot.
    /// </summary>
    public bool IsModeratorSendLiveEnabled { get; set; }

    /// <summary> 
    /// Number of slots the Guest Star call interface will allow the host to add to a call.
    /// </summary>
    public int SlotCount { get; set; }

    /// <summary> 
    /// Flag determining if browser sources subscribed to sessions on this channel should output audio.
    /// </summary>
    public bool IsBrowserSourceAudioEnabled { get; set; }

    /// <summary> 
    /// This setting determines how the guests within a session should be laid out within a group browser source. Can be one of the following values: tiled — All live guests are tiled within the browser source with the same size. screenshare — All live guests are tiled within the browser source with the same size. If there is an active screen share, it is sized larger than the other guests.horizontal_top — Indicates the group layout will contain all participants in a top-aligned horizontal stack.horizontal_bottom — Indicates the group layout will contain all participants in a bottom-aligned horizontal stack.vertical_left — Indicates the group layout will contain all participants in a left-aligned vertical stack.vertical_right — Indicates the group layout will contain all participants in a right-aligned vertical stack.
    /// </summary>
    public string GroupLayout { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelGuestStarSettingsUpdateEvent object.
    /// </summary> 
    public static TwitchChannelGuestStarSettingsUpdateEvent FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchChannelGuestStarSettingsUpdateEvent
        {
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
            BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
            BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
            IsModeratorSendLiveEnabled = data.Get("is_moderator_send_live_enabled").AsBool(),
            SlotCount = data.Get("slot_count").AsInt32(),
            IsBrowserSourceAudioEnabled = data.Get("is_browser_source_audio_enabled").AsBool(),
            GroupLayout = data.Get("group_layout").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_guest_star_settings_update.gd");
        var eventClass = script.Get("Event").AsGodotObject();
        var request = eventClass.Call("new").AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        request.Set("broadcaster_user_name", BroadcasterUserName);
        request.Set("broadcaster_user_login", BroadcasterUserLogin);
        request.Set("is_moderator_send_live_enabled", IsModeratorSendLiveEnabled);
        request.Set("slot_count", SlotCount);
        request.Set("is_browser_source_audio_enabled", IsBrowserSourceAudioEnabled);
        request.Set("group_layout", GroupLayout);
        return request;
    }
}
