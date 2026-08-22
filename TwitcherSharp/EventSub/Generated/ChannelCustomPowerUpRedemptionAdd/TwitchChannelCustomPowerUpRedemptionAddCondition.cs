using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelCustomPowerUpRedemptionAdd;

public partial class TwitchChannelCustomPowerUpRedemptionAddCondition(string broadcasterUserId) : RefCounted, ITwitcherSharpCondition<TwitchChannelCustomPowerUpRedemptionAddCondition>
{
    private GodotObject _data;
    
    public string Name => nameof(TwitchChannelCustomPowerUpRedemptionAddCondition);

    /// <summary> 
    /// The broadcaster user ID for the channel you want to receive custom Power-up redemption add notifications for.
    /// </summary>
    public string BroadcasterUserId { get; set; } = broadcasterUserId;

    /// <summary> 
    /// Optional. Specify a reward id to only receive notifications for a specific custom Power-up.
    /// </summary>
    public string RewardId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelCustomPowerUpRedemptionAddCondition object.
    /// </summary> 
    public static TwitchChannelCustomPowerUpRedemptionAddCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelCustomPowerUpRedemptionAddCondition(data.Get("broadcaster_user_id").AsString())
        {
            RewardId = data.Get("reward_id").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_custom_power_up_redemption_add.gd");
        var conditionClass = script.Get("Condition").As<GDScript>();
        var request = conditionClass.New().AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        request.Set("reward_id", RewardId);
        return request;
    }

    public static TwitchChannelCustomPowerUpRedemptionAddCondition FromDictionary(Dictionary data)
    {
        return new TwitchChannelCustomPowerUpRedemptionAddCondition(data["broadcaster_user_id"].AsString())
        {
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
