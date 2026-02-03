using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Moderation;
 
/// <summary> 
///  
/// </summary>
public partial class UpdateShieldModeStatusResponse : Resource, ITwitcherSharp<UpdateShieldModeStatusResponse>
{
    private GodotObject _data;
	public Data[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a UpdateShieldModeStatusResponse object.
    /// </summary> 
    public static UpdateShieldModeStatusResponse FromObject(GodotObject data)
    {
        return new UpdateShieldModeStatusResponse
        {

			Data = data.Get("data").As<Data[]>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_shield_mode_status_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
