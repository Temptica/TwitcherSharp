using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelUpdate;

public partial class TwitchChannelUpdateCondition(string broadcasterUserId) : RefCounted, ITwitcherSharpCondition<TwitchChannelUpdateCondition>
{
    private GodotObject? _data;
    
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
        var instance = new TwitchChannelUpdateCondition(data.Get("broadcaster_user_id").AsString());
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_update.gd");
        var conditionClass = script.Get("Condition").As<GDScript>();
        var request = conditionClass.New().AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        return request;
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
