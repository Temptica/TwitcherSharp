using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Extensions;
 
/// <summary> 
///  
/// </summary>
public partial class SendExtensionChatMessageBody : Resource, ITwitcherSharp<SendExtensionChatMessageBody>
{
    private GodotObject _data;
	public string Text { get; set; }
	public string ExtensionId { get; set; }
	public string ExtensionVersion { get; set; }
    /// <summary> 
    /// Transforms the godot data into a SendExtensionChatMessageBody object.
    /// </summary> 
    public static SendExtensionChatMessageBody FromObject(GodotObject data)
    {
        return new SendExtensionChatMessageBody
        {

			Text = data.Get("text").AsString(),
			ExtensionId = data.Get("extension_id").AsString(),
			ExtensionVersion = data.Get("extension_version").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_send_extension_chat_message_body.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("text", Text);
		request.Set("extension_id", ExtensionId);
		request.Set("extension_version", ExtensionVersion);
		return request;
	}
}
