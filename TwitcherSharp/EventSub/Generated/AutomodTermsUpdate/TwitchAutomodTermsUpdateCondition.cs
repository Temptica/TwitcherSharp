using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.AutomodTermsUpdate;

public partial class TwitchAutomodTermsUpdateCondition : Resource, ITwitcherSharpEventSub<TwitchAutomodTermsUpdateCondition>
{

	/// <summary> 
	/// User ID of the broadcaster (channel). Maximum:1.
	/// </summary>
	public string BroadcasterUserId { get; set; }

	/// <summary> 
	/// User ID of the moderator creating the subscription. Maximum:1
	/// </summary>
	public string ModeratorUserId { get; set; }


    /// <summary> 
    /// Transforms the godot data into a TwitchAutomodTermsUpdateCondition object.
    /// </summary> 
    public static TwitchAutomodTermsUpdateCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchAutomodTermsUpdateCondition
		{
			BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
			ModeratorUserId = data.Get("moderator_user_id").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_automod_terms_update.gd");
		var conditionClass = script.Get("Condition").AsGodotObject();
		var request = conditionClass.Call("new").AsGodotObject();
		request.Set("broadcaster_user_id", BroadcasterUserId);
		request.Set("moderator_user_id", ModeratorUserId);
		return request;
	}

}
