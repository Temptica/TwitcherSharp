using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelPollProgress;

public partial class TwitchChannelPollProgressCondition(string broadcasterUserId) : RefCounted, ITwitcherSharpCondition<TwitchChannelPollProgressCondition>
{
    private GodotObject? _data;
    
    public string Name => nameof(TwitchChannelPollProgressCondition);

    /// <summary> 
    /// The broadcaster user ID of the channel for which “poll progress” notifications will be received.
    /// </summary>
    public string BroadcasterUserId { get; set; } = broadcasterUserId;

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelPollProgressCondition object.
    /// </summary> 
    public static TwitchChannelPollProgressCondition? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelPollProgressCondition(data.Get("broadcaster_user_id").AsString());
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_poll_progress.gd");
        var conditionClass = script.Get("Condition").As<GDScript>();
        var request = conditionClass.New().AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        return request;
    }

    public static TwitchChannelPollProgressCondition FromDictionary(Dictionary data)
    {
        return new TwitchChannelPollProgressCondition(data["broadcaster_user_id"].AsString())
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
