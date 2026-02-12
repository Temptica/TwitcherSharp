using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchUserAuthorizationGrantEvent : Resource, ITwitcherSharpEventSub<TwitchUserAuthorizationGrantEvent>
{

	/// <summary> 
	/// The client_id of the application that was granted user access.
	/// </summary>
	public string ClientId { get; set; }

	/// <summary> 
	/// The user id for the user who has granted authorization for your client id.
	/// </summary>
	public string UserId { get; set; }

	/// <summary> 
	/// The user login for the user who has granted authorization for your client id.
	/// </summary>
	public string UserLogin { get; set; }

	/// <summary> 
	/// The user display name for the user who has granted authorization for your client id.
	/// </summary>
	public string UserName { get; set; }

	public static TwitchUserAuthorizationGrantEvent FromData(Dictionary data)
	{
	    return new TwitchUserAuthorizationGrantEvent
	    {
			ClientId = data["client_id"].AsString(),
			UserId = data["user_id"].AsString(),
			UserLogin = data["user_login"].AsString(),
			UserName = data["user_name"].AsString(),
		};
	}

}
