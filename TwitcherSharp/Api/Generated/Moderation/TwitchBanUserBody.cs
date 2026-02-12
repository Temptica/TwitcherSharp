using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchBanUserBody : Resource, ITwitcherSharp<TwitchBanUserBody>
{
    private GodotObject _data;
	public TwitchData Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchBanUserBody object.
    /// </summary> 
    public static TwitchBanUserBody FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchBanUserBody
		{
			Data = data.Get("data").As<TwitchData>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_ban_user.gd");
		var bodyClass = script.Get("Body").AsGodotObject();
		var request = bodyClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
