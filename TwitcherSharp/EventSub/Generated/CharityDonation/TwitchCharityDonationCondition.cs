using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.CharityDonation;

public partial class TwitchCharityDonationCondition(string broadcasterUserId) : RefCounted, ITwitcherSharpCondition<TwitchCharityDonationCondition>
{
    private GodotObject? _data;
    
    public string Name => nameof(TwitchCharityDonationCondition);

    /// <summary> 
    /// The ID of the broadcaster that you want to receive notifications about when users donate to their campaign.
    /// </summary>
    public string BroadcasterUserId { get; set; } = broadcasterUserId;

    /// <summary> 
    /// Transforms the godot data into a TwitchCharityDonationCondition object.
    /// </summary> 
    public static TwitchCharityDonationCondition? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchCharityDonationCondition(data.Get("broadcaster_user_id").AsString());
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_charity_donation.gd");
        var conditionClass = script.Get("Condition").As<GDScript>();
        var request = conditionClass.New().AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        return request;
    }

    public static TwitchCharityDonationCondition FromDictionary(Dictionary data)
    {
        return new TwitchCharityDonationCondition(data["broadcaster_user_id"].AsString())
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
