using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelModeratorAdd;

public partial class TwitchChannelModeratorAddCondition : Resource, ITwitcherSharpEventSub<TwitchChannelModeratorAddCondition>
{

	/// <summary> 
	/// The broadcaster user ID for the channel you want to get moderator addition notifications for.
	/// </summary>
	public string BroadcasterUserId { get; set; }


    /// <summary> 
    /// Transforms the godot data into a TwitchChannelModeratorAddCondition object.
    /// </summary> 
    public static TwitchChannelModeratorAddCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchChannelModeratorAddCondition
		{
			BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderator_add.gd");
		var conditionClass = script.Get("Condition").AsGodotObject();
		var request = conditionClass.Call("new").AsGodotObject();
		request.Set("broadcaster_user_id", BroadcasterUserId);
		return request;
	}

}
