using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Schedule;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchCreateChannelStreamScheduleSegmentResponse : Resource, ITwitcherSharp<TwitchCreateChannelStreamScheduleSegmentResponse>
{
    private GodotObject _data;
	public TwitchData Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchCreateChannelStreamScheduleSegmentResponse object.
    /// </summary> 
    public static TwitchCreateChannelStreamScheduleSegmentResponse FromObject(GodotObject data)
    {
		return new TwitchCreateChannelStreamScheduleSegmentResponse
		{
			Data = data.Get("data").As<TwitchData>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_create_channel_stream_schedule_segment.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
