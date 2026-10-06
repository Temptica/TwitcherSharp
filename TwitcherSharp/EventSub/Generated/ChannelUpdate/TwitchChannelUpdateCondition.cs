using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelUpdate;

public partial class TwitchChannelUpdateCondition(string broadcasterUserId) : RefCounted, ITwitcherSharpCondition<TwitchChannelUpdateCondition>
{
    private Variant _data;
    
    public string Name => nameof(TwitchChannelUpdateCondition);

    /// <summary> 
    /// The broadcaster user ID for the channel you want to get updates for.
    /// </summary>
    public string BroadcasterUserId { get; set; } = broadcasterUserId;

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelUpdateCondition object.
    /// </summary> 
    public static TwitchChannelUpdateCondition? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelUpdateCondition(data.Read("broadcaster_user_id", static v => v.AsString()));
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_update.gd", "Condition");
        request.SetValue("broadcaster_user_id", BroadcasterUserId);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

    public static TwitchChannelUpdateCondition FromDictionary(Dictionary data)
    {
        return new TwitchChannelUpdateCondition(data["broadcaster_user_id"].AsString())
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
