using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelVIPAdd;

public partial class TwitchChannelVIPAddCondition(string broadcasterUserId) : RefCounted, ITwitcherSharpCondition<TwitchChannelVIPAddCondition>
{
    private Variant _data;
    
    public string Name => nameof(TwitchChannelVIPAddCondition);

    /// <summary> 
    /// The User ID of the broadcaster (channel) Maximum: 1
    /// </summary>
    public string BroadcasterUserId { get; set; } = broadcasterUserId;

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelVIPAddCondition object.
    /// </summary> 
    public static TwitchChannelVIPAddCondition? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelVIPAddCondition(data.Read("broadcaster_user_id", static v => v.AsString()));
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_vip_add.gd", "Condition");
        request.SetValue("broadcaster_user_id", BroadcasterUserId);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

    public static TwitchChannelVIPAddCondition FromDictionary(Dictionary data)
    {
        return new TwitchChannelVIPAddCondition(data["broadcaster_user_id"].AsString())
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
