using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelWarningSend;

public partial class TwitchChannelWarningSendCondition : Resource, ITwitcherSharpEventSub<TwitchChannelWarningSendCondition>
{

	/// <summary> 
	/// The User ID of the broadcaster.
	/// </summary>
	public string BroadcasterUserId { get; set; }

	/// <summary> 
	/// The User ID of the moderator.
	/// </summary>
	public string ModeratorUserId { get; set; }


    /// <summary> 
    /// Transforms the godot data into a TwitchChannelWarningSendCondition object.
    /// </summary> 
    public static TwitchChannelWarningSendCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchChannelWarningSendCondition
		{
			BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
			ModeratorUserId = data.Get("moderator_user_id").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_warning_send.gd");
		var conditionClass = script.Get("Condition").AsGodotObject();
		var request = conditionClass.Call("new").AsGodotObject();
		request.Set("broadcaster_user_id", BroadcasterUserId);
		request.Set("moderator_user_id", ModeratorUserId);
		return request;
	}

}
