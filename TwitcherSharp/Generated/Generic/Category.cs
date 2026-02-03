using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
///  
/// </summary>
public partial class Category : Resource, ITwitcherSharp<Category>
{
    private GodotObject _data;
	public string BoxArtUrl { get; set; }
	public string Name { get; set; }
	public string Id { get; set; }
    /// <summary> 
    /// Transforms the godot data into a Category object.
    /// </summary> 
    public static Category FromObject(GodotObject data)
    {
        return new Category
        {

			BoxArtUrl = data.Get("box_art_url").AsString(),
			Name = data.Get("name").AsString(),
			Id = data.Get("id").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_category.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("box_art_url", BoxArtUrl);
		request.Set("name", Name);
		request.Set("id", Id);
		return request;
	}
}
