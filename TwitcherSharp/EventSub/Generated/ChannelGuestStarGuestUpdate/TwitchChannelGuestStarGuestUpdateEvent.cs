using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelGuestStarGuestUpdate;

public partial class TwitchChannelGuestStarGuestUpdateEvent : RefCounted, ITwitcherSharpEventSub<TwitchChannelGuestStarGuestUpdateEvent>
{
    private Variant _data;
    
    /// <summary> 
    /// The non-host broadcaster user ID.
    /// </summary>
    public string? BroadcasterUserId { get; set; }

    /// <summary> 
    /// The non-host broadcaster display name.
    /// </summary>
    public string? BroadcasterUserName { get; set; }

    /// <summary> 
    /// The non-host broadcaster login.
    /// </summary>
    public string? BroadcasterUserLogin { get; set; }

    /// <summary> 
    /// ID representing the unique session that was started.
    /// </summary>
    public string? SessionId { get; set; }

    /// <summary> 
    /// The user ID of the moderator who updated the guest’s state (could be the host). null if the update was performed by the guest.
    /// </summary>
    public string? ModeratorUserId { get; set; }

    /// <summary> 
    /// The moderator display name.null if the update was performed by the guest.
    /// </summary>
    public string? ModeratorUserName { get; set; }

    /// <summary> 
    /// The moderator login. null if the update was performed by the guest.
    /// </summary>
    public string? ModeratorUserLogin { get; set; }

    /// <summary> 
    /// The user ID of the guest who transitioned states in the session. null if the slot is now empty.
    /// </summary>
    public string? GuestUserId { get; set; }

    /// <summary> 
    /// The guest display name. null if the slot is now empty.
    /// </summary>
    public string? GuestUserName { get; set; }

    /// <summary> 
    /// The guest login. null if the slot is now empty.
    /// </summary>
    public string? GuestUserLogin { get; set; }

    /// <summary> 
    /// The ID of the slot assignment the guest is assigned to. null if the guest is in the INVITED, REMOVED, READY, or ACCEPTED state.
    /// </summary>
    public string? SlotId { get; set; }

    /// <summary> 
    /// The current state of the user after the update has taken place. null if the slot is now empty. Can otherwise be one of the following: invited — The guest has transitioned to the invite queue. This can take place when the guest was previously assigned a slot, but have been removed from the call and are sent back to the invite queue.accepted — The guest has accepted the invite and is currently in the process of setting up to join the session.ready — The guest has signaled they are ready and can be assigned a slot.backstage — The guest has been assigned a slot in the session, but is not currently seen live in the broadcasting software.live — The guest is now live in the host's broadcasting software.removed — The guest was removed from the call or queue.
    /// </summary>
    public string? State { get; set; }

    /// <summary> 
    /// User ID of the host channel.
    /// </summary>
    public string? HostUserId { get; set; }

    /// <summary> 
    /// The host display name.
    /// </summary>
    public string? HostUserName { get; set; }

    /// <summary> 
    /// The host login.
    /// </summary>
    public string? HostUserLogin { get; set; }

    /// <summary> 
    /// Flag that signals whether the host is allowing the slot’s video to be seen by participants within the session. null  if the guest is not slotted.
    /// </summary>
    public bool HostVideoEnabled { get; set; }

    /// <summary> 
    /// Flag that signals whether the host is allowing the slot’s audio to be heard by participants within the session. null  if the guest is not slotted.
    /// </summary>
    public bool HostAudioEnabled { get; set; }

    /// <summary> 
    /// Value between 0-100 that represents the slot’s audio level as heard by participants within the session. null  if the guest is not slotted.
    /// </summary>
    public int HostVolume { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelGuestStarGuestUpdateEvent object.
    /// </summary> 
    public static TwitchChannelGuestStarGuestUpdateEvent? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelGuestStarGuestUpdateEvent
        {
            BroadcasterUserId = data.Read("broadcaster_user_id", static v => v.AsString()),
            BroadcasterUserName = data.Read("broadcaster_user_name", static v => v.AsString()),
            BroadcasterUserLogin = data.Read("broadcaster_user_login", static v => v.AsString()),
            SessionId = data.Read("session_id", static v => v.AsString()),
            ModeratorUserId = data.Read("moderator_user_id", static v => v.AsString()),
            ModeratorUserName = data.Read("moderator_user_name", static v => v.AsString()),
            ModeratorUserLogin = data.Read("moderator_user_login", static v => v.AsString()),
            GuestUserId = data.Read("guest_user_id", static v => v.AsString()),
            GuestUserName = data.Read("guest_user_name", static v => v.AsString()),
            GuestUserLogin = data.Read("guest_user_login", static v => v.AsString()),
            SlotId = data.Read("slot_id", static v => v.AsString()),
            State = data.Read("state", static v => v.AsString()),
            HostUserId = data.Read("host_user_id", static v => v.AsString()),
            HostUserName = data.Read("host_user_name", static v => v.AsString()),
            HostUserLogin = data.Read("host_user_login", static v => v.AsString()),
            HostVideoEnabled = data.Read("host_video_enabled", static v => v.AsBool()),
            HostAudioEnabled = data.Read("host_audio_enabled", static v => v.AsBool()),
            HostVolume = data.Read("host_volume", static v => v.AsInt32()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_guest_star_guest_update.gd", "Event");
        if(BroadcasterUserId != null) request.SetValue("broadcaster_user_id", BroadcasterUserId);
        if(BroadcasterUserName != null) request.SetValue("broadcaster_user_name", BroadcasterUserName);
        if(BroadcasterUserLogin != null) request.SetValue("broadcaster_user_login", BroadcasterUserLogin);
        if(SessionId != null) request.SetValue("session_id", SessionId);
        if(ModeratorUserId != null) request.SetValue("moderator_user_id", ModeratorUserId);
        if(ModeratorUserName != null) request.SetValue("moderator_user_name", ModeratorUserName);
        if(ModeratorUserLogin != null) request.SetValue("moderator_user_login", ModeratorUserLogin);
        if(GuestUserId != null) request.SetValue("guest_user_id", GuestUserId);
        if(GuestUserName != null) request.SetValue("guest_user_name", GuestUserName);
        if(GuestUserLogin != null) request.SetValue("guest_user_login", GuestUserLogin);
        if(SlotId != null) request.SetValue("slot_id", SlotId);
        if(State != null) request.SetValue("state", State);
        if(HostUserId != null) request.SetValue("host_user_id", HostUserId);
        if(HostUserName != null) request.SetValue("host_user_name", HostUserName);
        if(HostUserLogin != null) request.SetValue("host_user_login", HostUserLogin);
        request.SetValue("host_video_enabled", HostVideoEnabled);
        request.SetValue("host_audio_enabled", HostAudioEnabled);
        request.SetValue("host_volume", HostVolume);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
}
