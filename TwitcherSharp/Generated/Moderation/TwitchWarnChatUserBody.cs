using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Moderation;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchWarnChatUserBody : Resource, ITwitcherSharp<TwitchWarnChatUserBody>
{
    private GodotObject _data;
	public TwitchData Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchWarnChatUserBody object.
    /// </summary> 
    public static TwitchWarnChatUserBody FromObject(GodotObject data)
    {
		return new TwitchWarnChatUserBody
		{
			Data = data.Get("data").As<TwitchData>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_warn_chat_user.gd");
		var bodyClass = script.Get("Body").AsGodotObject();
		var request = bodyClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
