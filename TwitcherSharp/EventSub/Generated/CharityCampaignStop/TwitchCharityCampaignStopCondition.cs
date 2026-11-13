using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.CharityCampaignStop;

public partial class TwitchCharityCampaignStopCondition(string broadcasterUserId) : RefCounted, ITwitcherSharpCondition<TwitchCharityCampaignStopCondition>
{
    private Variant _data;
    
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
        var instance = new TwitchCharityCampaignStopCondition(data.ReadAsString("broadcaster_user_id"));
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_charity_campaign_stop.gd", "Condition");
        request.SetValue("broadcaster_user_id", BroadcasterUserId);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
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
