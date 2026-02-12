using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchChannelUpdateEvent : Resource, ITwitcherSharpEventSub<TwitchChannelUpdateEvent>
{

	/// <summary> 
	/// The broadcaster’s user ID.
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

	/// <summary> 
	/// The channel’s stream title.
	/// </summary>
	public string Title { get; set; }

	/// <summary> 
	/// The channel’s broadcast language.
	/// </summary>
	public string Language { get; set; }

	/// <summary> 
	/// The channel’s category ID.
	/// </summary>
	public string CategoryId { get; set; }

	/// <summary> 
	/// The category name.
	/// </summary>
	public string CategoryName { get; set; }

	public static TwitchChannelUpdateEvent FromData(Dictionary data)
	{
	    return new TwitchChannelUpdateEvent
	    {
			BroadcasterUserId = data["broadcaster_user_id"].AsString(),
			BroadcasterUserLogin = data["broadcaster_user_login"].AsString(),
			BroadcasterUserName = data["broadcaster_user_name"].AsString(),
			Title = data["title"].AsString(),
			Language = data["language"].AsString(),
			CategoryId = data["category_id"].AsString(),
			CategoryName = data["category_name"].AsString(),
		};
	}

}
