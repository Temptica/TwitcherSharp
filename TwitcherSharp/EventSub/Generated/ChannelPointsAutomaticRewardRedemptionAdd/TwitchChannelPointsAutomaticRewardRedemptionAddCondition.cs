using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelPointsAutomaticRewardRedemptionAdd;

public partial class TwitchChannelPointsAutomaticRewardRedemptionAddCondition(string broadcasterUserId) : RefCounted, ITwitcherSharpCondition<TwitchChannelPointsAutomaticRewardRedemptionAddCondition>
{
    public string Name => nameof(TwitchChannelPointsAutomaticRewardRedemptionAddCondition);

    /// <summary> 
    /// The broadcaster user ID for the channel you want to receive channel points reward add notifications for.
    /// </summary>
    public string BroadcasterUserId { get; set; } = broadcasterUserId;

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelPointsAutomaticRewardRedemptionAddCondition object.
    /// </summary> 
    public static TwitchChannelPointsAutomaticRewardRedemptionAddCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchChannelPointsAutomaticRewardRedemptionAddCondition(data.Get("broadcaster_user_id").AsString());
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_points_automatic_reward_redemption_add.gd");
        var conditionClass = script.Get("Condition").As<GDScript>();
        var request = conditionClass.New().AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        return request;
    }

    public static TwitchChannelPointsAutomaticRewardRedemptionAddCondition FromDictionary(Dictionary data)
    {
        return new TwitchChannelPointsAutomaticRewardRedemptionAddCondition(data["broadcaster_user_id"].AsString())
        {
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
