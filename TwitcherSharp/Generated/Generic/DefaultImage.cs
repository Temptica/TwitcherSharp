using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// A set of default images for the reward. 
/// </summary>
public partial class DefaultImage : Resource, ITwitcherSharp<DefaultImage>
{
    private GodotObject _data;
	public string Url1x { get; set; }
	public string Url2x { get; set; }
	public string Url4x { get; set; }
    /// <summary> 
    /// Transforms the godot data into a DefaultImage object.
    /// </summary> 
    public static DefaultImage FromObject(GodotObject data)
    {
        return new DefaultImage
        {

			Url1x = data.Get("url_1x").AsString(),
			Url2x = data.Get("url_2x").AsString(),
			Url4x = data.Get("url_4x").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_default_image.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("url_1x", Url1x);
		request.Set("url_2x", Url2x);
		request.Set("url_4x", Url4x);
		return request;
	}
}
