using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelFollow;

public partial class TwitchChannelFollowCondition : Resource, ITwitcherSharpEventSub<TwitchChannelFollowCondition>
{

	/// <summary> 
	/// The broadcaster user ID for the channel you want to get follow notifications for.
	/// </summary>
	public string BroadcasterUserId { get; set; }

	/// <summary> 
	/// The ID of the moderator of the channel you want to get follow notifications for. If you have authorization from the broadcaster rather than a moderator, specify the broadcaster’s user ID here.
	/// </summary>
	public string ModeratorUserId { get; set; }


    /// <summary> 
    /// Transforms the godot data into a TwitchChannelFollowCondition object.
    /// </summary> 
    public static TwitchChannelFollowCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchChannelFollowCondition
		{
			BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
			ModeratorUserId = data.Get("moderator_user_id").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_follow.gd");
		var conditionClass = script.Get("Condition").AsGodotObject();
		var request = conditionClass.Call("new").AsGodotObject();
		request.Set("broadcaster_user_id", BroadcasterUserId);
		request.Set("moderator_user_id", ModeratorUserId);
		return request;
	}

}
