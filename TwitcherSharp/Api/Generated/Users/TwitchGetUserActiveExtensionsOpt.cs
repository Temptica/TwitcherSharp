using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Users;


/// <summary> 
/// All optional parameters for TwitchAPI.GetUserActiveExtensions 
/// </summary>
public partial class TwitchGetUserActiveExtensionsOpt : Resource, ITwitcherSharp<TwitchGetUserActiveExtensionsOpt>
{
    private GodotObject _data;
	public string UserId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetUserActiveExtensionsOpt object.
    /// </summary> 
    public static TwitchGetUserActiveExtensionsOpt FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchGetUserActiveExtensionsOpt
		{
			UserId = data.Get("user_id").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_user_active_extensions.gd");
		var optClass = script.Get("Opt").AsGodotObject();
		var request = optClass.Call("new").AsGodotObject();
		if(UserId != null) request.Set("user_id", UserId);
		return request;
	}

}
