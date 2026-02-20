using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelAdBreakBegin;

public partial class TwitchChannelAdBreakBeginCondition : Resource, ITwitcherSharpCondition<TwitchChannelAdBreakBeginCondition>
{
    public string Name => nameof(TwitchChannelAdBreakBeginCondition);

    /// <summary> 
    /// The ID of the broadcaster that you want to get Channel Ad Break begin notifications for. Maximum: 1
    /// </summary>
    public string BroadcasterId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelAdBreakBeginCondition object.
    /// </summary> 
    public static TwitchChannelAdBreakBeginCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchChannelAdBreakBeginCondition
        {
            BroadcasterId = data.Get("broadcaster_id").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_ad_break_begin.gd");
        var conditionClass = script.Get("Condition").AsGodotObject();
        var request = conditionClass.Call("new").AsGodotObject();
        request.Set("broadcaster_id", BroadcasterId);
        return request;
    }
}
