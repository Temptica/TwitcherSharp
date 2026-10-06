using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelPointsCustomRewardAdd;

public partial class TwitchChannelPointsCustomRewardAddCondition(string broadcasterUserId) : RefCounted, ITwitcherSharpCondition<TwitchChannelPointsCustomRewardAddCondition>
{
    private Variant _data;
    
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
        var instance = new TwitchChannelPointsCustomRewardAddCondition(data.Read("broadcaster_user_id", static v => v.AsString()));
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_points_custom_reward_add.gd", "Condition");
        request.SetValue("broadcaster_user_id", BroadcasterUserId);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
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
