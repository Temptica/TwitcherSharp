using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;
using TwitcherSharp.EventSub.Generated.Shared;

namespace TwitcherSharp.EventSub.Generated.ChannelPollBegin;

public partial class TwitchChannelPollBeginEvent : RefCounted, ITwitcherSharpEventSub<TwitchChannelPollBeginEvent>
{
    private Variant _data;
    
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
    /// An array of choices for the poll.
    /// </summary>
    public TwitchChoices[]? Choices { get => field ??= _data.GetArray<TwitchChoices>("choices"); set; }

    /// <summary> 
    /// NOTE: Bits voting is not supported.
    /// </summary>
    public TwitchBitsVoting? BitsVoting { get => field ??= _data.Get<TwitchBitsVoting>("bits_voting"); set; }

    /// <summary> 
    /// 
    /// </summary>
    public TwitchChannelPointsVoting? ChannelPointsVoting { get => field ??= _data.Get<TwitchChannelPointsVoting>("channel_points_voting"); set; }

    /// <summary> 
    /// The time the poll started.
    /// </summary>
    public string? StartedAt { get; set; }

    /// <summary> 
    /// The time the poll will end.
    /// </summary>
    public string? EndsAt { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelPollBeginEvent object.
    /// </summary> 
    public static TwitchChannelPollBeginEvent? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelPollBeginEvent
        {
            Id = data.Read("id", static v => v.AsString()),
            BroadcasterUserId = data.Read("broadcaster_user_id", static v => v.AsString()),
            BroadcasterUserLogin = data.Read("broadcaster_user_login", static v => v.AsString()),
            BroadcasterUserName = data.Read("broadcaster_user_name", static v => v.AsString()),
            Title = data.Read("title", static v => v.AsString()),
            StartedAt = data.Read("started_at", static v => v.AsString()),
            EndsAt = data.Read("ends_at", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_poll_begin.gd", "Event");
        if(Id != null) request.SetValue("id", Id);
        if(BroadcasterUserId != null) request.SetValue("broadcaster_user_id", BroadcasterUserId);
        if(BroadcasterUserLogin != null) request.SetValue("broadcaster_user_login", BroadcasterUserLogin);
        if(BroadcasterUserName != null) request.SetValue("broadcaster_user_name", BroadcasterUserName);
        if(Title != null) request.SetValue("title", Title);
        if(Choices != null) request.SetArray("choices", Choices);
        if(BitsVoting != null) request.SetObject("bits_voting", BitsVoting);
        if(ChannelPointsVoting != null) request.SetObject("channel_points_voting", ChannelPointsVoting);
        if(StartedAt != null) request.SetValue("started_at", StartedAt);
        if(EndsAt != null) request.SetValue("ends_at", EndsAt);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
}
