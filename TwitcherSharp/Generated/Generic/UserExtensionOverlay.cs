using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
///  
/// </summary>
public partial class UserExtensionOverlay : Resource, ITwitcherSharp<UserExtensionOverlay>
{
    private GodotObject _data;
	public bool Active { get; set; }
	public string Id { get; set; }
	public string Version { get; set; }
	public string Name { get; set; }
    /// <summary> 
    /// Transforms the godot data into a UserExtensionOverlay object.
    /// </summary> 
    public static UserExtensionOverlay FromObject(GodotObject data)
    {
        return new UserExtensionOverlay
        {

			Active = data.Get("active").AsBool(),
			Id = data.Get("id").AsString(),
			Version = data.Get("version").AsString(),
			Name = data.Get("name").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_user_extension_overlay.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("active", Active);
		request.Set("id", Id);
		request.Set("version", Version);
		request.Set("name", Name);
		return request;
	}
}
