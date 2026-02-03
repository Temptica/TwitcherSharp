using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Ads;
 
/// <summary> 
///  
/// </summary>
public partial class GetAdScheduleResponse : Resource, ITwitcherSharp<GetAdScheduleResponse>
{
    private GodotObject _data;
	public Data[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetAdScheduleResponse object.
    /// </summary> 
    public static GetAdScheduleResponse FromObject(GodotObject data)
    {
        return new GetAdScheduleResponse
        {

			Data = data.Get("data").As<Data[]>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_ad_schedule_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
