using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.AutomodMessageHold;

public partial class TwitchAutomodMessageHoldCondition : RefCounted, ITwitcherSharpCondition<TwitchAutomodMessageHoldCondition>
{
    public string Name => nameof(TwitchAutomodMessageHoldCondition);

    /// <summary> 
    /// User ID of the broadcaster (channel).
    /// </summary>
    public string BroadcasterUserId { get; set; }

    /// <summary> 
    /// User ID of the moderator.
    /// </summary>
    public string ModeratorUserId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchAutomodMessageHoldCondition object.
    /// </summary> 
    public static TwitchAutomodMessageHoldCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchAutomodMessageHoldCondition
        {
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
            ModeratorUserId = data.Get("moderator_user_id").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_automod_message_hold.gd");
        var conditionClass = script.Get("Condition").AsGodotObject();
        var request = conditionClass.Call("new").AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        request.Set("moderator_user_id", ModeratorUserId);
        return request;
    }

    public static TwitchAutomodMessageHoldCondition FromDictionary(Dictionary data)
    {
        return new TwitchAutomodMessageHoldCondition
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
