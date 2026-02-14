using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Shared;
 
/// <summary> 
/// Describes how the extension is displayed on mobile devices. 
/// </summary>
public partial class TwitchMobile : Resource, ITwitcherSharp<TwitchMobile>
{
    private GodotObject _data;
	public string ViewerUrl { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchMobile object.
    /// </summary> 
    public static TwitchMobile FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchMobile
		{
			ViewerUrl = data.Get("viewer_url").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_mobile.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("viewer_url", ViewerUrl);
		return request;
	}
}
