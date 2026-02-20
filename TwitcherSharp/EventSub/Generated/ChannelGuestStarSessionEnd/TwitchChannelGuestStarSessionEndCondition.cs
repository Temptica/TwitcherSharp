using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelGuestStarSessionEnd;

public partial class TwitchChannelGuestStarSessionEndCondition : Resource, ITwitcherSharpCondition<TwitchChannelGuestStarSessionEndCondition>
{
	public string Name => nameof(TwitchChannelGuestStarSessionEndCondition);

	/// <summary> 
	/// The broadcaster user ID of the channel hosting the Guest Star Session
	/// </summary>
	public string BroadcasterUserId { get; set; }

	/// <summary> 
	/// The user ID of the moderator or broadcaster of the specified channel.
	/// </summary>
	public string ModeratorUserId { get; set; }


    /// <summary> 
    /// Transforms the godot data into a TwitchChannelGuestStarSessionEndCondition object.
    /// </summary> 
    public static TwitchChannelGuestStarSessionEndCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchChannelGuestStarSessionEndCondition
		{
			BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
			ModeratorUserId = data.Get("moderator_user_id").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_guest_star_session_end.gd");
		var conditionClass = script.Get("Condition").AsGodotObject();
		var request = conditionClass.Call("new").AsGodotObject();
		request.Set("broadcaster_user_id", BroadcasterUserId);
		request.Set("moderator_user_id", ModeratorUserId);
		return request;
	}

}
