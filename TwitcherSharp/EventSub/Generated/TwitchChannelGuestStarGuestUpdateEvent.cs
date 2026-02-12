using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchChannelGuestStarGuestUpdateEvent : Resource, ITwitcherSharpEventSub<TwitchChannelGuestStarGuestUpdateEvent>
{

	/// <summary> 
	/// The non-host broadcaster user ID.
	/// </summary>
	public string BroadcasterUserId { get; set; }

	/// <summary> 
	/// The non-host broadcaster display name.
	/// </summary>
	public string BroadcasterUserName { get; set; }

	/// <summary> 
	/// The non-host broadcaster login.
	/// </summary>
	public string BroadcasterUserLogin { get; set; }

	/// <summary> 
	/// ID representing the unique session that was started.
	/// </summary>
	public string SessionId { get; set; }

	/// <summary> 
	/// The user ID of the moderator who updated the guest’s state (could be the host). null if the update was performed by the guest.
	/// </summary>
	public string ModeratorUserId { get; set; }

	/// <summary> 
	/// The moderator display name.null if the update was performed by the guest.
	/// </summary>
	public string ModeratorUserName { get; set; }

	/// <summary> 
	/// The moderator login. null if the update was performed by the guest.
	/// </summary>
	public string ModeratorUserLogin { get; set; }

	/// <summary> 
	/// The user ID of the guest who transitioned states in the session. null if the slot is now empty.
	/// </summary>
	public string GuestUserId { get; set; }

	/// <summary> 
	/// The guest display name. null if the slot is now empty.
	/// </summary>
	public string GuestUserName { get; set; }

	/// <summary> 
	/// The guest login. null if the slot is now empty.
	/// </summary>
	public string GuestUserLogin { get; set; }

	/// <summary> 
	/// The ID of the slot assignment the guest is assigned to. null if the guest is in the INVITED, REMOVED, READY, or ACCEPTED state.
	/// </summary>
	public string SlotId { get; set; }

	/// <summary> 
	/// The current state of the user after the update has taken place. null if the slot is now empty. Can otherwise be one of the following: invited — The guest has transitioned to the invite queue. This can take place when the guest was previously assigned a slot, but have been removed from the call and are sent back to the invite queue.accepted — The guest has accepted the invite and is currently in the process of setting up to join the session.ready — The guest has signaled they are ready and can be assigned a slot.backstage — The guest has been assigned a slot in the session, but is not currently seen live in the broadcasting software.live — The guest is now live in the host's broadcasting software.removed — The guest was removed from the call or queue.accepted — The guest has accepted the invite to the call.
	/// </summary>
	public string State { get; set; }

	/// <summary> 
	/// User ID of the host channel.
	/// </summary>
	public string HostUserId { get; set; }

	/// <summary> 
	/// The host display name.
	/// </summary>
	public string HostUserName { get; set; }

	/// <summary> 
	/// The host login.
	/// </summary>
	public string HostUserLogin { get; set; }

	/// <summary> 
	/// Flag that signals whether the host is allowing the slot’s video to be seen by participants within the session. null  if the guest is not slotted.
	/// </summary>
	public Bool HostVideoEnabled { get; set; }

	/// <summary> 
	/// Flag that signals whether the host is allowing the slot’s audio to be heard by participants within the session. null  if the guest is not slotted.
	/// </summary>
	public Bool HostAudioEnabled { get; set; }

	/// <summary> 
	/// Value between 0-100 that represents the slot’s audio level as heard by participants within the session. null  if the guest is not slotted.
	/// </summary>
	public int HostVolume { get; set; }

	public static TwitchChannelGuestStarGuestUpdateEvent FromData(Dictionary data)
	{
	    return new TwitchChannelGuestStarGuestUpdateEvent
	    {
			BroadcasterUserId = data["broadcaster_user_id"].AsString(),
			BroadcasterUserName = data["broadcaster_user_name"].AsString(),
			BroadcasterUserLogin = data["broadcaster_user_login"].AsString(),
			SessionId = data["session_id"].AsString(),
			ModeratorUserId = data["moderator_user_id"].AsString(),
			ModeratorUserName = data["moderator_user_name"].AsString(),
			ModeratorUserLogin = data["moderator_user_login"].AsString(),
			GuestUserId = data["guest_user_id"].AsString(),
			GuestUserName = data["guest_user_name"].AsString(),
			GuestUserLogin = data["guest_user_login"].AsString(),
			SlotId = data["slot_id"].AsString(),
			State = data["state"].AsString(),
			HostUserId = data["host_user_id"].AsString(),
			HostUserName = data["host_user_name"].AsString(),
			HostUserLogin = data["host_user_login"].AsString(),
			HostVideoEnabled = data["host_video_enabled"].As<Bool>(),
			HostAudioEnabled = data["host_audio_enabled"].As<Bool>(),
			HostVolume = data["host_volume"].AsInt32(),
		};
	}

}
