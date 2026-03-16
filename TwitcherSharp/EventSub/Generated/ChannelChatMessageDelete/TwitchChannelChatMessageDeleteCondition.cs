using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelChatMessageDelete;

public partial class TwitchChannelChatMessageDeleteCondition : RefCounted, ITwitcherSharpCondition<TwitchChannelChatMessageDeleteCondition>
{
    public string Name => nameof(TwitchChannelChatMessageDeleteCondition);

    /// <summary> 
    /// User ID of the channel to receive chat message delete events for.
    /// </summary>
    public string BroadcasterUserId { get; set; }

    /// <summary> 
    /// The user ID to read chat as.
    /// </summary>
    public string UserId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelChatMessageDeleteCondition object.
    /// </summary> 
    public static TwitchChannelChatMessageDeleteCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchChannelChatMessageDeleteCondition
        {
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
            UserId = data.Get("user_id").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_message_delete.gd");
        var conditionClass = script.Get("Condition").AsGodotObject();
        var request = conditionClass.Call("new").AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        request.Set("user_id", UserId);
        return request;
    }
}
