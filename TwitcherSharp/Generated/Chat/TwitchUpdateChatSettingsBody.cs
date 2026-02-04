using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Chat;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchUpdateChatSettingsBody : Resource, ITwitcherSharp<TwitchUpdateChatSettingsBody>
{
    private GodotObject _data;
	public bool EmoteMode { get; set; }
	public bool FollowerMode { get; set; }
	public int FollowerModeDuration { get; set; }
	public bool NonModeratorChatDelay { get; set; }
	public int NonModeratorChatDelayDuration { get; set; }
	public bool SlowMode { get; set; }
	public int SlowModeWaitTime { get; set; }
	public bool SubscriberMode { get; set; }
	public bool UniqueChatMode { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateChatSettingsBody object.
    /// </summary> 
    public static TwitchUpdateChatSettingsBody FromObject(GodotObject data)
    {
		return new TwitchUpdateChatSettingsBody
		{
			EmoteMode = data.Get("emote_mode").AsBool(),
			FollowerMode = data.Get("follower_mode").AsBool(),
			FollowerModeDuration = data.Get("follower_mode_duration").AsInt32(),
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
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_chat_settings.gd");
		var bodyClass = script.Get("Body").AsGodotObject();
		var request = bodyClass.Call("new").AsGodotObject();
		request.Set("emote_mode", EmoteMode);
		request.Set("follower_mode", FollowerMode);
		request.Set("follower_mode_duration", FollowerModeDuration);
		request.Set("non_moderator_chat_delay", NonModeratorChatDelay);
		request.Set("non_moderator_chat_delay_duration", NonModeratorChatDelayDuration);
		request.Set("slow_mode", SlowMode);
		request.Set("slow_mode_wait_time", SlowModeWaitTime);
		request.Set("subscriber_mode", SubscriberMode);
		request.Set("unique_chat_mode", UniqueChatMode);
		return request;
	}
}
