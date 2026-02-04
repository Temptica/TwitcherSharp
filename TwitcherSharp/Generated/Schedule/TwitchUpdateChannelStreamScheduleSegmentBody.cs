using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Schedule;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchUpdateChannelStreamScheduleSegmentBody : Resource, ITwitcherSharp<TwitchUpdateChannelStreamScheduleSegmentBody>
{
    private GodotObject _data;
	public string StartTime { get; set; }
	public string Duration { get; set; }
	public string CategoryId { get; set; }
	public string Title { get; set; }
	public bool IsCanceled { get; set; }
	public string Timezone { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateChannelStreamScheduleSegmentBody object.
    /// </summary> 
    public static TwitchUpdateChannelStreamScheduleSegmentBody FromObject(GodotObject data)
    {
		return new TwitchUpdateChannelStreamScheduleSegmentBody
		{
			StartTime = data.Get("start_time").AsString(),
			Duration = data.Get("duration").AsString(),
			CategoryId = data.Get("category_id").AsString(),
			Title = data.Get("title").AsString(),
			IsCanceled = data.Get("is_canceled").AsBool(),
			Timezone = data.Get("timezone").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_channel_stream_schedule_segment.gd");
		var bodyClass = script.Get("Body").AsGodotObject();
		var request = bodyClass.Call("new").AsGodotObject();
		request.Set("start_time", StartTime);
		request.Set("duration", Duration);
		request.Set("category_id", CategoryId);
		request.Set("title", Title);
		request.Set("is_canceled", IsCanceled);
		request.Set("timezone", Timezone);
		return request;
	}
}
