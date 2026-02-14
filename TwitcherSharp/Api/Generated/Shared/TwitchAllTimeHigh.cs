using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Shared;
 
/// <summary> 
/// An object with information about the channel’s Hype Train records. Null if a Hype Train has not occurred. 
/// </summary>
public partial class TwitchAllTimeHigh : Resource, ITwitcherSharp<TwitchAllTimeHigh>
{
    private GodotObject _data;
	public int Level { get; set; }
	public int Total { get; set; }
	public string AchievedAt { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchAllTimeHigh object.
    /// </summary> 
    public static TwitchAllTimeHigh FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchAllTimeHigh
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
