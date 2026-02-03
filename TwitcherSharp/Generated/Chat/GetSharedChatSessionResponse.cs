using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Chat;
 
/// <summary> 
///  
/// </summary>
public partial class GetSharedChatSessionResponse : Resource, ITwitcherSharp<GetSharedChatSessionResponse>
{
    private GodotObject _data;
	public Data[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetSharedChatSessionResponse object.
    /// </summary> 
    public static GetSharedChatSessionResponse FromObject(GodotObject data)
    {
        return new GetSharedChatSessionResponse
        {

			Data = data.Get("data").As<Data[]>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_shared_chat_session_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
