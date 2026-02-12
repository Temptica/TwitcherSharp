using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Generic;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchChatSettingsUpdated : Resource, ITwitcherSharp<TwitchChatSettingsUpdated>
{
    private GodotObject _data;
	public string BroadcasterId { get; set; }
	public bool EmoteMode { get; set; }
	public bool FollowerMode { get; set; }
	public int FollowerModeDuration { get; set; }
	public string ModeratorId { get; set; }
	public bool NonModeratorChatDelay { get; set; }
	public int NonModeratorChatDelayDuration { get; set; }
	public bool SlowMode { get; set; }
	public int SlowModeWaitTime { get; set; }
	public bool SubscriberMode { get; set; }
	public bool UniqueChatMode { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChatSettingsUpdated object.
    /// </summary> 
    public static TwitchChatSettingsUpdated FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchChatSettingsUpdated
		{
			BroadcasterId = data.Get("broadcaster_id").AsString(),
			EmoteMode = data.Get("emote_mode").AsBool(),
			FollowerMode = data.Get("follower_mode").AsBool(),
			FollowerModeDuration = data.Get("follower_mode_duration").AsInt32(),
			ModeratorId = data.Get("moderator_id").AsString(),
			NonModeratorChatDelay = data.Get("non_moderator_chat_delay").AsBool(),
			NonModeratorChatDelayDuration = data.Get("non_moderator_chat_delay_duration").AsInt32(),
			SlowMode = data.Get("slow_mode").AsBool(),
			SlowModeWaitTime = data.Get("slow_mode_wait_time").AsInt32(),
			SubscriberMode = data.Get("subscriber_mode").AsBool(),
			UniqueChatMode = data.Get("unique_chat_mode").AsBool(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_chat_settings_updated.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("broadcaster_id", BroadcasterId);
		request.Set("emote_mode", EmoteMode);
		request.Set("follower_mode", FollowerMode);
		request.Set("follower_mode_duration", FollowerModeDuration);
		if(ModeratorId != null) request.Set("moderator_id", ModeratorId);
		request.Set("non_moderator_chat_delay", NonModeratorChatDelay);
		request.Set("non_moderator_chat_delay_duration", NonModeratorChatDelayDuration);
		request.Set("slow_mode", SlowMode);
		request.Set("slow_mode_wait_time", SlowModeWaitTime);
		request.Set("subscriber_mode", SubscriberMode);
		request.Set("unique_chat_mode", UniqueChatMode);
		return request;
	}
}
