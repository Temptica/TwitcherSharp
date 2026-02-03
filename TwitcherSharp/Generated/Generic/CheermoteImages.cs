using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
///  
/// </summary>
public partial class CheermoteImages : Resource, ITwitcherSharp<CheermoteImages>
{
    private GodotObject _data;
	public Light Light { get; set; }
	public Dark Dark { get; set; }
    /// <summary> 
    /// Transforms the godot data into a CheermoteImages object.
    /// </summary> 
    public static CheermoteImages FromObject(GodotObject data)
    {
        return new CheermoteImages
        {

			Light = data.Get("light").As<Light>(),
			Dark = data.Get("dark").As<Dark>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_cheermote_images.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("light", Light);
		request.Set("dark", Dark);
		return request;
	}
}
