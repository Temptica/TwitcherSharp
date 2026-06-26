using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelModeratorRemove;

public partial class TwitchChannelModeratorRemoveCondition(string broadcasterUserId) : RefCounted, ITwitcherSharpCondition<TwitchChannelModeratorRemoveCondition>
{
    private GodotObject _data;
    
    public string Name => nameof(TwitchChannelModeratorRemoveCondition);

    /// <summary> 
    /// The broadcaster user ID for the channel you want to get moderator removal notifications for.
    /// </summary>
    public string BroadcasterUserId { get; set; } = broadcasterUserId;

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelModeratorRemoveCondition object.
    /// </summary> 
    public static TwitchChannelModeratorRemoveCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelModeratorRemoveCondition(data.Get("broadcaster_user_id").AsString());
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderator_remove.gd");
        var conditionClass = script.Get("Condition").As<GDScript>();
        var request = conditionClass.New().AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        return request;
    }

    public static TwitchChannelModeratorRemoveCondition FromDictionary(Dictionary data)
    {
        return new TwitchChannelModeratorRemoveCondition(data["broadcaster_user_id"].AsString())
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
