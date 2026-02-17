using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelRaid;

public partial class TwitchChannelRaidEvent : Resource, ITwitcherSharpEventSub<TwitchChannelRaidEvent>
{

	/// <summary> 
	/// The broadcaster ID that created the raid.
	/// </summary>
	public string FromBroadcasterUserId { get; set; }

	/// <summary> 
	/// The broadcaster login that created the raid.
	/// </summary>
	public string FromBroadcasterUserLogin { get; set; }

	/// <summary> 
	/// The broadcaster display name that created the raid.
	/// </summary>
	public string FromBroadcasterUserName { get; set; }

	/// <summary> 
	/// The broadcaster ID that received the raid.
	/// </summary>
	public string ToBroadcasterUserId { get; set; }

	/// <summary> 
	/// The broadcaster login that received the raid.
	/// </summary>
	public string ToBroadcasterUserLogin { get; set; }

	/// <summary> 
	/// The broadcaster display name that received the raid.
	/// </summary>
	public string ToBroadcasterUserName { get; set; }

	/// <summary> 
	/// The number of viewers in the raid.
	/// </summary>
	public int Viewers { get; set; }


    /// <summary> 
    /// Transforms the godot data into a TwitchChannelRaidEvent object.
    /// </summary> 
    public static TwitchChannelRaidEvent FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchChannelRaidEvent
		{
			FromBroadcasterUserId = data.Get("from_broadcaster_user_id").AsString(),
			FromBroadcasterUserLogin = data.Get("from_broadcaster_user_login").AsString(),
			FromBroadcasterUserName = data.Get("from_broadcaster_user_name").AsString(),
			ToBroadcasterUserId = data.Get("to_broadcaster_user_id").AsString(),
			ToBroadcasterUserLogin = data.Get("to_broadcaster_user_login").AsString(),
			ToBroadcasterUserName = data.Get("to_broadcaster_user_name").AsString(),
			Viewers = data.Get("viewers").AsInt32(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_raid.gd");
		var eventClass = script.Get("Event").AsGodotObject();
		var request = eventClass.Call("new").AsGodotObject();
		request.Set("from_broadcaster_user_id", FromBroadcasterUserId);
		request.Set("from_broadcaster_user_login", FromBroadcasterUserLogin);
		request.Set("from_broadcaster_user_name", FromBroadcasterUserName);
		request.Set("to_broadcaster_user_id", ToBroadcasterUserId);
		request.Set("to_broadcaster_user_login", ToBroadcasterUserLogin);
		request.Set("to_broadcaster_user_name", ToBroadcasterUserName);
		request.Set("viewers", Viewers);
		return request;
	}

}
