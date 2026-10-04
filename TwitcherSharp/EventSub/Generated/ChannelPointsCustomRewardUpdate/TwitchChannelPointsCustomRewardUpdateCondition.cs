using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelPointsCustomRewardUpdate;

public partial class TwitchChannelPointsCustomRewardUpdateCondition(string broadcasterUserId) : RefCounted, ITwitcherSharpCondition<TwitchChannelPointsCustomRewardUpdateCondition>
{
    private Variant _data;
    
    public string Name => nameof(TwitchChannelPointsCustomRewardUpdateCondition);

    /// <summary> 
    /// The broadcaster user ID for the channel you want to receive channel points custom reward update notifications for.
    /// </summary>
    public string BroadcasterUserId { get; set; } = broadcasterUserId;

    /// <summary> 
    /// Optional. Specify a reward id to only receive notifications for a specific reward.
    /// </summary>
    public string? RewardId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelPointsCustomRewardUpdateCondition object.
    /// </summary> 
    public static TwitchChannelPointsCustomRewardUpdateCondition? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelPointsCustomRewardUpdateCondition(data.Read("broadcaster_user_id", static v => v.AsString()))
        {
            RewardId = data.Read("reward_id", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_points_custom_reward_update.gd", "Condition");
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

    public static TwitchChannelPointsCustomRewardUpdateCondition FromDictionary(Dictionary data)
    {
        return new TwitchChannelPointsCustomRewardUpdateCondition(data["broadcaster_user_id"].AsString())
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
