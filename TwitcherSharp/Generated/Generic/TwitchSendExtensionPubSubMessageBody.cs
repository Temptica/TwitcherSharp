using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchSendExtensionPubSubMessageBody : Resource, ITwitcherSharp<TwitchSendExtensionPubSubMessageBody>
{
    private GodotObject _data;
	public string[] Target { get; set; }
	public string BroadcasterId { get; set; }
	public bool IsGlobalBroadcast { get; set; }
	public string Message { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchSendExtensionPubSubMessageBody object.
    /// </summary> 
    public static TwitchSendExtensionPubSubMessageBody FromObject(GodotObject data)
    {
		return new TwitchSendExtensionPubSubMessageBody
		{
			Target = data.Get("target").AsStringArray(),
			BroadcasterId = data.Get("broadcaster_id").AsString(),
			IsGlobalBroadcast = data.Get("is_global_broadcast").AsBool(),
			Message = data.Get("message").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_send_extension_pub_sub_message.gd");
		var bodyClass = script.Get("Body").AsGodotObject();
		var request = bodyClass.Call("new").AsGodotObject();
		request.Set("target", Target);
		request.Set("broadcaster_id", BroadcasterId);
		request.Set("is_global_broadcast", IsGlobalBroadcast);
		request.Set("message", Message);
		return request;
	}
}
