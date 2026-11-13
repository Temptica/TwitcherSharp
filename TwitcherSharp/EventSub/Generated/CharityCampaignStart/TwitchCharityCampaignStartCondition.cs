using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.CharityCampaignStart;

public partial class TwitchCharityCampaignStartCondition(string broadcasterUserId) : RefCounted, ITwitcherSharpCondition<TwitchCharityCampaignStartCondition>
{
    private Variant _data;
    
    public string Name => nameof(TwitchCharityCampaignStartCondition);

    /// <summary> 
    /// The ID of the broadcaster that you want to receive notifications about when they start a charity campaign.
    /// </summary>
    public string BroadcasterUserId { get; set; } = broadcasterUserId;

    /// <summary> 
    /// Transforms the godot data into a TwitchCharityCampaignStartCondition object.
    /// </summary> 
    public static TwitchCharityCampaignStartCondition? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchCharityCampaignStartCondition(data.ReadAsString("broadcaster_user_id"));
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_charity_campaign_start.gd", "Condition");
        request.SetValue("broadcaster_user_id", BroadcasterUserId);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

    public static TwitchCharityCampaignStartCondition FromDictionary(Dictionary data)
    {
        return new TwitchCharityCampaignStartCondition(data["broadcaster_user_id"].AsString())
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
