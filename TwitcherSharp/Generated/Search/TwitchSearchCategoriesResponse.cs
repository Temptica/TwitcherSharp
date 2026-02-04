using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Search;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchSearchCategoriesResponse : Resource, ITwitcherSharp<TwitchSearchCategoriesResponse>
{
    private GodotObject _data;
	public TwitchCategory[] Data { get; set; }
	public TwitchPagination Pagination { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchSearchCategoriesResponse object.
    /// </summary> 
    public static TwitchSearchCategoriesResponse FromObject(GodotObject data)
    {
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		return new TwitchSearchCategoriesResponse
		{
			Data = dataArray.Select(TwitchCategory.FromObject).ToArray(),
			Pagination = data.Get("pagination").As<TwitchPagination>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_search_categories.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		request.Set("pagination", Pagination);
		return request;
	}
}
