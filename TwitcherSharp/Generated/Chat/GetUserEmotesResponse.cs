using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Chat;
 
/// <summary> 
///  
/// </summary>
public partial class GetUserEmotesResponse : Resource, ITwitcherSharp<GetUserEmotesResponse>
{
    private GodotObject _data;
	public Data[] Data { get; set; }
	public string Template { get; set; }
	public Pagination Pagination { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetUserEmotesResponse object.
    /// </summary> 
    public static GetUserEmotesResponse FromObject(GodotObject data)
    {
        return new GetUserEmotesResponse
        {

			Data = data.Get("data").As<Data[]>(),
			Template = data.Get("template").AsString(),
			Pagination = data.Get("pagination").As<Pagination>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_user_emotes_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		request.Set("template", Template);
		request.Set("pagination", Pagination);
		return request;
	}
}
