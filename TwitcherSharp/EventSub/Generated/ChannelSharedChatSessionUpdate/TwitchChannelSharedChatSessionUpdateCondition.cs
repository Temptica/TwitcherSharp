using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelSharedChatSessionUpdate;

public partial class TwitchChannelSharedChatSessionUpdateCondition(string broadcasterUserId) : RefCounted, ITwitcherSharpCondition<TwitchChannelSharedChatSessionUpdateCondition>
{
    private Variant _data;
    
    public string Name => nameof(TwitchChannelSharedChatSessionUpdateCondition);

    /// <summary> 
    /// The User ID of the channel to receive shared chat session update events for.
    /// </summary>
    public string BroadcasterUserId { get; set; } = broadcasterUserId;

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelSharedChatSessionUpdateCondition object.
    /// </summary> 
    public static TwitchChannelSharedChatSessionUpdateCondition? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelSharedChatSessionUpdateCondition(data.Read("broadcaster_user_id", static v => v.AsString()));
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_shared_chat_session_update.gd", "Condition");
        request.SetValue("broadcaster_user_id", BroadcasterUserId);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

    public static TwitchChannelSharedChatSessionUpdateCondition FromDictionary(Dictionary data)
    {
        return new TwitchChannelSharedChatSessionUpdateCondition(data["broadcaster_user_id"].AsString())
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
