using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelSubscriptionGift;

public partial class TwitchChannelSubscriptionGiftCondition : RefCounted, ITwitcherSharpCondition<TwitchChannelSubscriptionGiftCondition>
{
    public string Name => nameof(TwitchChannelSubscriptionGiftCondition);

    /// <summary> 
    /// The broadcaster user ID for the channel you want to get subscription gift notifications for.
    /// </summary>
    public string BroadcasterUserId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelSubscriptionGiftCondition object.
    /// </summary> 
    public static TwitchChannelSubscriptionGiftCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchChannelSubscriptionGiftCondition
        {
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_subscription_gift.gd");
        var conditionClass = script.Get("Condition").AsGodotObject();
        var request = conditionClass.Call("new").AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        return request;
    }

    public static TwitchChannelSubscriptionGiftCondition FromDictionary(Dictionary data)
    {
        return new TwitchChannelSubscriptionGiftCondition
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
