using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelAdBreakBegin;

public partial class TwitchChannelAdBreakBeginEvent : RefCounted, ITwitcherSharpEventSub<TwitchChannelAdBreakBeginEvent>
{
    /// <summary> 
    /// Length in seconds of the mid-roll ad break requested
    /// </summary>
    public int DurationSeconds { get; set; }

    /// <summary> 
    /// The UTC timestamp of when the ad break began, in RFC3339 format. Note that there is potential delay between this event, when the streamer requested the ad break, and when the viewers will see ads.
    /// </summary>
    public string StartedAt { get; set; }

    /// <summary> 
    /// Indicates if the ad was automatically scheduled via Ads Manager
    /// </summary>
    public bool IsAutomatic { get; set; }

    /// <summary> 
    /// The broadcaster’s user ID for the channel the ad was run on.
    /// </summary>
    public string BroadcasterUserId { get; set; }

    /// <summary> 
    /// The broadcaster’s user login for the channel the ad was run on.
    /// </summary>
    public string BroadcasterUserLogin { get; set; }

    /// <summary> 
    /// The broadcaster’s user display name for the channel the ad was run on.
    /// </summary>
    public string BroadcasterUserName { get; set; }

    /// <summary> 
    /// The ID of the user that requested the ad. For automatic ads, this will be the ID of the broadcaster.
    /// </summary>
    public string RequesterUserId { get; set; }

    /// <summary> 
    /// The login of the user that requested the ad.
    /// </summary>
    public string RequesterUserLogin { get; set; }

    /// <summary> 
    /// The display name of the user that requested the ad.
    /// </summary>
    public string RequesterUserName { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelAdBreakBeginEvent object.
    /// </summary> 
    public static TwitchChannelAdBreakBeginEvent FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchChannelAdBreakBeginEvent
        {
            DurationSeconds = data.Get("duration_seconds").AsInt32(),
            StartedAt = data.Get("started_at").AsString(),
            IsAutomatic = data.Get("is_automatic").AsBool(),
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
            BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
            BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
            RequesterUserId = data.Get("requester_user_id").AsString(),
            RequesterUserLogin = data.Get("requester_user_login").AsString(),
            RequesterUserName = data.Get("requester_user_name").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_ad_break_begin.gd");
        var eventClass = script.Get("Event").As<GDScript>();
        var request = eventClass.New().AsGodotObject();
        request.Set("duration_seconds", DurationSeconds);
        request.Set("started_at", StartedAt);
        request.Set("is_automatic", IsAutomatic);
        request.Set("broadcaster_user_id", BroadcasterUserId);
        request.Set("broadcaster_user_login", BroadcasterUserLogin);
        request.Set("broadcaster_user_name", BroadcasterUserName);
        request.Set("requester_user_id", RequesterUserId);
        request.Set("requester_user_login", RequesterUserLogin);
        request.Set("requester_user_name", RequesterUserName);
        return request;
    }
}
