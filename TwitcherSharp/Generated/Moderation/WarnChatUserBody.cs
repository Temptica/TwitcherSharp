using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Moderation;
 
/// <summary> 
///  
/// </summary>
public partial class WarnChatUserBody : Resource, ITwitcherSharp<WarnChatUserBody>
{
    private GodotObject _data;
	public Data Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a WarnChatUserBody object.
    /// </summary> 
    public static WarnChatUserBody FromObject(GodotObject data)
    {
        return new WarnChatUserBody
        {

			Data = data.Get("data").As<Data>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_warn_chat_user_body.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
