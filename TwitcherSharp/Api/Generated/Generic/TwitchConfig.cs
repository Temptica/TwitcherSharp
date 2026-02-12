using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Generic;
 
/// <summary> 
/// Describes the view that is shown to broadcasters while they are configuring your extension within the Extension Manager. 
/// </summary>
public partial class TwitchConfig : Resource, ITwitcherSharp<TwitchConfig>
{
    private GodotObject _data;
	public string ViewerUrl { get; set; }
	public bool CanLinkExternalContent { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchConfig object.
    /// </summary> 
    public static TwitchConfig FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchConfig
		{
			ViewerUrl = data.Get("viewer_url").AsString(),
			CanLinkExternalContent = data.Get("can_link_external_content").AsBool(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_config.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("viewer_url", ViewerUrl);
		request.Set("can_link_external_content", CanLinkExternalContent);
		return request;
	}
}
