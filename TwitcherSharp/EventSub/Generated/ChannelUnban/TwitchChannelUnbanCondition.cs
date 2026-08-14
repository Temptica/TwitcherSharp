using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelUnban;

public partial class TwitchChannelUnbanCondition(string broadcasterUserId) : RefCounted, ITwitcherSharpCondition<TwitchChannelUnbanCondition>
{
    private GodotObject? _data;
    
    public string Name => nameof(TwitchChannelUnbanCondition);

    /// <summary> 
    /// The broadcaster user ID for the channel you want to get unban notifications for.
    /// </summary>
    public string BroadcasterUserId { get; set; } = broadcasterUserId;

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelUnbanCondition object.
    /// </summary> 
    public static TwitchChannelUnbanCondition? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelUnbanCondition(data.Get("broadcaster_user_id").AsString());
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_unban.gd");
        var conditionClass = script.Get("Condition").As<GDScript>();
        var request = conditionClass.New().AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        return request;
    }

    public static TwitchChannelUnbanCondition FromDictionary(Dictionary data)
    {
        return new TwitchChannelUnbanCondition(data["broadcaster_user_id"].AsString())
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
