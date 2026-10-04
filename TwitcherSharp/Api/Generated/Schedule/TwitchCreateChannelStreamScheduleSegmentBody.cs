using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Schedule;

public partial class TwitchCreateChannelStreamScheduleSegmentBody : RefCounted, ITwitcherSharp<TwitchCreateChannelStreamScheduleSegmentBody>
{
    private Variant _data;
    public string StartTime { get; set; } = null!;
    public string Timezone { get; set; } = null!;
    public string Duration { get; set; } = null!;
    public bool? IsRecurring { get; set; }
    public string? CategoryId { get; set; }
    public string? Title { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchCreateChannelStreamScheduleSegmentBody object.
    /// </summary> 
    public static TwitchCreateChannelStreamScheduleSegmentBody? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchCreateChannelStreamScheduleSegmentBody
        {
            StartTime = data.Read("start_time", static v => v.AsString()),
            Timezone = data.Read("timezone", static v => v.AsString()),
            Duration = data.Read("duration", static v => v.AsString()),
            IsRecurring = data.Read("is_recurring", static v => v.AsBool()),
            CategoryId = data.Read("category_id", static v => v.AsString()),
            Title = data.Read("title", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_create_channel_stream_schedule_segment.gd", "Body");
        if(StartTime != null) request.SetValue("start_time", StartTime);
        if(Timezone != null) request.SetValue("timezone", Timezone);
        if(Duration != null) request.SetValue("duration", Duration);
        if(IsRecurring.HasValue) request.SetValue("is_recurring", IsRecurring.Value);
        if(CategoryId != null) request.SetValue("category_id", CategoryId);
        if(Title != null) request.SetValue("title", Title);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
