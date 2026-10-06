using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelChatUserMessageUpdate;

public partial class TwitchChannelChatUserMessageUpdateCondition(string broadcasterUserId, string userId) : RefCounted, ITwitcherSharpCondition<TwitchChannelChatUserMessageUpdateCondition>
{
    private Variant _data;
    
    public string Name => nameof(TwitchChannelChatUserMessageUpdateCondition);

    /// <summary> 
    /// User ID of the channel to receive chat message events for.
    /// </summary>
    public string BroadcasterUserId { get; set; } = broadcasterUserId;

    /// <summary> 
    /// The user ID to read chat as.
    /// </summary>
    public string UserId { get; set; } = userId;

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelChatUserMessageUpdateCondition object.
    /// </summary> 
    public static TwitchChannelChatUserMessageUpdateCondition? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelChatUserMessageUpdateCondition(data.Read("broadcaster_user_id", static v => v.AsString()), data.Read("user_id", static v => v.AsString()));
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_user_message_update.gd", "Condition");
        request.SetValue("broadcaster_user_id", BroadcasterUserId);
        request.SetValue("user_id", UserId);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

    public static TwitchChannelChatUserMessageUpdateCondition FromDictionary(Dictionary data)
    {
        return new TwitchChannelChatUserMessageUpdateCondition(data["broadcaster_user_id"].AsString(), data["user_id"].AsString())
        {
        };
    }

    public Dictionary ToDictionary()
    {
        return new Dictionary
        {
            {"broadcaster_user_id", BroadcasterUserId},
            {"user_id", UserId},
        };
    }
}
