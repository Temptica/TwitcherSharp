using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Moderation;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchGetShieldModeStatusResponse : Resource, ITwitcherSharp<TwitchGetShieldModeStatusResponse>
{
    private GodotObject _data;
	public TwitchData[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchGetShieldModeStatusResponse object.
    /// </summary> 
    public static TwitchGetShieldModeStatusResponse FromObject(GodotObject data)
    {
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		return new TwitchGetShieldModeStatusResponse
		{
			Data = dataArray.Select(TwitchData.FromObject).ToArray(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_shield_mode_status.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
