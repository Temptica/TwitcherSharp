using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchChannelGuestStarSettingsUpdateEvent : Resource, ITwitcherSharpEventSub<TwitchChannelGuestStarSettingsUpdateEvent>
{

	/// <summary> 
	/// User ID of the host channel.
	/// </summary>
	public string BroadcasterUserId { get; set; }

	/// <summary> 
	/// The broadcaster display name
	/// </summary>
	public string BroadcasterUserName { get; set; }

	/// <summary> 
	/// he broadcaster login.
	/// </summary>
	public string BroadcasterUserLogin { get; set; }

	/// <summary> 
	/// Flag determining if Guest Star moderators have access to control whether a guest is live once assigned to a slot.
	/// </summary>
	public Bool IsModeratorSendLiveEnabled { get; set; }

	/// <summary> 
	/// Number of slots the Guest Star call interface will allow the host to add to a call.
	/// </summary>
	public int SlotCount { get; set; }

	/// <summary> 
	/// Flag determining if browser sources subscribed to sessions on this channel should output audio.
	/// </summary>
	public Bool IsBrowserSourceAudioEnabled { get; set; }

	/// <summary> 
	/// This setting determines how the guests within a session should be laid out within a group browser source. Can be one of the following values: tiled — All live guests are tiled within the browser source with the same size. screenshare — All live guests are tiled within the browser source with the same size. If there is an active screen share, it is sized larger than the other guests.horizontal_top — Indicates the group layout will contain all participants in a top-aligned horizontal stack.horizontal_bottom — Indicates the group layout will contain all participants in a bottom-aligned horizontal stack.vertical_left — Indicates the group layout will contain all participants in a left-aligned vertical stack.vertical_right — Indicates the group layout will contain all participants in a right-aligned vertical stack.
	/// </summary>
	public string GroupLayout { get; set; }

	public static TwitchChannelGuestStarSettingsUpdateEvent FromData(Dictionary data)
	{
	    return new TwitchChannelGuestStarSettingsUpdateEvent
	    {
			BroadcasterUserId = data["broadcaster_user_id"].AsString(),
			BroadcasterUserName = data["broadcaster_user_name"].AsString(),
			BroadcasterUserLogin = data["broadcaster_user_login"].AsString(),
			IsModeratorSendLiveEnabled = data["is_moderator_send_live_enabled"].As<Bool>(),
			SlotCount = data["slot_count"].AsInt32(),
			IsBrowserSourceAudioEnabled = data["is_browser_source_audio_enabled"].As<Bool>(),
			GroupLayout = data["group_layout"].AsString(),
		};
	}

}
