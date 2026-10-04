using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelRaid;

public partial class TwitchChannelRaidCondition() : RefCounted, ITwitcherSharpCondition<TwitchChannelRaidCondition>
{
    private Variant _data;
    
    public string Name => nameof(TwitchChannelRaidCondition);

    /// <summary> 
    /// The broadcaster user ID that created the channel raid you want to get notifications for. Use this parameter if you want to know when a specific broadcaster raids another broadcaster. The channel raid condition must include either from_broadcaster_user_id or to_broadcaster_user_id.
    /// </summary>
    public string? FromBroadcasterUserId { get; set; }

    /// <summary> 
    /// The broadcaster user ID that received the channel raid you want to get notifications for. Use this parameter if you want to know when a specific broadcaster is raided by another broadcaster. The channel raid condition must include either from_broadcaster_user_id or to_broadcaster_user_id.
    /// </summary>
    public string? ToBroadcasterUserId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelRaidCondition object.
    /// </summary> 
    public static TwitchChannelRaidCondition? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelRaidCondition
        {
            FromBroadcasterUserId = data.Read("from_broadcaster_user_id", static v => v.AsString()),
            ToBroadcasterUserId = data.Read("to_broadcaster_user_id", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_raid.gd", "Condition");
        if(FromBroadcasterUserId != null) request.SetValue("from_broadcaster_user_id", FromBroadcasterUserId);
        if(ToBroadcasterUserId != null) request.SetValue("to_broadcaster_user_id", ToBroadcasterUserId);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

    public static TwitchChannelRaidCondition FromDictionary(Dictionary data)
    {
        return new TwitchChannelRaidCondition
        {
            FromBroadcasterUserId = data["from_broadcaster_user_id"].AsString(),
            ToBroadcasterUserId = data["to_broadcaster_user_id"].AsString(),
        };
    }

    public Dictionary ToDictionary()
    {
        return new Dictionary
        {
            {"from_broadcaster_user_id", FromBroadcasterUserId!},
            {"to_broadcaster_user_id", ToBroadcasterUserId!},
        };
    }
}
