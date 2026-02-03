using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Ads;
 
/// <summary> 
///  
/// </summary>
public partial class SnoozeNextAdResponse : Resource, ITwitcherSharp<SnoozeNextAdResponse>
{
    private GodotObject _data;
	public Data[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a SnoozeNextAdResponse object.
    /// </summary> 
    public static SnoozeNextAdResponse FromObject(GodotObject data)
    {
        return new SnoozeNextAdResponse
        {

			Data = data.Get("data").As<Data[]>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_snooze_next_ad_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
