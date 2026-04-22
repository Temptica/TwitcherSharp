using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelModeratorAdd;

public partial class TwitchChannelModeratorAddCondition : RefCounted, ITwitcherSharpCondition<TwitchChannelModeratorAddCondition>
{
    public string Name => nameof(TwitchChannelModeratorAddCondition);

    /// <summary> 
    /// The broadcaster user ID for the channel you want to get moderator addition notifications for.
    /// </summary>
    public string BroadcasterUserId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelModeratorAddCondition object.
    /// </summary> 
    public static TwitchChannelModeratorAddCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchChannelModeratorAddCondition
        {
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
        };
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
        return new TwitchChannelModeratorAddCondition
        {
            BroadcasterUserId = data["broadcaster_user_id"].AsString(),
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
