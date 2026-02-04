using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Chat;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchGetUserEmotesResponse : Resource, ITwitcherSharp<TwitchGetUserEmotesResponse>
{
    private GodotObject _data;
	public TwitchData[] Data { get; set; }
	public string Template { get; set; }
	public TwitchPagination Pagination { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchGetUserEmotesResponse object.
    /// </summary> 
    public static TwitchGetUserEmotesResponse FromObject(GodotObject data)
    {
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		return new TwitchGetUserEmotesResponse
		{
			Data = dataArray.Select(TwitchData.FromObject).ToArray(),
			Template = data.Get("template").AsString(),
			Pagination = data.Get("pagination").As<TwitchPagination>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_user_emotes.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		request.Set("template", Template);
		request.Set("pagination", Pagination);
		return request;
	}
}
