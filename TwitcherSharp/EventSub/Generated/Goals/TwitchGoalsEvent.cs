using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.Goals;

public partial class TwitchGoalsEvent : RefCounted, ITwitcherSharpEventSub<TwitchGoalsEvent>
{
    private GodotObject? _data;
    
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
            Id = data.Get("id").AsString(),
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
            BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
            BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
            Type = data.Get("type").AsString(),
            Description = data.Get("description").AsString(),
            IsAchieved = data.Get("is_achieved").AsBool(),
            CurrentAmount = data.Get("current_amount").AsInt32(),
            TargetAmount = data.Get("target_amount").AsInt32(),
            StartedAt = data.Get("started_at").AsString(),
            EndedAt = data.Get("ended_at").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_goals.gd");
        var eventClass = script.Get("Event").As<GDScript>();
        var request = eventClass.New().AsGodotObject();
        if(Id != null) request.Set("id", Id);
        if(BroadcasterUserId != null) request.Set("broadcaster_user_id", BroadcasterUserId);
        if(BroadcasterUserName != null) request.Set("broadcaster_user_name", BroadcasterUserName);
        if(BroadcasterUserLogin != null) request.Set("broadcaster_user_login", BroadcasterUserLogin);
        if(Type != null) request.Set("type", Type);
        if(Description != null) request.Set("description", Description);
        request.Set("is_achieved", IsAchieved);
        request.Set("current_amount", CurrentAmount);
        request.Set("target_amount", TargetAmount);
        if(StartedAt != null) request.Set("started_at", StartedAt);
        if(EndedAt != null) request.Set("ended_at", EndedAt);
        return request;
    }
}
