using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Users;
 
/// <summary> 
///  
/// </summary>
public partial class GetAuthorizationByUserResponse : Resource, ITwitcherSharp<GetAuthorizationByUserResponse>
{
    private GodotObject _data;
	public Data[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetAuthorizationByUserResponse object.
    /// </summary> 
    public static GetAuthorizationByUserResponse FromObject(GodotObject data)
    {
        return new GetAuthorizationByUserResponse
        {

			Data = data.Get("data").As<Data[]>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_authorization_by_user_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
