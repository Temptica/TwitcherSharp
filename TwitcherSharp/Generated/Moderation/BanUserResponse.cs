using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Moderation;
 
/// <summary> 
///  
/// </summary>
public partial class BanUserResponse : Resource, ITwitcherSharp<BanUserResponse>
{
    private GodotObject _data;
	public Data[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a BanUserResponse object.
    /// </summary> 
    public static BanUserResponse FromObject(GodotObject data)
    {
        return new BanUserResponse
        {

			Data = data.Get("data").As<Data[]>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_ban_user_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
