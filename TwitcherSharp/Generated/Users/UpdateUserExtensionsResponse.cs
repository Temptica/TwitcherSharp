using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Users;
 
/// <summary> 
///  
/// </summary>
public partial class UpdateUserExtensionsResponse : Resource, ITwitcherSharp<UpdateUserExtensionsResponse>
{
    private GodotObject _data;
	public Data Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a UpdateUserExtensionsResponse object.
    /// </summary> 
    public static UpdateUserExtensionsResponse FromObject(GodotObject data)
    {
        return new UpdateUserExtensionsResponse
        {

			Data = data.Get("data").As<Data>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_user_extensions_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
