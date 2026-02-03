using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// An object with information about the channel’s Hype Train records. Null if a Hype Train has not occurred. 
/// </summary>
public partial class AllTimeHigh : Resource, ITwitcherSharp<AllTimeHigh>
{
    private GodotObject _data;
	public int Level { get; set; }
	public int Total { get; set; }
	public string AchievedAt { get; set; }
    /// <summary> 
    /// Transforms the godot data into a AllTimeHigh object.
    /// </summary> 
    public static AllTimeHigh FromObject(GodotObject data)
    {
        return new AllTimeHigh
        {

			Level = data.Get("level").AsInt32(),
			Total = data.Get("total").AsInt32(),
			AchievedAt = data.Get("achieved_at").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_all_time_high.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("level", Level);
		request.Set("total", Total);
		request.Set("achieved_at", AchievedAt);
		return request;
	}
}
