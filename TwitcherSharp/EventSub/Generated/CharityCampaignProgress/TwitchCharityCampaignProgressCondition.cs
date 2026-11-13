using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.CharityCampaignProgress;

public partial class TwitchCharityCampaignProgressCondition(string broadcasterUserId) : RefCounted, ITwitcherSharpCondition<TwitchCharityCampaignProgressCondition>
{
    private Variant _data;
    
    public string Name => nameof(TwitchCharityCampaignProgressCondition);

    /// <summary> 
    /// The ID of the broadcaster that you want to receive notifications about when their campaign makes progress or is updated.
    /// </summary>
    public string BroadcasterUserId { get; set; } = broadcasterUserId;

    /// <summary> 
    /// Transforms the godot data into a TwitchCharityCampaignProgressCondition object.
    /// </summary> 
    public static TwitchCharityCampaignProgressCondition? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchCharityCampaignProgressCondition(data.ReadAsString("broadcaster_user_id"));
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_charity_campaign_progress.gd", "Condition");
        request.SetValue("broadcaster_user_id", BroadcasterUserId);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

    public static TwitchCharityCampaignProgressCondition FromDictionary(Dictionary data)
    {
        return new TwitchCharityCampaignProgressCondition(data["broadcaster_user_id"].AsString())
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
