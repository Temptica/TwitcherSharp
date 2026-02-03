using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Chat;
 
/// <summary> 
///  
/// </summary>
public partial class GetChattersResponse : Resource, ITwitcherSharp<GetChattersResponse>
{
    private GodotObject _data;
	public Chatter[] Data { get; set; }
	public Pagination Pagination { get; set; }
	public int Total { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetChattersResponse object.
    /// </summary> 
    public static GetChattersResponse FromObject(GodotObject data)
    {
        return new GetChattersResponse
        {

			Data = data.Get("data").As<Chatter[]>(),
			Pagination = data.Get("pagination").As<Pagination>(),
			Total = data.Get("total").AsInt32(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_chatters_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		request.Set("pagination", Pagination);
		request.Set("total", Total);
		return request;
	}
}
