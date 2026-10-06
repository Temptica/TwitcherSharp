using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.Goals;

public partial class TwitchGoalsEvent : RefCounted, ITwitcherSharpEventSub<TwitchGoalsEvent>
{
    private Variant _data;
    
    /// <summary> 
    /// An ID that identifies this event.
    /// </summary>
    public string? Id { get; set; }

    /// <summary> 
    /// An ID that uniquely identifies the broadcaster.
    /// </summary>
    public string? BroadcasterUserId { get; set; }

    /// <summary> 
    /// The broadcaster’s display name.
    /// </summary>
    public string? BroadcasterUserName { get; set; }

    /// <summary> 
    /// The broadcaster’s user handle.
    /// </summary>
    public string? BroadcasterUserLogin { get; set; }

    /// <summary> 
    /// The type of goal. Possible values are: follow — The goal is to increase followers.subscription — The goal is to increase subscriptions. This type shows the net increase or decrease in tier points associated with the subscriptions.subscription_count — The goal is to increase subscriptions. This type shows the net increase or decrease in the number of subscriptions.new_subscription — The goal is to increase subscriptions. This type shows only the net increase in tier points associated with the subscriptions (it does not account for users that unsubscribed since the goal started).new_subscription_count — The goal is to increase subscriptions. This type shows only the net increase in the number of subscriptions (it does not account for users that unsubscribed since the goal started).new_bit — The goal is to increase the amount of Bits used on the channel.new_cheerer — The goal is to increase the number of unique Cheerers to Cheer on the channel.
    /// </summary>
    public string? Type { get; set; }

    /// <summary> 
    /// A description of the goal, if specified. The description may contain a maximum of 40 characters.
    /// </summary>
    public string? Description { get; set; }

    /// <summary> 
    /// A Boolean value that indicates whether the broadcaster achieved their goal. Is true if the goal was achieved; otherwise, false.Only the channel.goal.end event includes this field.
    /// </summary>
    public bool IsAchieved { get; set; }

    /// <summary> 
    /// The goal’s current value.The goal’s type determines how this value is increased or decreased.If type is follow, this field is set to the broadcaster's current number of followers. This number increases with new followers and decreases when users unfollow the broadcaster.If type is subscription, this field is increased and decreased by the points value associated with the subscription tier. For example, if a tier-two subscription is worth 2 points, this field is increased or decreased by 2, not 1.If type is subscription_count, this field is increased by 1 for each new subscription and decreased by 1 for each user that unsubscribes.If type is new_subscription, this field is increased by the points value associated with the subscription tier. For example, if a tier-two subscription is worth 2 points, this field is increased by 2, not 1.If type is new_subscription_count, this field is increased by 1 for each new subscription.
    /// </summary>
    public int CurrentAmount { get; set; }

    /// <summary> 
    /// The goal’s target value. For example, if the broadcaster has 200 followers before creating the goal, and their goal is to double that number, this field is set to 400.
    /// </summary>
    public int TargetAmount { get; set; }

    /// <summary> 
    /// The UTC timestamp in RFC 3339 format, which indicates when the broadcaster created the goal.
    /// </summary>
    public string? StartedAt { get; set; }

    /// <summary> 
    /// The UTC timestamp in RFC 3339 format, which indicates when the broadcaster ended the goal.Only the channel.goal.end event includes this field.
    /// </summary>
    public string? EndedAt { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGoalsEvent object.
    /// </summary> 
    public static TwitchGoalsEvent? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGoalsEvent
        {
            Id = data.Read("id", static v => v.AsString()),
            BroadcasterUserId = data.Read("broadcaster_user_id", static v => v.AsString()),
            BroadcasterUserName = data.Read("broadcaster_user_name", static v => v.AsString()),
            BroadcasterUserLogin = data.Read("broadcaster_user_login", static v => v.AsString()),
            Type = data.Read("type", static v => v.AsString()),
            Description = data.Read("description", static v => v.AsString()),
            IsAchieved = data.Read("is_achieved", static v => v.AsBool()),
            CurrentAmount = data.Read("current_amount", static v => v.AsInt32()),
            TargetAmount = data.Read("target_amount", static v => v.AsInt32()),
            StartedAt = data.Read("started_at", static v => v.AsString()),
            EndedAt = data.Read("ended_at", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_goals.gd", "Event");
        if(Id != null) request.SetValue("id", Id);
        if(BroadcasterUserId != null) request.SetValue("broadcaster_user_id", BroadcasterUserId);
        if(BroadcasterUserName != null) request.SetValue("broadcaster_user_name", BroadcasterUserName);
        if(BroadcasterUserLogin != null) request.SetValue("broadcaster_user_login", BroadcasterUserLogin);
        if(Type != null) request.SetValue("type", Type);
        if(Description != null) request.SetValue("description", Description);
        request.SetValue("is_achieved", IsAchieved);
        request.SetValue("current_amount", CurrentAmount);
        request.SetValue("target_amount", TargetAmount);
        if(StartedAt != null) request.SetValue("started_at", StartedAt);
        if(EndedAt != null) request.SetValue("ended_at", EndedAt);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
}
