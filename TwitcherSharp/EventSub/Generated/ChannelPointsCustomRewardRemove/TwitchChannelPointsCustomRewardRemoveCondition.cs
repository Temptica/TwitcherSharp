using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelPointsCustomRewardRemove;

public partial class TwitchChannelPointsCustomRewardRemoveCondition(string broadcasterUserId) : RefCounted, ITwitcherSharpCondition<TwitchChannelPointsCustomRewardRemoveCondition>
{
    private Variant _data;
    
    public string Name => nameof(TwitchChannelPointsCustomRewardRemoveCondition);

    /// <summary> 
    /// The broadcaster user ID for the channel you want to receive channel points custom reward remove notifications for.
    /// </summary>
    public string BroadcasterUserId { get; set; } = broadcasterUserId;

    /// <summary> 
    /// Optional. Specify a reward id to only receive notifications for a specific reward.
    /// </summary>
    public string? RewardId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelPointsCustomRewardRemoveCondition object.
    /// </summary> 
    public static TwitchChannelPointsCustomRewardRemoveCondition? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelPointsCustomRewardRemoveCondition(data.Read("broadcaster_user_id", static v => v.AsString()))
        {
            RewardId = data.Read("reward_id", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_points_custom_reward_remove.gd", "Condition");
        request.SetValue("broadcaster_user_id", BroadcasterUserId);
        if(RewardId != null) request.SetValue("reward_id", RewardId);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
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
            {"reward_id", RewardId!},
        };
    }
}
