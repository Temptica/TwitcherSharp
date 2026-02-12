using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Generic;
 
/// <summary> 
/// The dates when the broadcaster is on vacation and not streaming. Is set to **null** if vacation mode is not enabled. 
/// </summary>
public partial class TwitchVacation : Resource, ITwitcherSharp<TwitchVacation>
{
    private GodotObject _data;
	public string StartTime { get; set; }
	public string EndTime { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchVacation object.
    /// </summary> 
    public static TwitchVacation FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchVacation
		{
			StartTime = data.Get("start_time").AsString(),
			EndTime = data.Get("end_time").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_vacation.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("start_time", StartTime);
		request.Set("end_time", EndTime);
		return request;
	}
}
