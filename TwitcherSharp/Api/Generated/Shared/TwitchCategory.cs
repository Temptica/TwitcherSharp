using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Shared;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchCategory : Resource, ITwitcherSharp<TwitchCategory>
{
    private GodotObject _data;
	public string BoxArtUrl { get; set; }
	public string Name { get; set; }
	public string Id { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchCategory object.
    /// </summary> 
    public static TwitchCategory FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchCategory
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
