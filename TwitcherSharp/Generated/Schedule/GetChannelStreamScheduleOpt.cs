using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Schedule;
 
/// <summary> 
/// All optional parameters for TwitchAPI.GetChannelStreamSchedule 
/// </summary>
public partial class GetChannelStreamScheduleOpt : Resource, ITwitcherSharp<GetChannelStreamScheduleOpt>
{
    private GodotObject _data;
	public string[] Id { get; set; }
	public string StartTime { get; set; }
	public string UtcOffset { get; set; }
	public int First { get; set; }
	public string After { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetChannelStreamScheduleOpt object.
    /// </summary> 
    public static GetChannelStreamScheduleOpt FromObject(GodotObject data)
    {
        return new GetChannelStreamScheduleOpt
        {

			Id = data.Get("id").AsStringArray(),
			StartTime = data.Get("start_time").AsString(),
			UtcOffset = data.Get("utc_offset").AsString(),
			First = data.Get("first").AsInt32(),
			After = data.Get("after").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_channel_stream_schedule_opt.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("id", Id);
		request.Set("start_time", StartTime);
		request.Set("utc_offset", UtcOffset);
		request.Set("first", First);
		request.Set("after", After);
		return request;
	}
}
