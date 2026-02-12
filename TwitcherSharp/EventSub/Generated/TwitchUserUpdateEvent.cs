using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchUserUpdateEvent : Resource, ITwitcherSharpEventSub<TwitchUserUpdateEvent>
{

	/// <summary> 
	/// The user’s user id.
	/// </summary>
	public string UserId { get; set; }

	/// <summary> 
	/// The user’s user login.
	/// </summary>
	public string UserLogin { get; set; }

	/// <summary> 
	/// The user’s user display name.
	/// </summary>
	public string UserName { get; set; }

	/// <summary> 
	/// The user’s email address. The event includes the user’s email address only if the app used to request this event type includes the user:read:email scope for the user; otherwise, the field is set to an empty string. See Create EventSub Subscription.
	/// </summary>
	public string Email { get; set; }

	/// <summary> 
	/// A Boolean value that determines whether Twitch has verified the user’s email address. Is true if Twitch has verified the email address; otherwise, false.NOTE: Ignore this field if the email field contains an empty string.
	/// </summary>
	public bool EmailVerified { get; set; }

	/// <summary> 
	/// The user’s description.
	/// </summary>
	public string Description { get; set; }

	public static TwitchUserUpdateEvent FromData(Dictionary data)
	{
	    return new TwitchUserUpdateEvent
	    {
			UserId = data["user_id"].AsString(),
			UserLogin = data["user_login"].AsString(),
			UserName = data["user_name"].AsString(),
			Email = data["email"].AsString(),
			EmailVerified = data["email_verified"].AsBool(),
			Description = data["description"].AsString(),
		};
	}

}
