using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// The dates when the broadcaster is on vacation and not streaming. Is set to **null** if vacation mode is not enabled. 
/// </summary>
public partial class Vacation : Resource, ITwitcherSharp<Vacation>
{
    private GodotObject _data;
	public string StartTime { get; set; }
	public string EndTime { get; set; }
    /// <summary> 
    /// Transforms the godot data into a Vacation object.
    /// </summary> 
    public static Vacation FromObject(GodotObject data)
    {
        return new Vacation
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
