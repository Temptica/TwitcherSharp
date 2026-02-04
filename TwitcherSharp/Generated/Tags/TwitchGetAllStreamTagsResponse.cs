using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Tags;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchGetAllStreamTagsResponse : Resource, ITwitcherSharp<TwitchGetAllStreamTagsResponse>
{
    private GodotObject _data;
	public TwitchStreamTag[] Data { get; set; }
	public TwitchPagination Pagination { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchGetAllStreamTagsResponse object.
    /// </summary> 
    public static TwitchGetAllStreamTagsResponse FromObject(GodotObject data)
    {
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		return new TwitchGetAllStreamTagsResponse
		{
			Data = dataArray.Select(TwitchStreamTag.FromObject).ToArray(),
			Pagination = data.Get("pagination").As<TwitchPagination>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_all_stream_tags.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		request.Set("pagination", Pagination);
		return request;
	}
}
