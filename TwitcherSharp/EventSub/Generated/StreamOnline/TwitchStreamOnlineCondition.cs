using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.StreamOnline;

public partial class TwitchStreamOnlineCondition(string broadcasterUserId) : RefCounted, ITwitcherSharpCondition<TwitchStreamOnlineCondition>
{
    private Variant _data;
    
    public string Name => nameof(TwitchStreamOnlineCondition);

    /// <summary> 
    /// The broadcaster user ID you want to get stream online notifications for.
    /// </summary>
    public string BroadcasterUserId { get; set; } = broadcasterUserId;

    /// <summary> 
    /// Transforms the godot data into a TwitchStreamOnlineCondition object.
    /// </summary> 
    public static TwitchStreamOnlineCondition? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchStreamOnlineCondition(data.Read("broadcaster_user_id", static v => v.AsString()));
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_stream_online.gd", "Condition");
        request.SetValue("broadcaster_user_id", BroadcasterUserId);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

    public static TwitchStreamOnlineCondition FromDictionary(Dictionary data)
    {
        return new TwitchStreamOnlineCondition(data["broadcaster_user_id"].AsString())
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
