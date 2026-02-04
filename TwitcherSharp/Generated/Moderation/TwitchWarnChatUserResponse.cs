using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Moderation;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchWarnChatUserResponse : Resource, ITwitcherSharp<TwitchWarnChatUserResponse>
{
    private GodotObject _data;
	public TwitchData[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchWarnChatUserResponse object.
    /// </summary> 
    public static TwitchWarnChatUserResponse FromObject(GodotObject data)
    {
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		return new TwitchWarnChatUserResponse
		{
			Data = dataArray.Select(TwitchData.FromObject).ToArray(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_warn_chat_user.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
