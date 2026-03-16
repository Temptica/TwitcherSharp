using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelCheer;

public partial class TwitchChannelCheerCondition : RefCounted, ITwitcherSharpCondition<TwitchChannelCheerCondition>
{
    public string Name => nameof(TwitchChannelCheerCondition);

    /// <summary> 
    /// The broadcaster user ID for the channel you want to get cheer notifications for.
    /// </summary>
    public string BroadcasterUserId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelCheerCondition object.
    /// </summary> 
    public static TwitchChannelCheerCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchChannelCheerCondition
        {
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_cheer.gd");
        var conditionClass = script.Get("Condition").AsGodotObject();
        var request = conditionClass.Call("new").AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        return request;
    }
}
