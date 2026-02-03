using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Moderation;
 
/// <summary> 
///  
/// </summary>
public partial class BanUserBody : Resource, ITwitcherSharp<BanUserBody>
{
    private GodotObject _data;
	public Data Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a BanUserBody object.
    /// </summary> 
    public static BanUserBody FromObject(GodotObject data)
    {
        return new BanUserBody
        {

			Data = data.Get("data").As<Data>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_ban_user_body.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
