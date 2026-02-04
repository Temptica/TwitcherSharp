using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Ads;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchSnoozeNextAdResponse : Resource, ITwitcherSharp<TwitchSnoozeNextAdResponse>
{
    private GodotObject _data;
	public TwitchData[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchSnoozeNextAdResponse object.
    /// </summary> 
    public static TwitchSnoozeNextAdResponse FromObject(GodotObject data)
    {
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		return new TwitchSnoozeNextAdResponse
		{
			Data = dataArray.Select(TwitchData.FromObject).ToArray(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_snooze_next_ad.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
