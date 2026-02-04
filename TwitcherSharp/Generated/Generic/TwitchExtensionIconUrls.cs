using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// A dictionary that contains URLs to different sizes of the default icon. The dictionary’s key identifies the icon’s size (for example, 24x24), and the dictionary’s value contains the URL to the icon. 
/// </summary>
public partial class TwitchExtensionIconUrls : Resource, ITwitcherSharp<TwitchExtensionIconUrls>
{
    private GodotObject _data;
	public string _100x100 { get; set; }
	public string _24x24 { get; set; }
	public string _300x200 { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchExtensionIconUrls object.
    /// </summary> 
    public static TwitchExtensionIconUrls FromObject(GodotObject data)
    {
		return new TwitchExtensionIconUrls
		{
			_100x100 = data.Get("__1_0_0x_1_0_0").AsString(),
			_24x24 = data.Get("__2_4x_2_4").AsString(),
			_300x200 = data.Get("__3_0_0x_2_0_0").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_extension_icon_urls.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("__1_0_0x_1_0_0", _100x100);
		request.Set("__2_4x_2_4", _24x24);
		request.Set("__3_0_0x_2_0_0", _300x200);
		return request;
	}
}
