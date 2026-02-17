using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelPointsCustomRewardAdd;

public partial class TwitchChannelPointsCustomRewardAddCondition : Resource, ITwitcherSharpEventSub<TwitchChannelPointsCustomRewardAddCondition>
{

	/// <summary> 
	/// The broadcaster user ID for the channel you want to receive channel points custom reward add notifications for.
	/// </summary>
	public string BroadcasterUserId { get; set; }


    /// <summary> 
    /// Transforms the godot data into a TwitchChannelPointsCustomRewardAddCondition object.
    /// </summary> 
    public static TwitchChannelPointsCustomRewardAddCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchChannelPointsCustomRewardAddCondition
		{
			BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_points_custom_reward_add.gd");
		var conditionClass = script.Get("Condition").AsGodotObject();
		var request = conditionClass.Call("new").AsGodotObject();
		request.Set("broadcaster_user_id", BroadcasterUserId);
		return request;
	}

}
