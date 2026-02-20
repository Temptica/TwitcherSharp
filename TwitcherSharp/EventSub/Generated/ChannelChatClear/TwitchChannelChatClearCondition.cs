using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelChatClear;

public partial class TwitchChannelChatClearCondition : Resource, ITwitcherSharpCondition<TwitchChannelChatClearCondition>
{
	public string Name => nameof(TwitchChannelChatClearCondition);

	/// <summary> 
	/// User ID of the channel to receive chat clear events for.
	/// </summary>
	public string BroadcasterUserId { get; set; }

	/// <summary> 
	/// The user ID to read chat as.
	/// </summary>
	public string UserId { get; set; }


    /// <summary> 
    /// Transforms the godot data into a TwitchChannelChatClearCondition object.
    /// </summary> 
    public static TwitchChannelChatClearCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchChannelChatClearCondition
		{
			BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
			UserId = data.Get("user_id").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_clear.gd");
		var conditionClass = script.Get("Condition").AsGodotObject();
		var request = conditionClass.Call("new").AsGodotObject();
		request.Set("broadcaster_user_id", BroadcasterUserId);
		request.Set("user_id", UserId);
		return request;
	}

}
