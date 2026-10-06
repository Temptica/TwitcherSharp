using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelPointsAutomaticRewardRedemptionAdd;

public partial class TwitchChannelPointsAutomaticRewardRedemptionAddCondition(string broadcasterUserId) : RefCounted, ITwitcherSharpCondition<TwitchChannelPointsAutomaticRewardRedemptionAddCondition>
{
    private Variant _data;
    
    public string Name => nameof(TwitchChannelPointsAutomaticRewardRedemptionAddCondition);

    /// <summary> 
    /// The broadcaster user ID for the channel you want to receive channel points reward add notifications for.
    /// </summary>
    public string BroadcasterUserId { get; set; } = broadcasterUserId;

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelPointsAutomaticRewardRedemptionAddCondition object.
    /// </summary> 
    public static TwitchChannelPointsAutomaticRewardRedemptionAddCondition? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelPointsAutomaticRewardRedemptionAddCondition(data.Read("broadcaster_user_id", static v => v.AsString()));
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_points_automatic_reward_redemption_add.gd", "Condition");
        request.SetValue("broadcaster_user_id", BroadcasterUserId);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
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
