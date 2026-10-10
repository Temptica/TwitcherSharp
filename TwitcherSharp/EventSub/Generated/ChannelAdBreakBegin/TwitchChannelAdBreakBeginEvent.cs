using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelAdBreakBegin;

public partial class TwitchChannelAdBreakBeginEvent : RefCounted, ITwitcherSharpEventSub<TwitchChannelAdBreakBeginEvent>
{
    private Variant _data;
    
    /// <summary> 
    /// Length in seconds of the mid-roll ad break requested
    /// </summary>
    public int DurationSeconds { get; set; }

    /// <summary> 
    /// The UTC timestamp of when the ad break began, in RFC3339 format. Note that there is potential delay between this event, when the streamer requested the ad break, and when the viewers will see ads.
    /// </summary>
    public string? StartedAt { get; set; }

    /// <summary> 
    /// Indicates if the ad was automatically scheduled via Ads Manager
    /// </summary>
    public bool IsAutomatic { get; set; }

    /// <summary> 
    /// The broadcaster’s user ID for the channel the ad was run on.
    /// </summary>
    public string? BroadcasterUserId { get; set; }

    /// <summary> 
    /// The broadcaster’s user login for the channel the ad was run on.
    /// </summary>
    public string? BroadcasterUserLogin { get; set; }

    /// <summary> 
    /// The broadcaster’s user display name for the channel the ad was run on.
    /// </summary>
    public string? BroadcasterUserName { get; set; }

    /// <summary> 
    /// The ID of the user that requested the ad. For automatic ads, this will be the ID of the broadcaster.
    /// </summary>
    public string? RequesterUserId { get; set; }

    /// <summary> 
    /// The login of the user that requested the ad.
    /// </summary>
    public string? RequesterUserLogin { get; set; }

    /// <summary> 
    /// The display name of the user that requested the ad.
    /// </summary>
    public string? RequesterUserName { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelAdBreakBeginEvent object.
    /// </summary> 
    public static TwitchChannelAdBreakBeginEvent? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelAdBreakBeginEvent
        {
            DurationSeconds = data.ReadAsInt32("duration_seconds"),
            StartedAt = data.ReadAsString("started_at"),
            IsAutomatic = data.ReadAsBool("is_automatic"),
            BroadcasterUserId = data.ReadAsString("broadcaster_user_id"),
            BroadcasterUserLogin = data.ReadAsString("broadcaster_user_login"),
            BroadcasterUserName = data.ReadAsString("broadcaster_user_name"),
            RequesterUserId = data.ReadAsString("requester_user_id"),
            RequesterUserLogin = data.ReadAsString("requester_user_login"),
            RequesterUserName = data.ReadAsString("requester_user_name"),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_ad_break_begin.gd", "Event");
        request.SetValue("duration_seconds", DurationSeconds);
        if(StartedAt != null) request.SetValue("started_at", StartedAt);
        request.SetValue("is_automatic", IsAutomatic);
        if(BroadcasterUserId != null) request.SetValue("broadcaster_user_id", BroadcasterUserId);
        if(BroadcasterUserLogin != null) request.SetValue("broadcaster_user_login", BroadcasterUserLogin);
        if(BroadcasterUserName != null) request.SetValue("broadcaster_user_name", BroadcasterUserName);
        if(RequesterUserId != null) request.SetValue("requester_user_id", RequesterUserId);
        if(RequesterUserLogin != null) request.SetValue("requester_user_login", RequesterUserLogin);
        if(RequesterUserName != null) request.SetValue("requester_user_name", RequesterUserName);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
}
