using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelAdBreakBegin;

public partial class TwitchChannelAdBreakBeginCondition(string broadcasterUserId) : RefCounted, ITwitcherSharpCondition<TwitchChannelAdBreakBeginCondition>
{
    private Variant _data;
    
    public string Name => nameof(TwitchChannelAdBreakBeginCondition);

    /// <summary> 
    /// The ID of the broadcaster that you want to get Channel Ad Break begin notifications for. Maximum: 1
    /// </summary>
    public string BroadcasterUserId { get; set; } = broadcasterUserId;

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelAdBreakBeginCondition object.
    /// </summary> 
    public static TwitchChannelAdBreakBeginCondition? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelAdBreakBeginCondition(data.Read("broadcaster_user_id", static v => v.AsString()));
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_ad_break_begin.gd", "Condition");
        request.SetValue("broadcaster_user_id", BroadcasterUserId);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

    public static TwitchChannelAdBreakBeginCondition FromDictionary(Dictionary data)
    {
        return new TwitchChannelAdBreakBeginCondition(data["broadcaster_user_id"].AsString())
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
