using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Schedule;
 
/// <summary> 
///  
/// </summary>
public partial class CreateChannelStreamScheduleSegmentBody : Resource, ITwitcherSharp<CreateChannelStreamScheduleSegmentBody>
{
    private GodotObject _data;
	public string StartTime { get; set; }
	public string Timezone { get; set; }
	public string Duration { get; set; }
	public bool IsRecurring { get; set; }
	public string CategoryId { get; set; }
	public string Title { get; set; }
    /// <summary> 
    /// Transforms the godot data into a CreateChannelStreamScheduleSegmentBody object.
    /// </summary> 
    public static CreateChannelStreamScheduleSegmentBody FromObject(GodotObject data)
    {
        return new CreateChannelStreamScheduleSegmentBody
        {

			StartTime = data.Get("start_time").AsString(),
			Timezone = data.Get("timezone").AsString(),
			Duration = data.Get("duration").AsString(),
			IsRecurring = data.Get("is_recurring").AsBool(),
			CategoryId = data.Get("category_id").AsString(),
			Title = data.Get("title").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_create_channel_stream_schedule_segment_body.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("start_time", StartTime);
		request.Set("timezone", Timezone);
		request.Set("duration", Duration);
		request.Set("is_recurring", IsRecurring);
		request.Set("category_id", CategoryId);
		request.Set("title", Title);
		return request;
	}
}
