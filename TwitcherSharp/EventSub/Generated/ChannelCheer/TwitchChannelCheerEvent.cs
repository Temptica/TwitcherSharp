using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelCheer;

public partial class TwitchChannelCheerEvent : RefCounted, ITwitcherSharpEventSub<TwitchChannelCheerEvent>
{
    private Variant _data;
    
    /// <summary> 
    /// Whether the user cheered anonymously or not.
    /// </summary>
    public bool IsAnonymous { get; set; }

    /// <summary> 
    /// The user ID for the user who cheered on the specified channel. This is null if is_anonymous is true.
    /// </summary>
    public string? UserId { get; set; }

    /// <summary> 
    /// The user login for the user who cheered on the specified channel. This is null if is_anonymous is true.
    /// </summary>
    public string? UserLogin { get; set; }

    /// <summary> 
    /// The user display name for the user who cheered on the specified channel. This is null if is_anonymous is true.
    /// </summary>
    public string? UserName { get; set; }

    /// <summary> 
    /// The requested broadcaster ID.
    /// </summary>
    public string? BroadcasterUserId { get; set; }

    /// <summary> 
    /// The requested broadcaster login.
    /// </summary>
    public string? BroadcasterUserLogin { get; set; }

    /// <summary> 
    /// The requested broadcaster display name.
    /// </summary>
    public string? BroadcasterUserName { get; set; }

    /// <summary> 
    /// The message sent with the cheer.
    /// </summary>
    public string? Message { get; set; }

    /// <summary> 
    /// The number of Bits cheered.
    /// </summary>
    public int Bits { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelCheerEvent object.
    /// </summary> 
    public static TwitchChannelCheerEvent? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelCheerEvent
        {
            IsAnonymous = data.Read("is_anonymous", static v => v.AsBool()),
            UserId = data.Read("user_id", static v => v.AsString()),
            UserLogin = data.Read("user_login", static v => v.AsString()),
            UserName = data.Read("user_name", static v => v.AsString()),
            BroadcasterUserId = data.Read("broadcaster_user_id", static v => v.AsString()),
            BroadcasterUserLogin = data.Read("broadcaster_user_login", static v => v.AsString()),
            BroadcasterUserName = data.Read("broadcaster_user_name", static v => v.AsString()),
            Message = data.Read("message", static v => v.AsString()),
            Bits = data.Read("bits", static v => v.AsInt32()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_cheer.gd", "Event");
        request.SetValue("is_anonymous", IsAnonymous);
        if(UserId != null) request.SetValue("user_id", UserId);
        if(UserLogin != null) request.SetValue("user_login", UserLogin);
        if(UserName != null) request.SetValue("user_name", UserName);
        if(BroadcasterUserId != null) request.SetValue("broadcaster_user_id", BroadcasterUserId);
        if(BroadcasterUserLogin != null) request.SetValue("broadcaster_user_login", BroadcasterUserLogin);
        if(BroadcasterUserName != null) request.SetValue("broadcaster_user_name", BroadcasterUserName);
        if(Message != null) request.SetValue("message", Message);
        request.SetValue("bits", Bits);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
}
