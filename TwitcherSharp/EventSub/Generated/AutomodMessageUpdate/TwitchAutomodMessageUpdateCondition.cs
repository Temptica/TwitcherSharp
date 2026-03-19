using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.AutomodMessageUpdate;

public partial class TwitchAutomodMessageUpdateCondition : RefCounted, ITwitcherSharpCondition<TwitchAutomodMessageUpdateCondition>
{
    public string Name => nameof(TwitchAutomodMessageUpdateCondition);

    /// <summary> 
    /// User ID of the broadcaster (channel). Maximum:1.
    /// </summary>
    public string BroadcasterUserId { get; set; }

    /// <summary> 
    /// User ID of the moderator.
    /// </summary>
    public string ModeratorUserId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchAutomodMessageUpdateCondition object.
    /// </summary> 
    public static TwitchAutomodMessageUpdateCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchAutomodMessageUpdateCondition
        {
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
            ModeratorUserId = data.Get("moderator_user_id").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_automod_message_update.gd");
        var conditionClass = script.Get("Condition").AsGodotObject();
        var request = conditionClass.Call("new").AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        request.Set("moderator_user_id", ModeratorUserId);
        return request;
    }

    public static TwitchAutomodMessageUpdateCondition FromDictionary(Dictionary data)
    {
        return new TwitchAutomodMessageUpdateCondition
        {
            BroadcasterUserId = data["broadcaster_user_id"].AsString(),
            ModeratorUserId = data["moderator_user_id"].AsString(),
        };
    }

    public Dictionary ToDictionary()
    {
        return new Dictionary
        {
            {"broadcaster_user_id", BroadcasterUserId},
            {"moderator_user_id", ModeratorUserId},
        };
    }
}
