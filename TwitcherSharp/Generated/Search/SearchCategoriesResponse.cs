using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Search;
 
/// <summary> 
///  
/// </summary>
public partial class SearchCategoriesResponse : Resource, ITwitcherSharp<SearchCategoriesResponse>
{
    private GodotObject _data;
	public Category[] Data { get; set; }
	public Pagination Pagination { get; set; }
    /// <summary> 
    /// Transforms the godot data into a SearchCategoriesResponse object.
    /// </summary> 
    public static SearchCategoriesResponse FromObject(GodotObject data)
    {
        return new SearchCategoriesResponse
        {

			Data = data.Get("data").As<Category[]>(),
			Pagination = data.Get("pagination").As<Pagination>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_search_categories_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		request.Set("pagination", Pagination);
		return request;
	}
}
