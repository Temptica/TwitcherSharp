using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchUserExtensionPanel : Resource, ITwitcherSharp<TwitchUserExtensionPanel>
{
    private GodotObject _data;
	public bool Active { get; set; }
	public string Id { get; set; }
	public string Version { get; set; }
	public string Name { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchUserExtensionPanel object.
    /// </summary> 
    public static TwitchUserExtensionPanel FromObject(GodotObject data)
    {
		return new TwitchUserExtensionPanel
		{
			Active = data.Get("active").AsBool(),
			Id = data.Get("id").AsString(),
			Version = data.Get("version").AsString(),
			Name = data.Get("name").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_user_extension_panel.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("active", Active);
		request.Set("id", Id);
		request.Set("version", Version);
		request.Set("name", Name);
		return request;
	}
}
