using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelSubscriptionGift;

public partial class TwitchChannelSubscriptionGiftCondition(string broadcasterUserId) : RefCounted, ITwitcherSharpCondition<TwitchChannelSubscriptionGiftCondition>
{
    private Variant _data;
    
    public string Name => nameof(TwitchChannelSubscriptionGiftCondition);

    /// <summary> 
    /// The broadcaster user ID for the channel you want to get subscription gift notifications for.
    /// </summary>
    public string BroadcasterUserId { get; set; } = broadcasterUserId;

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelSubscriptionGiftCondition object.
    /// </summary> 
    public static TwitchChannelSubscriptionGiftCondition? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelSubscriptionGiftCondition(data.Read("broadcaster_user_id", static v => v.AsString()));
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_subscription_gift.gd", "Condition");
        request.SetValue("broadcaster_user_id", BroadcasterUserId);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

    public static TwitchChannelSubscriptionGiftCondition FromDictionary(Dictionary data)
    {
        return new TwitchChannelSubscriptionGiftCondition(data["broadcaster_user_id"].AsString())
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
