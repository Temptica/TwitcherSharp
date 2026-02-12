using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Generic;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchUserExtensionComponentUpdate : Resource, ITwitcherSharp<TwitchUserExtensionComponentUpdate>
{
    private GodotObject _data;
	public bool Active { get; set; }
	public string Id { get; set; }
	public string Version { get; set; }
	public int? X { get; set; }
	public int? Y { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchUserExtensionComponentUpdate object.
    /// </summary> 
    public static TwitchUserExtensionComponentUpdate FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchUserExtensionComponentUpdate
		{
			Active = data.Get("active").AsBool(),
			Id = data.Get("id").AsString(),
			Version = data.Get("version").AsString(),
			X = data.Get("x").AsInt32(),
			Y = data.Get("y").AsInt32(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_user_extension_component_update.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("active", Active);
		if(Id != null) request.Set("id", Id);
		if(Version != null) request.Set("version", Version);
		if(X.HasValue) request.Set("x", X.Value);
		if(Y.HasValue) request.Set("y", Y.Value);
		return request;
	}
}
