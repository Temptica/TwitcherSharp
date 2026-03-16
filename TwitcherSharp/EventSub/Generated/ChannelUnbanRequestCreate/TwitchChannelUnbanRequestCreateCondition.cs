using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelUnbanRequestCreate;

public partial class TwitchChannelUnbanRequestCreateCondition : RefCounted, ITwitcherSharpCondition<TwitchChannelUnbanRequestCreateCondition>
{
    public string Name => nameof(TwitchChannelUnbanRequestCreateCondition);

    /// <summary> 
    /// The ID of the user that has permission to moderate the broadcaster’s channel and has granted your app permission to subscribe to this subscription type.
    /// </summary>
    public string ModeratorUserId { get; set; }

    /// <summary> 
    /// The ID of the broadcaster you want to get chat unban request notifications for. Maximum: 1.
    /// </summary>
    public string BroadcasterUserId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelUnbanRequestCreateCondition object.
    /// </summary> 
    public static TwitchChannelUnbanRequestCreateCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchChannelUnbanRequestCreateCondition
        {
            ModeratorUserId = data.Get("moderator_user_id").AsString(),
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_unban_request_create.gd");
        var conditionClass = script.Get("Condition").AsGodotObject();
        var request = conditionClass.Call("new").AsGodotObject();
        request.Set("moderator_user_id", ModeratorUserId);
        request.Set("broadcaster_user_id", BroadcasterUserId);
        return request;
    }
}
