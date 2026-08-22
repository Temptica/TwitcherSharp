using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelModeratorAdd;

public partial class TwitchChannelModeratorAddCondition(string broadcasterUserId) : RefCounted, ITwitcherSharpCondition<TwitchChannelModeratorAddCondition>
{
    private GodotObject? _data;
    
    public string Name => nameof(TwitchChannelModeratorAddCondition);

    /// <summary> 
    /// The broadcaster user ID for the channel you want to get moderator addition notifications for.
    /// </summary>
    public string BroadcasterUserId { get; set; } = broadcasterUserId;

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelModeratorAddCondition object.
    /// </summary> 
    public static TwitchChannelModeratorAddCondition? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelModeratorAddCondition(data.Get("broadcaster_user_id").AsString());
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderator_add.gd");
        var conditionClass = script.Get("Condition").As<GDScript>();
        var request = conditionClass.New().AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        return request;
    }

    public static TwitchChannelModeratorAddCondition FromDictionary(Dictionary data)
    {
        return new TwitchChannelModeratorAddCondition(data["broadcaster_user_id"].AsString())
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
