using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelModeratorRemove;

public partial class TwitchChannelModeratorRemoveCondition : RefCounted, ITwitcherSharpCondition<TwitchChannelModeratorRemoveCondition>
{
    public string Name => nameof(TwitchChannelModeratorRemoveCondition);

    /// <summary> 
    /// The broadcaster user ID for the channel you want to get moderator removal notifications for.
    /// </summary>
    public string BroadcasterUserId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelModeratorRemoveCondition object.
    /// </summary> 
    public static TwitchChannelModeratorRemoveCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchChannelModeratorRemoveCondition
        {
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderator_remove.gd");
        var conditionClass = script.Get("Condition").AsGodotObject();
        var request = conditionClass.Call("new").AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        return request;
    }
}
