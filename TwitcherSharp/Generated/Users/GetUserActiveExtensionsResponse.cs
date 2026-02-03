using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Users;
 
/// <summary> 
///  
/// </summary>
public partial class GetUserActiveExtensionsResponse : Resource, ITwitcherSharp<GetUserActiveExtensionsResponse>
{
    private GodotObject _data;
	public Data Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetUserActiveExtensionsResponse object.
    /// </summary> 
    public static GetUserActiveExtensionsResponse FromObject(GodotObject data)
    {
        return new GetUserActiveExtensionsResponse
        {

			Data = data.Get("data").As<Data>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_user_active_extensions_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
