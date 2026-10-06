using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelGuestStarSettingsUpdate;

public partial class TwitchChannelGuestStarSettingsUpdateEvent : RefCounted, ITwitcherSharpEventSub<TwitchChannelGuestStarSettingsUpdateEvent>
{
    private Variant _data;
    
    /// <summary> 
    /// User ID of the host channel.
    /// </summary>
    public string? BroadcasterUserId { get; set; }

    /// <summary> 
    /// The broadcaster display name
    /// </summary>
    public string? BroadcasterUserName { get; set; }

    /// <summary> 
    /// he broadcaster login.
    /// </summary>
    public string? BroadcasterUserLogin { get; set; }

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
    public string? GroupLayout { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelGuestStarSettingsUpdateEvent object.
    /// </summary> 
    public static TwitchChannelGuestStarSettingsUpdateEvent? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelGuestStarSettingsUpdateEvent
        {
            BroadcasterUserId = data.Read("broadcaster_user_id", static v => v.AsString()),
            BroadcasterUserName = data.Read("broadcaster_user_name", static v => v.AsString()),
            BroadcasterUserLogin = data.Read("broadcaster_user_login", static v => v.AsString()),
            IsModeratorSendLiveEnabled = data.Read("is_moderator_send_live_enabled", static v => v.AsBool()),
            SlotCount = data.Read("slot_count", static v => v.AsInt32()),
            IsBrowserSourceAudioEnabled = data.Read("is_browser_source_audio_enabled", static v => v.AsBool()),
            GroupLayout = data.Read("group_layout", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_guest_star_settings_update.gd", "Event");
        if(BroadcasterUserId != null) request.SetValue("broadcaster_user_id", BroadcasterUserId);
        if(BroadcasterUserName != null) request.SetValue("broadcaster_user_name", BroadcasterUserName);
        if(BroadcasterUserLogin != null) request.SetValue("broadcaster_user_login", BroadcasterUserLogin);
        request.SetValue("is_moderator_send_live_enabled", IsModeratorSendLiveEnabled);
        request.SetValue("slot_count", SlotCount);
        request.SetValue("is_browser_source_audio_enabled", IsBrowserSourceAudioEnabled);
        if(GroupLayout != null) request.SetValue("group_layout", GroupLayout);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
}
