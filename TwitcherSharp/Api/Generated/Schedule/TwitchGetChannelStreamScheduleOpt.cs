using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Schedule;


/// <summary> 
/// All optional parameters for TwitchAPI.GetChannelStreamSchedule 
/// </summary>
public partial class TwitchGetChannelStreamScheduleOpt : RefCounted, ITwitcherSharp<TwitchGetChannelStreamScheduleOpt>
{
    private Variant _data;
    public string[]? Id { get; set; }
    public string? StartTime { get; set; }
    public string? UtcOffset { get; set; }
    public int? First { get; set; }
    public string? After { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetChannelStreamScheduleOpt object.
    /// </summary> 
    public static TwitchGetChannelStreamScheduleOpt? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetChannelStreamScheduleOpt
        {
            Id = data.ReadAsStringArray("id"),
            StartTime = data.ReadAsString("start_time"),
            UtcOffset = data.ReadAsString("utc_offset"),
            First = data.ReadAsInt32("first"),
            After = data.ReadAsString("after"),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_channel_stream_schedule.gd", "Opt");
        if(Id != null) request.SetValue("id", new Godot.Collections.Array<string>(Id));
        if(StartTime != null) request.SetValue("start_time", StartTime);
        if(UtcOffset != null) request.SetValue("utc_offset", UtcOffset);
        if(First.HasValue) request.SetValue("first", First.Value);
        if(After != null) request.SetValue("after", After);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
