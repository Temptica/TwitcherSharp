using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Users;
 
/// <summary> 
///  
/// </summary>
public partial class UpdateUserExtensionsBody : Resource, ITwitcherSharp<UpdateUserExtensionsBody>
{
    private GodotObject _data;
	public Data Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a UpdateUserExtensionsBody object.
    /// </summary> 
    public static UpdateUserExtensionsBody FromObject(GodotObject data)
    {
        return new UpdateUserExtensionsBody
        {

			Data = data.Get("data").As<Data>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_user_extensions_body.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
