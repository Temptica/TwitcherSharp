using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelBitsUse;

public partial class TwitchChannelBitsUseCondition : Resource, ITwitcherSharpCondition<TwitchChannelBitsUseCondition>
{
    public string Name => nameof(TwitchChannelBitsUseCondition);

    /// <summary> 
    /// The user ID of the channel broadcaster. Maximum: 1.
    /// </summary>
    public string BroadcasterUserId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelBitsUseCondition object.
    /// </summary> 
    public static TwitchChannelBitsUseCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchChannelBitsUseCondition
        {
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_bits_use.gd");
        var conditionClass = script.Get("Condition").AsGodotObject();
        var request = conditionClass.Call("new").AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        return request;
    }
}
