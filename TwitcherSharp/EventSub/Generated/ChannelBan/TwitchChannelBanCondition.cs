using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelBan;

public partial class TwitchChannelBanCondition : Resource, ITwitcherSharpCondition<TwitchChannelBanCondition>
{
    public string Name => nameof(TwitchChannelBanCondition);

    /// <summary> 
    /// The broadcaster user ID for the channel you want to get ban notifications for.
    /// </summary>
    public string BroadcasterUserId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelBanCondition object.
    /// </summary> 
    public static TwitchChannelBanCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchChannelBanCondition
        {
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_ban.gd");
        var conditionClass = script.Get("Condition").AsGodotObject();
        var request = conditionClass.Call("new").AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        return request;
    }
}
