using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// Contains the information used to page through the list of results. The object is empty if there are no more pages left to page through. [Read More](https://dev.twitch.tv/docs/api/guide#pagination) 
/// </summary>
public partial class Pagination : Resource, ITwitcherSharp<Pagination>
{
    private GodotObject _data;
	public string Cursor { get; set; }
    /// <summary> 
    /// Transforms the godot data into a Pagination object.
    /// </summary> 
    public static Pagination FromObject(GodotObject data)
    {
        return new Pagination
        {

			Cursor = data.Get("cursor").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_pagination.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("cursor", Cursor);
		return request;
	}
}
