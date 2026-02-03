using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// The image URLs for the emote. These image URLs always provide a static, non-animated emote image with a light background.  
///   
/// **NOTE:** You should use the templated URL in the `template` field to fetch the image instead of using these URLs. 
/// </summary>
public partial class Images : Resource, ITwitcherSharp<Images>
{
    private GodotObject _data;
	public string Url1x { get; set; }
	public string Url2x { get; set; }
	public string Url4x { get; set; }
    /// <summary> 
    /// Transforms the godot data into a Images object.
    /// </summary> 
    public static Images FromObject(GodotObject data)
    {
        return new Images
        {

			Url1x = data.Get("url_1x").AsString(),
			Url2x = data.Get("url_2x").AsString(),
			Url4x = data.Get("url_4x").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_images.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("url_1x", Url1x);
		request.Set("url_2x", Url2x);
		request.Set("url_4x", Url4x);
		return request;
	}
}
