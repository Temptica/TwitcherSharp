using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelAdBreakBegin;

public partial class TwitchChannelAdBreakBeginCondition(string broadcasterUserId) : RefCounted, ITwitcherSharpCondition<TwitchChannelAdBreakBeginCondition>
{
    private GodotObject _data;
    
    public string Name => nameof(TwitchChannelAdBreakBeginCondition);

    /// <summary> 
    /// The ID of the broadcaster that you want to get Channel Ad Break begin notifications for. Maximum: 1
    /// </summary>
    public string BroadcasterUserId { get; set; } = broadcasterUserId;

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelAdBreakBeginCondition object.
    /// </summary> 
    public static TwitchChannelAdBreakBeginCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelAdBreakBeginCondition(data.Get("broadcaster_user_id").AsString());
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_ad_break_begin.gd");
        var conditionClass = script.Get("Condition").As<GDScript>();
        var request = conditionClass.New().AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        return request;
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
