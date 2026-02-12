using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Generic;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchChannelStreamScheduleSegment : Resource, ITwitcherSharp<TwitchChannelStreamScheduleSegment>
{
    private GodotObject _data;
	public string Id { get; set; }
	public string StartTime { get; set; }
	public string EndTime { get; set; }
	public string Title { get; set; }
	public string CanceledUntil { get; set; }
	public TwitchCategory Category { get; set; }
	public bool IsRecurring { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelStreamScheduleSegment object.
    /// </summary> 
    public static TwitchChannelStreamScheduleSegment FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchChannelStreamScheduleSegment
		{
			Id = data.Get("id").AsString(),
			StartTime = data.Get("start_time").AsString(),
			EndTime = data.Get("end_time").AsString(),
			Title = data.Get("title").AsString(),
			CanceledUntil = data.Get("canceled_until").AsString(),
			Category = data.Get("category").As<TwitchCategory>(),
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
