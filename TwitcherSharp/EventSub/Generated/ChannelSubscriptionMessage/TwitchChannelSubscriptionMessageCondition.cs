using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelSubscriptionMessage;

public partial class TwitchChannelSubscriptionMessageCondition : RefCounted, ITwitcherSharpCondition<TwitchChannelSubscriptionMessageCondition>
{
    public string Name => nameof(TwitchChannelSubscriptionMessageCondition);

    /// <summary> 
    /// The broadcaster user ID for the channel you want to get resubscription chat message notifications for.
    /// </summary>
    public string BroadcasterUserId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelSubscriptionMessageCondition object.
    /// </summary> 
    public static TwitchChannelSubscriptionMessageCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchChannelSubscriptionMessageCondition
        {
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_subscription_message.gd");
        var conditionClass = script.Get("Condition").As<GDScript>();
        var request = conditionClass.New().AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        return request;
    }

    public static TwitchChannelSubscriptionMessageCondition FromDictionary(Dictionary data)
    {
        return new TwitchChannelSubscriptionMessageCondition
        {
            BroadcasterUserId = data["broadcaster_user_id"].AsString(),
        };
    }

    public Dictionary ToDictionary()
    {
        return new Dictionary
        {
            {"broadcaster_user_id", BroadcasterUserId},
        };
    }
}
