using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Shared;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchUserExtension : Resource, ITwitcherSharp<TwitchUserExtension>
{
    private GodotObject _data;
	public string Id { get; set; }
	public string Version { get; set; }
	public string Name { get; set; }
	public bool CanActivate { get; set; }
	public string[] Type { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchUserExtension object.
    /// </summary> 
    public static TwitchUserExtension FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchUserExtension
		{
			Id = data.Get("id").AsString(),
			Version = data.Get("version").AsString(),
			Name = data.Get("name").AsString(),
			CanActivate = data.Get("can_activate").AsBool(),
			Type = data.Get("type").AsStringArray(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_user_extension.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("id", Id);
		request.Set("version", Version);
		request.Set("name", Name);
		request.Set("can_activate", CanActivate);
		request.Set("type", Type);
		return request;
	}
}
