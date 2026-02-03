using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// The list of chat badges in this set. 
/// </summary>
public partial class Versions : Resource, ITwitcherSharp<Versions>
{
    private GodotObject _data;
	public string Id { get; set; }
	public string ImageUrl1x { get; set; }
	public string ImageUrl2x { get; set; }
	public string ImageUrl4x { get; set; }
	public string Title { get; set; }
	public string Description { get; set; }
	public string ClickAction { get; set; }
	public string ClickUrl { get; set; }
    /// <summary> 
    /// Transforms the godot data into a Versions object.
    /// </summary> 
    public static Versions FromObject(GodotObject data)
    {
        return new Versions
        {

			Id = data.Get("id").AsString(),
			ImageUrl1x = data.Get("image_url_1x").AsString(),
			ImageUrl2x = data.Get("image_url_2x").AsString(),
			ImageUrl4x = data.Get("image_url_4x").AsString(),
			Title = data.Get("title").AsString(),
			Description = data.Get("description").AsString(),
			ClickAction = data.Get("click_action").AsString(),
			ClickUrl = data.Get("click_url").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_versions.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("id", Id);
		request.Set("image_url_1x", ImageUrl1x);
		request.Set("image_url_2x", ImageUrl2x);
		request.Set("image_url_4x", ImageUrl4x);
		request.Set("title", Title);
		request.Set("description", Description);
		request.Set("click_action", ClickAction);
		request.Set("click_url", ClickUrl);
		return request;
	}
}
