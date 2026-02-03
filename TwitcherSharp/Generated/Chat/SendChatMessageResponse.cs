using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Chat;
 
/// <summary> 
///  
/// </summary>
public partial class SendChatMessageResponse : Resource, ITwitcherSharp<SendChatMessageResponse>
{
    private GodotObject _data;
	public Data[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a SendChatMessageResponse object.
    /// </summary> 
    public static SendChatMessageResponse FromObject(GodotObject data)
    {
        return new SendChatMessageResponse
        {

			Data = data.Get("data").As<Data[]>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_send_chat_message_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
