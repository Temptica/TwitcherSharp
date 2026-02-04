using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchUserExtensionPanelUpdate : Resource, ITwitcherSharp<TwitchUserExtensionPanelUpdate>
{
    private GodotObject _data;
	public bool Active { get; set; }
	public string Id { get; set; }
	public string Version { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchUserExtensionPanelUpdate object.
    /// </summary> 
    public static TwitchUserExtensionPanelUpdate FromObject(GodotObject data)
    {
		return new TwitchUserExtensionPanelUpdate
		{
			Active = data.Get("active").AsBool(),
			Id = data.Get("id").AsString(),
			Version = data.Get("version").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_user_extension_panel_update.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("active", Active);
		request.Set("id", Id);
		request.Set("version", Version);
		return request;
	}
}
