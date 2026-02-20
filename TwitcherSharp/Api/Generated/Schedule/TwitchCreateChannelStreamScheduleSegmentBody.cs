using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Schedule;

public partial class TwitchCreateChannelStreamScheduleSegmentBody : Resource, ITwitcherSharp<TwitchCreateChannelStreamScheduleSegmentBody>
{
    private GodotObject _data;
	public string StartTime { get; set; }
	public string Timezone { get; set; }
	public string Duration { get; set; }
	public bool? IsRecurring { get; set; }
	public string CategoryId { get; set; }
	public string Title { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchCreateChannelStreamScheduleSegmentBody object.
    /// </summary> 
    public static TwitchCreateChannelStreamScheduleSegmentBody FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchCreateChannelStreamScheduleSegmentBody
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
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_create_channel_stream_schedule_segment.gd");
		var bodyClass = script.Get("Body").AsGodotObject();
		var request = bodyClass.Call("new").AsGodotObject();
		request.Set("start_time", StartTime);
		request.Set("timezone", Timezone);
		request.Set("duration", Duration);
		if(IsRecurring.HasValue) request.Set("is_recurring", IsRecurring.Value);
		if(CategoryId != null) request.Set("category_id", CategoryId);
		if(Title != null) request.Set("title", Title);
		return request;
	}

}
