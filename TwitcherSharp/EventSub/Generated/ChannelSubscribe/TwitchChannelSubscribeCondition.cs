using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelSubscribe;

public partial class TwitchChannelSubscribeCondition(string broadcasterUserId) : RefCounted, ITwitcherSharpCondition<TwitchChannelSubscribeCondition>
{
    private GodotObject _data;
    
    public string Name => nameof(TwitchChannelSubscribeCondition);

    /// <summary> 
    /// The broadcaster user ID for the channel you want to get subscribe notifications for.
    /// </summary>
    public string BroadcasterUserId { get; set; } = broadcasterUserId;

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelSubscribeCondition object.
    /// </summary> 
    public static TwitchChannelSubscribeCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelSubscribeCondition(data.Get("broadcaster_user_id").AsString());
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_subscribe.gd");
        var conditionClass = script.Get("Condition").As<GDScript>();
        var request = conditionClass.New().AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        return request;
    }

    public static TwitchChannelSubscribeCondition FromDictionary(Dictionary data)
    {
        return new TwitchChannelSubscribeCondition(data["broadcaster_user_id"].AsString())
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
