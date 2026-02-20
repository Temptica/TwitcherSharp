using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelSubscriptionEnd;

public partial class TwitchChannelSubscriptionEndCondition : Resource, ITwitcherSharpCondition<TwitchChannelSubscriptionEndCondition>
{
	public string Name => nameof(TwitchChannelSubscriptionEndCondition);

	/// <summary> 
	/// The broadcaster user ID for the channel you want to get subscription end notifications for.
	/// </summary>
	public string BroadcasterUserId { get; set; }


    /// <summary> 
    /// Transforms the godot data into a TwitchChannelSubscriptionEndCondition object.
    /// </summary> 
    public static TwitchChannelSubscriptionEndCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchChannelSubscriptionEndCondition
		{
			BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_subscription_end.gd");
		var conditionClass = script.Get("Condition").AsGodotObject();
		var request = conditionClass.Call("new").AsGodotObject();
		request.Set("broadcaster_user_id", BroadcasterUserId);
		return request;
	}

}
