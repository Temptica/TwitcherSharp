using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelPointsAutomaticRewardRedemptionAdd;

public partial class TwitchChannelPointsAutomaticRewardRedemptionAddV2Condition : Resource, ITwitcherSharpEventSub<TwitchChannelPointsAutomaticRewardRedemptionAddV2Condition>
{

	/// <summary> 
	/// The broadcaster user ID for the channel you want to receive channel points reward add notifications for.
	/// </summary>
	public string BroadcasterUserId { get; set; }


    /// <summary> 
    /// Transforms the godot data into a TwitchChannelPointsAutomaticRewardRedemptionAddV2Condition object.
    /// </summary> 
    public static TwitchChannelPointsAutomaticRewardRedemptionAddV2Condition FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchChannelPointsAutomaticRewardRedemptionAddV2Condition
		{
			BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_points_automatic_reward_redemption_add.gd");
		var conditionV2Class = script.Get("ConditionV2").AsGodotObject();
		var request = conditionV2Class.Call("new").AsGodotObject();
		request.Set("broadcaster_user_id", BroadcasterUserId);
		return request;
	}

}
