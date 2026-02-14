using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Shared;
 
/// <summary> 
/// A dictionary that contains URLs to different sizes of the default icon. The dictionary’s key identifies the icon’s size (for example, 24x24), and the dictionary’s value contains the URL to the icon. 
/// </summary>
public partial class TwitchIconUrls : Resource, ITwitcherSharp<TwitchIconUrls>
{
    private GodotObject _data;
	public string _100x100 { get; set; }
	public string _24x24 { get; set; }
	public string _300x200 { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchIconUrls object.
    /// </summary> 
    public static TwitchIconUrls FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchIconUrls
		{
			_100x100 = data.Get("__1_0_0x_1_0_0").AsString(),
			_24x24 = data.Get("__2_4x_2_4").AsString(),
			_300x200 = data.Get("__3_0_0x_2_0_0").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_icon_urls.gd");
		var request = script.Call("new").AsGodotObject();
		if(_100x100 != null) request.Set("__1_0_0x_1_0_0", _100x100);
		if(_24x24 != null) request.Set("__2_4x_2_4", _24x24);
		if(_300x200 != null) request.Set("__3_0_0x_2_0_0", _300x200);
		return request;
	}
}
