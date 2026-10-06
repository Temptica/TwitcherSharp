using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelSharedChatSessionBegin;

public partial class TwitchChannelSharedChatSessionBeginCondition(string broadcasterUserId) : RefCounted, ITwitcherSharpCondition<TwitchChannelSharedChatSessionBeginCondition>
{
    private Variant _data;
    
    public string Name => nameof(TwitchChannelSharedChatSessionBeginCondition);

    /// <summary> 
    /// The User ID of the channel to receive shared chat session begin events for.
    /// </summary>
    public string BroadcasterUserId { get; set; } = broadcasterUserId;

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelSharedChatSessionBeginCondition object.
    /// </summary> 
    public static TwitchChannelSharedChatSessionBeginCondition? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelSharedChatSessionBeginCondition(data.Read("broadcaster_user_id", static v => v.AsString()));
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_shared_chat_session_begin.gd", "Condition");
        request.SetValue("broadcaster_user_id", BroadcasterUserId);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

    public static TwitchChannelSharedChatSessionBeginCondition FromDictionary(Dictionary data)
    {
        return new TwitchChannelSharedChatSessionBeginCondition(data["broadcaster_user_id"].AsString())
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
