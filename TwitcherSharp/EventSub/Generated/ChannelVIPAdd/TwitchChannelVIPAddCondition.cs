using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelVIPAdd;

public partial class TwitchChannelVIPAddCondition : Resource, ITwitcherSharpEventSub<TwitchChannelVIPAddCondition>
{

	/// <summary> 
	/// The User ID of the broadcaster (channel) Maximum: 1
	/// </summary>
	public string BroadcasterUserId { get; set; }


    /// <summary> 
    /// Transforms the godot data into a TwitchChannelVIPAddCondition object.
    /// </summary> 
    public static TwitchChannelVIPAddCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchChannelVIPAddCondition
		{
			BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_v_i_p_add.gd");
		var conditionClass = script.Get("Condition").AsGodotObject();
		var request = conditionClass.Call("new").AsGodotObject();
		request.Set("broadcaster_user_id", BroadcasterUserId);
		return request;
	}

}
