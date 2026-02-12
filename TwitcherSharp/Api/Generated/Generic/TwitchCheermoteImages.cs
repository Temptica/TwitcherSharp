using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Generic;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchCheermoteImages : Resource, ITwitcherSharp<TwitchCheermoteImages>
{
    private GodotObject _data;
	public TwitchLight Light { get; set; }
	public TwitchDark Dark { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchCheermoteImages object.
    /// </summary> 
    public static TwitchCheermoteImages FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchCheermoteImages
		{
			Light = data.Get("light").As<TwitchLight>(),
			Dark = data.Get("dark").As<TwitchDark>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_cheermote_images.gd");
		var request = script.Call("new").AsGodotObject();
		if(Light != null) request.Set("light", Light);
		if(Dark != null) request.Set("dark", Dark);
		return request;
	}
}
