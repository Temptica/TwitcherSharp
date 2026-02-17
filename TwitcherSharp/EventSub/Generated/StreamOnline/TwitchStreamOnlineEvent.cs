using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.StreamOnline;

public partial class TwitchStreamOnlineEvent : Resource, ITwitcherSharpEventSub<TwitchStreamOnlineEvent>
{

	/// <summary> 
	/// The id of the stream.
	/// </summary>
	public string Id { get; set; }

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

	/// <summary> 
	/// The stream type. Valid values are: live, playlist, watch_party, premiere, rerun.
	/// </summary>
	public string Type { get; set; }

	/// <summary> 
	/// The timestamp at which the stream went online at.
	/// </summary>
	public string StartedAt { get; set; }


    /// <summary> 
    /// Transforms the godot data into a TwitchStreamOnlineEvent object.
    /// </summary> 
    public static TwitchStreamOnlineEvent FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchStreamOnlineEvent
		{
			Id = data.Get("id").AsString(),
			BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
			BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
			BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
			Type = data.Get("type").AsString(),
			StartedAt = data.Get("started_at").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_stream_online.gd");
		var eventClass = script.Get("Event").AsGodotObject();
		var request = eventClass.Call("new").AsGodotObject();
		request.Set("id", Id);
		request.Set("broadcaster_user_id", BroadcasterUserId);
		request.Set("broadcaster_user_login", BroadcasterUserLogin);
		request.Set("broadcaster_user_name", BroadcasterUserName);
		request.Set("type", Type);
		request.Set("started_at", StartedAt);
		return request;
	}

}
