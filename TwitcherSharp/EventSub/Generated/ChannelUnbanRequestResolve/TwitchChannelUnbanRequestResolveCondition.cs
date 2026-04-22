using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelUnbanRequestResolve;

public partial class TwitchChannelUnbanRequestResolveCondition : RefCounted, ITwitcherSharpCondition<TwitchChannelUnbanRequestResolveCondition>
{
    public string Name => nameof(TwitchChannelUnbanRequestResolveCondition);

    /// <summary> 
    /// The ID of the user that has permission to moderate the broadcaster’s channel and has granted your app permission to subscribe to this subscription type.
    /// </summary>
    public string ModeratorUserId { get; set; }

    /// <summary> 
    /// The ID of the broadcaster you want to get unban request resolution notifications for. Maximum: 1.
    /// </summary>
    public string BroadcasterUserId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelUnbanRequestResolveCondition object.
    /// </summary> 
    public static TwitchChannelUnbanRequestResolveCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchChannelUnbanRequestResolveCondition
        {
            ModeratorUserId = data.Get("moderator_user_id").AsString(),
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_unban_request_resolve.gd");
        var conditionClass = script.Get("Condition").As<GDScript>();
        var request = conditionClass.New().AsGodotObject();
        request.Set("moderator_user_id", ModeratorUserId);
        request.Set("broadcaster_user_id", BroadcasterUserId);
        return request;
    }

    public static TwitchChannelUnbanRequestResolveCondition FromDictionary(Dictionary data)
    {
        return new TwitchChannelUnbanRequestResolveCondition
        {
            ModeratorUserId = data["moderator_user_id"].AsString(),
            BroadcasterUserId = data["broadcaster_user_id"].AsString(),
        };
    }

    public Dictionary ToDictionary()
    {
        return new Dictionary
        {
            {"moderator_user_id", ModeratorUserId},
            {"broadcaster_user_id", BroadcasterUserId},
        };
    }
}
