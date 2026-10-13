using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Schedule;

public partial class TwitchUpdateChannelStreamScheduleSegmentBody : RefCounted, ITwitcherSharp<TwitchUpdateChannelStreamScheduleSegmentBody>
{
    private Variant _data;
    public string? StartTime { get; set; }
    public string? Duration { get; set; }
    public string? CategoryId { get; set; }
    public string? Title { get; set; }
    public bool? IsCanceled { get; set; }
    public string? Timezone { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateChannelStreamScheduleSegmentBody object.
    /// </summary> 
    public static TwitchUpdateChannelStreamScheduleSegmentBody? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchUpdateChannelStreamScheduleSegmentBody
        {
            StartTime = data.ReadAsString("start_time"),
            Duration = data.ReadAsString("duration"),
            CategoryId = data.ReadAsString("category_id"),
            Title = data.ReadAsString("title"),
            IsCanceled = data.ReadAsBool("is_canceled"),
            Timezone = data.ReadAsString("timezone"),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_update_channel_stream_schedule_segment.gd", "Body");
        if(StartTime != null) request.SetValue("start_time", StartTime);
        if(Duration != null) request.SetValue("duration", Duration);
        if(CategoryId != null) request.SetValue("category_id", CategoryId);
        if(Title != null) request.SetValue("title", Title);
        if(IsCanceled.HasValue) request.SetValue("is_canceled", IsCanceled.Value);
        if(Timezone != null) request.SetValue("timezone", Timezone);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
