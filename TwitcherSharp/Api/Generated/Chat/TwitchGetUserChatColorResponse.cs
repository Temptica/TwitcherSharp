using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Chat;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchGetUserChatColorResponse : Resource, ITwitcherSharp<TwitchGetUserChatColorResponse>
{
    private GodotObject _data;
	public TwitchUserChatColor[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetUserChatColorResponse object.
    /// </summary> 
    public static TwitchGetUserChatColorResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		return new TwitchGetUserChatColorResponse
		{
			Data = dataArray.Select(TwitchUserChatColor.FromObject).ToArray(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_user_chat_color.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
