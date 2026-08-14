using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelPointsCustomRewardAdd;

public partial class TwitchChannelPointsCustomRewardAddCondition(string broadcasterUserId) : RefCounted, ITwitcherSharpCondition<TwitchChannelPointsCustomRewardAddCondition>
{
    private GodotObject? _data;
    
    public string Name => nameof(TwitchChannelPointsCustomRewardAddCondition);

    /// <summary> 
    /// The broadcaster user ID for the channel you want to receive channel points custom reward add notifications for.
    /// </summary>
    public string BroadcasterUserId { get; set; } = broadcasterUserId;

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelPointsCustomRewardAddCondition object.
    /// </summary> 
    public static TwitchChannelPointsCustomRewardAddCondition? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelPointsCustomRewardAddCondition(data.Get("broadcaster_user_id").AsString());
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_points_custom_reward_add.gd");
        var conditionClass = script.Get("Condition").As<GDScript>();
        var request = conditionClass.New().AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        return request;
    }

    public static TwitchChannelPointsCustomRewardAddCondition FromDictionary(Dictionary data)
    {
        return new TwitchChannelPointsCustomRewardAddCondition(data["broadcaster_user_id"].AsString())
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
