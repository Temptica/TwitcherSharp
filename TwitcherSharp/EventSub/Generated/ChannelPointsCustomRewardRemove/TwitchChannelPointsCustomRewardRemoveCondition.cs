using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelPointsCustomRewardRemove;

public partial class TwitchChannelPointsCustomRewardRemoveCondition(string broadcasterUserId) : RefCounted, ITwitcherSharpCondition<TwitchChannelPointsCustomRewardRemoveCondition>
{
    private GodotObject _data;
    
    public string Name => nameof(TwitchChannelPointsCustomRewardRemoveCondition);

    /// <summary> 
    /// The broadcaster user ID for the channel you want to receive channel points custom reward remove notifications for.
    /// </summary>
    public string BroadcasterUserId { get; set; } = broadcasterUserId;

    /// <summary> 
    /// Optional. Specify a reward id to only receive notifications for a specific reward.
    /// </summary>
    public string RewardId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelPointsCustomRewardRemoveCondition object.
    /// </summary> 
    public static TwitchChannelPointsCustomRewardRemoveCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelPointsCustomRewardRemoveCondition(data.Get("broadcaster_user_id").AsString())
        {
            RewardId = data.Get("reward_id").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_points_custom_reward_remove.gd");
        var conditionClass = script.Get("Condition").As<GDScript>();
        var request = conditionClass.New().AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        request.Set("reward_id", RewardId);
        return request;
    }

    public static TwitchChannelPointsCustomRewardRemoveCondition FromDictionary(Dictionary data)
    {
        return new TwitchChannelPointsCustomRewardRemoveCondition(data["broadcaster_user_id"].AsString())
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
