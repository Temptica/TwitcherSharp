using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.CharityCampaignStop;

public partial class TwitchCharityCampaignStopCondition(string broadcasterUserId) : RefCounted, ITwitcherSharpCondition<TwitchCharityCampaignStopCondition>
{
    private GodotObject? _data;
    
    public string Name => nameof(TwitchCharityCampaignStopCondition);

    /// <summary> 
    /// The ID of the broadcaster that you want to receive notifications about when they stop a charity campaign.
    /// </summary>
    public string BroadcasterUserId { get; set; } = broadcasterUserId;

    /// <summary> 
    /// Transforms the godot data into a TwitchCharityCampaignStopCondition object.
    /// </summary> 
    public static TwitchCharityCampaignStopCondition? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchCharityCampaignStopCondition(data.Get("broadcaster_user_id").AsString());
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_charity_campaign_stop.gd");
        var conditionClass = script.Get("Condition").As<GDScript>();
        var request = conditionClass.New().AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        return request;
    }

    public static TwitchCharityCampaignStopCondition FromDictionary(Dictionary data)
    {
        return new TwitchCharityCampaignStopCondition(data["broadcaster_user_id"].AsString())
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
