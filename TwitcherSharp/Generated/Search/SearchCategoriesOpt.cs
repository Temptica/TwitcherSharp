using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Search;
 
/// <summary> 
/// All optional parameters for TwitchAPI.SearchCategories 
/// </summary>
public partial class SearchCategoriesOpt : Resource, ITwitcherSharp<SearchCategoriesOpt>
{
    private GodotObject _data;
	public int First { get; set; }
	public string After { get; set; }
    /// <summary> 
    /// Transforms the godot data into a SearchCategoriesOpt object.
    /// </summary> 
    public static SearchCategoriesOpt FromObject(GodotObject data)
    {
        return new SearchCategoriesOpt
        {

			First = data.Get("first").AsInt32(),
			After = data.Get("after").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_search_categories_opt.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("first", First);
		request.Set("after", After);
		return request;
	}
}
