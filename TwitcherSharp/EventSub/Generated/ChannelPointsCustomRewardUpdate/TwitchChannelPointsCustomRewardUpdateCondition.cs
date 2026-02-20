using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelPointsCustomRewardUpdate;

public partial class TwitchChannelPointsCustomRewardUpdateCondition : Resource, ITwitcherSharpCondition<TwitchChannelPointsCustomRewardUpdateCondition>
{
	public string Name => nameof(TwitchChannelPointsCustomRewardUpdateCondition);

	/// <summary> 
	/// The broadcaster user ID for the channel you want to receive channel points custom reward update notifications for.
	/// </summary>
	public string BroadcasterUserId { get; set; }

	/// <summary> 
	/// Optional. Specify a reward id to only receive notifications for a specific reward.
	/// </summary>
	public string RewardId { get; set; }


    /// <summary> 
    /// Transforms the godot data into a TwitchChannelPointsCustomRewardUpdateCondition object.
    /// </summary> 
    public static TwitchChannelPointsCustomRewardUpdateCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchChannelPointsCustomRewardUpdateCondition
		{
			BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
			RewardId = data.Get("reward_id").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_points_custom_reward_update.gd");
		var conditionClass = script.Get("Condition").AsGodotObject();
		var request = conditionClass.Call("new").AsGodotObject();
		request.Set("broadcaster_user_id", BroadcasterUserId);
		request.Set("reward_id", RewardId);
		return request;
	}

}
