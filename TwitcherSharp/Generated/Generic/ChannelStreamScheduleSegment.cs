using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
///  
/// </summary>
public partial class ChannelStreamScheduleSegment : Resource, ITwitcherSharp<ChannelStreamScheduleSegment>
{
    private GodotObject _data;
	public string Id { get; set; }
	public string StartTime { get; set; }
	public string EndTime { get; set; }
	public string Title { get; set; }
	public string CanceledUntil { get; set; }
	public Category Category { get; set; }
	public bool IsRecurring { get; set; }
    /// <summary> 
    /// Transforms the godot data into a ChannelStreamScheduleSegment object.
    /// </summary> 
    public static ChannelStreamScheduleSegment FromObject(GodotObject data)
    {
        return new ChannelStreamScheduleSegment
        {

			Id = data.Get("id").AsString(),
			StartTime = data.Get("start_time").AsString(),
			EndTime = data.Get("end_time").AsString(),
			Title = data.Get("title").AsString(),
			CanceledUntil = data.Get("canceled_until").AsString(),
			Category = data.Get("category").As<Category>(),
			IsRecurring = data.Get("is_recurring").AsBool(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_channel_stream_schedule_segment.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("id", Id);
		request.Set("start_time", StartTime);
		request.Set("end_time", EndTime);
		request.Set("title", Title);
		request.Set("canceled_until", CanceledUntil);
		request.Set("category", Category);
		request.Set("is_recurring", IsRecurring);
		return request;
	}
}
