using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
///  
/// </summary>
public partial class UserExtensionComponent : Resource, ITwitcherSharp<UserExtensionComponent>
{
    private GodotObject _data;
	public bool Active { get; set; }
	public string Id { get; set; }
	public string Version { get; set; }
	public string Name { get; set; }
	public int X { get; set; }
	public int Y { get; set; }
    /// <summary> 
    /// Transforms the godot data into a UserExtensionComponent object.
    /// </summary> 
    public static UserExtensionComponent FromObject(GodotObject data)
    {
        return new UserExtensionComponent
        {

			Active = data.Get("active").AsBool(),
			Id = data.Get("id").AsString(),
			Version = data.Get("version").AsString(),
			Name = data.Get("name").AsString(),
			X = data.Get("x").AsInt32(),
			Y = data.Get("y").AsInt32(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_user_extension_component.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("active", Active);
		request.Set("id", Id);
		request.Set("version", Version);
		request.Set("name", Name);
		request.Set("x", X);
		request.Set("y", Y);
		return request;
	}
}
