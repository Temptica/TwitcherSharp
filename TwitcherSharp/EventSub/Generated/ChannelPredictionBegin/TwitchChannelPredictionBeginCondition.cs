using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelPredictionBegin;

public partial class TwitchChannelPredictionBeginCondition(string broadcasterUserId) : RefCounted, ITwitcherSharpCondition<TwitchChannelPredictionBeginCondition>
{
    private Variant _data;
    
    public string Name => nameof(TwitchChannelPredictionBeginCondition);

    /// <summary> 
    /// The broadcaster user ID of the channel for which “prediction begin” notifications will be received.
    /// </summary>
    public string BroadcasterUserId { get; set; } = broadcasterUserId;

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelPredictionBeginCondition object.
    /// </summary> 
    public static TwitchChannelPredictionBeginCondition? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelPredictionBeginCondition(data.Read("broadcaster_user_id", static v => v.AsString()));
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_prediction_begin.gd", "Condition");
        request.SetValue("broadcaster_user_id", BroadcasterUserId);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

    public static TwitchChannelPredictionBeginCondition FromDictionary(Dictionary data)
    {
        return new TwitchChannelPredictionBeginCondition(data["broadcaster_user_id"].AsString())
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
