using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelRaid;

public partial class TwitchChannelRaidEvent : RefCounted, ITwitcherSharpEventSub<TwitchChannelRaidEvent>
{
    private Variant _data;
    
    /// <summary> 
    /// The broadcaster ID that created the raid.
    /// </summary>
    public string? FromBroadcasterUserId { get; set; }

    /// <summary> 
    /// The broadcaster login that created the raid.
    /// </summary>
    public string? FromBroadcasterUserLogin { get; set; }

    /// <summary> 
    /// The broadcaster display name that created the raid.
    /// </summary>
    public string? FromBroadcasterUserName { get; set; }

    /// <summary> 
    /// The broadcaster ID that received the raid.
    /// </summary>
    public string? ToBroadcasterUserId { get; set; }

    /// <summary> 
    /// The broadcaster login that received the raid.
    /// </summary>
    public string? ToBroadcasterUserLogin { get; set; }

    /// <summary> 
    /// The broadcaster display name that received the raid.
    /// </summary>
    public string? ToBroadcasterUserName { get; set; }

    /// <summary> 
    /// The number of viewers in the raid.
    /// </summary>
    public int Viewers { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelRaidEvent object.
    /// </summary> 
    public static TwitchChannelRaidEvent? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelRaidEvent
        {
            FromBroadcasterUserId = data.Read("from_broadcaster_user_id", static v => v.AsString()),
            FromBroadcasterUserLogin = data.Read("from_broadcaster_user_login", static v => v.AsString()),
            FromBroadcasterUserName = data.Read("from_broadcaster_user_name", static v => v.AsString()),
            ToBroadcasterUserId = data.Read("to_broadcaster_user_id", static v => v.AsString()),
            ToBroadcasterUserLogin = data.Read("to_broadcaster_user_login", static v => v.AsString()),
            ToBroadcasterUserName = data.Read("to_broadcaster_user_name", static v => v.AsString()),
            Viewers = data.Read("viewers", static v => v.AsInt32()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_raid.gd", "Event");
        if(FromBroadcasterUserId != null) request.SetValue("from_broadcaster_user_id", FromBroadcasterUserId);
        if(FromBroadcasterUserLogin != null) request.SetValue("from_broadcaster_user_login", FromBroadcasterUserLogin);
        if(FromBroadcasterUserName != null) request.SetValue("from_broadcaster_user_name", FromBroadcasterUserName);
        if(ToBroadcasterUserId != null) request.SetValue("to_broadcaster_user_id", ToBroadcasterUserId);
        if(ToBroadcasterUserLogin != null) request.SetValue("to_broadcaster_user_login", ToBroadcasterUserLogin);
        if(ToBroadcasterUserName != null) request.SetValue("to_broadcaster_user_name", ToBroadcasterUserName);
        request.SetValue("viewers", Viewers);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
}
