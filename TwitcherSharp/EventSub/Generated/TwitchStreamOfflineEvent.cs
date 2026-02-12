using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchStreamOfflineEvent : Resource, ITwitcherSharpEventSub<TwitchStreamOfflineEvent>
{

	/// <summary> 
	/// The broadcaster’s user id.
	/// </summary>
	public string BroadcasterUserId { get; set; }

	/// <summary> 
	/// The broadcaster’s user login.
	/// </summary>
	public string BroadcasterUserLogin { get; set; }

	/// <summary> 
	/// The broadcaster’s user display name.
	/// </summary>
	public string BroadcasterUserName { get; set; }

	public static TwitchStreamOfflineEvent FromData(Dictionary data)
	{
	    return new TwitchStreamOfflineEvent
	    {
			BroadcasterUserId = data["broadcaster_user_id"].AsString(),
			BroadcasterUserLogin = data["broadcaster_user_login"].AsString(),
			BroadcasterUserName = data["broadcaster_user_name"].AsString(),
		};
	}

}
