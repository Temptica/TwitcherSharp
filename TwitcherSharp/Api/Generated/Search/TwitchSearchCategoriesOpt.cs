using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Search;


/// <summary> 
/// All optional parameters for TwitchAPI.SearchCategories 
/// </summary>
public partial class TwitchSearchCategoriesOpt : RefCounted, ITwitcherSharp<TwitchSearchCategoriesOpt>
{
    private GodotObject _data;
    public int? First { get; set; }
    public string After { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchSearchCategoriesOpt object.
    /// </summary> 
    public static TwitchSearchCategoriesOpt FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchSearchCategoriesOpt
        {
            First = data.Get("first").AsInt32(),
            After = data.Get("after").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_search_categories.gd");
        var optClass = script.Get("Opt").AsGodotObject();
        var request = optClass.Call("new").AsGodotObject();
        if(First.HasValue) request.Set("first", First.Value);
        if(After != null) request.Set("after", After);
        return request;
    }

}
