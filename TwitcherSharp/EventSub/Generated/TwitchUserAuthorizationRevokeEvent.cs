using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchUserAuthorizationRevokeEvent : Resource, ITwitcherSharpEventSub<TwitchUserAuthorizationRevokeEvent>
{

	/// <summary> 
	/// The client_id of the application with revoked user access.
	/// </summary>
	public string ClientId { get; set; }

	/// <summary> 
	/// The user id for the user who has revoked authorization for your client id.
	/// </summary>
	public string UserId { get; set; }

	/// <summary> 
	/// The user login for the user who has revoked authorization for your client id. This is null if the user no longer exists.
	/// </summary>
	public string UserLogin { get; set; }

	/// <summary> 
	/// The user display name for the user who has revoked authorization for your client id. This is null if the user no longer exists.
	/// </summary>
	public string UserName { get; set; }

	public static TwitchUserAuthorizationRevokeEvent FromData(Dictionary data)
	{
	    return new TwitchUserAuthorizationRevokeEvent
	    {
			ClientId = data["client_id"].AsString(),
			UserId = data["user_id"].AsString(),
			UserLogin = data["user_login"].AsString(),
			UserName = data["user_name"].AsString(),
		};
	}

}
