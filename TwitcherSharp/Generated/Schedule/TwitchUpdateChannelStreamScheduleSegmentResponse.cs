using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Schedule;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchUpdateChannelStreamScheduleSegmentResponse : Resource, ITwitcherSharp<TwitchUpdateChannelStreamScheduleSegmentResponse>
{
    private GodotObject _data;
	public TwitchData Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateChannelStreamScheduleSegmentResponse object.
    /// </summary> 
    public static TwitchUpdateChannelStreamScheduleSegmentResponse FromObject(GodotObject data)
    {
		return new TwitchUpdateChannelStreamScheduleSegmentResponse
		{
			Data = data.Get("data").As<TwitchData>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_channel_stream_schedule_segment.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
