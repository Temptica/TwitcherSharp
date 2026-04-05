using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelPointsCustomRewardRedemptionAdd;

public partial class TwitchChannelPointsCustomRewardRedemptionAddCondition : RefCounted, ITwitcherSharpCondition<TwitchChannelPointsCustomRewardRedemptionAddCondition>
{
    public string Name => nameof(TwitchChannelPointsCustomRewardRedemptionAddCondition);

    /// <summary> 
    /// The broadcaster user ID for the channel you want to receive channel points custom reward redemption add notifications for.
    /// </summary>
    public string BroadcasterUserId { get; set; }

    /// <summary> 
    /// Optional. Specify a reward id to only receive notifications for a specific reward.
    /// </summary>
    public string RewardId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelPointsCustomRewardRedemptionAddCondition object.
    /// </summary> 
    public static TwitchChannelPointsCustomRewardRedemptionAddCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchChannelPointsCustomRewardRedemptionAddCondition
        {
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
            RewardId = data.Get("reward_id").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_points_custom_reward_redemption_add.gd");
        var conditionClass = script.Get("Condition").As<GDScript>();
        var request = conditionClass.New().AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        request.Set("reward_id", RewardId);
        return request;
    }

    public static TwitchChannelPointsCustomRewardRedemptionAddCondition FromDictionary(Dictionary data)
    {
        return new TwitchChannelPointsCustomRewardRedemptionAddCondition
        {
            BroadcasterUserId = data["broadcaster_user_id"].AsString(),
            RewardId = data["reward_id"].AsString(),
        };
    }

    public Dictionary ToDictionary()
    {
        return new Dictionary
        {
            {"broadcaster_user_id", BroadcasterUserId},
            {"reward_id", RewardId},
        };
    }
}
