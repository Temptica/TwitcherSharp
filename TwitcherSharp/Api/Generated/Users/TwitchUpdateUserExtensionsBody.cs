using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Users;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchUpdateUserExtensionsBody : Resource, ITwitcherSharp<TwitchUpdateUserExtensionsBody>
{
    private GodotObject _data;
	public TwitchData Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateUserExtensionsBody object.
    /// </summary> 
    public static TwitchUpdateUserExtensionsBody FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchUpdateUserExtensionsBody
		{
			Data = data.Get("data").As<TwitchData>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_user_extensions.gd");
		var bodyClass = script.Get("Body").AsGodotObject();
		var request = bodyClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
