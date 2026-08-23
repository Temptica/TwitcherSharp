using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;
using TwitcherSharp.EventSub.Generated.Shared;

namespace TwitcherSharp.EventSub.Generated.ChannelPollEnd;

public partial class TwitchChannelPollEndEvent : RefCounted, ITwitcherSharpEventSub<TwitchChannelPollEndEvent>
{
    private GodotObject? _data;
    
    /// <summary> 
    /// ID of the poll.
    /// </summary>
    public string? Id { get; set; }

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
    /// Question displayed for the poll.
    /// </summary>
    public string? Title { get; set; }

    /// <summary> 
    /// An array of choices for the poll. Includes vote counts.
    /// </summary>
    public TwitchChoices[]? Choices { get => field ??= _data?.GetArray<TwitchChoices>("choices"); set; }

    /// <summary> 
    /// NOTE: Bits voting is not supported.
    /// </summary>
    public TwitchBitsVoting? BitsVoting { get => field ??= _data?.Get<TwitchBitsVoting>("bits_voting"); set; }

    /// <summary> 
    /// 
    /// </summary>
    public TwitchChannelPointsVoting? ChannelPointsVoting { get => field ??= _data?.Get<TwitchChannelPointsVoting>("channel_points_voting"); set; }

    /// <summary> 
    /// The status of the poll. Valid values are completed, archived, and terminated.
    /// </summary>
    public string? Status { get; set; }

    /// <summary> 
    /// The time the poll started.
    /// </summary>
    public string? StartedAt { get; set; }

    /// <summary> 
    /// The time the poll ended.
    /// </summary>
    public string? EndedAt { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelPollEndEvent object.
    /// </summary> 
    public static TwitchChannelPollEndEvent? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelPollEndEvent
        {
            Id = data.Get("id").AsString(),
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
            BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
            BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
            Title = data.Get("title").AsString(),
            Status = data.Get("status").AsString(),
            StartedAt = data.Get("started_at").AsString(),
            EndedAt = data.Get("ended_at").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_poll_end.gd");
        var eventClass = script.Get("Event").As<GDScript>();
        var request = eventClass.New().AsGodotObject();
        if(Id != null) request.Set("id", Id);
        if(BroadcasterUserId != null) request.Set("broadcaster_user_id", BroadcasterUserId);
        if(BroadcasterUserLogin != null) request.Set("broadcaster_user_login", BroadcasterUserLogin);
        if(BroadcasterUserName != null) request.Set("broadcaster_user_name", BroadcasterUserName);
        if(Title != null) request.Set("title", Title);
        if(Choices != null) request.Set("choices", Choices.ToGodotArray());
        if(BitsVoting != null) request.Set("bits_voting", BitsVoting.ToGodotObject());
        if(ChannelPointsVoting != null) request.Set("channel_points_voting", ChannelPointsVoting.ToGodotObject());
        if(Status != null) request.Set("status", Status);
        if(StartedAt != null) request.Set("started_at", StartedAt);
        if(EndedAt != null) request.Set("ended_at", EndedAt);
        return request;
    }
}
