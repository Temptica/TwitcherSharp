using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Schedule;
 
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
	public bool? IsCanceled { get; set; }
	public string Timezone { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateChannelStreamScheduleSegmentBody object.
    /// </summary> 
    public static TwitchUpdateChannelStreamScheduleSegmentBody FromObject(GodotObject data)
    {
        if(data == null) return null;
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
		if(StartTime != null) request.Set("start_time", StartTime);
		if(Duration != null) request.Set("duration", Duration);
		if(CategoryId != null) request.Set("category_id", CategoryId);
		if(Title != null) request.Set("title", Title);
		if(IsCanceled.HasValue) request.Set("is_canceled", IsCanceled.Value);
		if(Timezone != null) request.Set("timezone", Timezone);
		return request;
	}
}
