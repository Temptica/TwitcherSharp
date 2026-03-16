using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelGuestStarSettingsUpdate;

public partial class TwitchChannelGuestStarSettingsUpdateCondition : RefCounted, ITwitcherSharpCondition<TwitchChannelGuestStarSettingsUpdateCondition>
{
    public string Name => nameof(TwitchChannelGuestStarSettingsUpdateCondition);

    /// <summary> 
    /// The broadcaster user ID of the channel hosting the Guest Star Session
    /// </summary>
    public string BroadcasterUserId { get; set; }

    /// <summary> 
    /// The user ID of the moderator or broadcaster of the specified channel.
    /// </summary>
    public string ModeratorUserId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelGuestStarSettingsUpdateCondition object.
    /// </summary> 
    public static TwitchChannelGuestStarSettingsUpdateCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchChannelGuestStarSettingsUpdateCondition
        {
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
            ModeratorUserId = data.Get("moderator_user_id").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_guest_star_settings_update.gd");
        var conditionClass = script.Get("Condition").AsGodotObject();
        var request = conditionClass.Call("new").AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        request.Set("moderator_user_id", ModeratorUserId);
        return request;
    }
}
