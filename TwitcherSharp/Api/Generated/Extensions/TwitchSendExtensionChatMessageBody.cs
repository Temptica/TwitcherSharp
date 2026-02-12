using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Extensions;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchSendExtensionChatMessageBody : Resource, ITwitcherSharp<TwitchSendExtensionChatMessageBody>
{
    private GodotObject _data;
	public string Text { get; set; }
	public string ExtensionId { get; set; }
	public string ExtensionVersion { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchSendExtensionChatMessageBody object.
    /// </summary> 
    public static TwitchSendExtensionChatMessageBody FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchSendExtensionChatMessageBody
		{
			Text = data.Get("text").AsString(),
			ExtensionId = data.Get("extension_id").AsString(),
			ExtensionVersion = data.Get("extension_version").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_send_extension_chat_message.gd");
		var bodyClass = script.Get("Body").AsGodotObject();
		var request = bodyClass.Call("new").AsGodotObject();
		request.Set("text", Text);
		request.Set("extension_id", ExtensionId);
		request.Set("extension_version", ExtensionVersion);
		return request;
	}
}
