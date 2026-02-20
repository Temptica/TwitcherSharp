using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Schedule;


/// <summary> 
/// All optional parameters for TwitchAPI.GetChannelStreamSchedule 
/// </summary>
public partial class TwitchGetChannelStreamScheduleOpt : Resource, ITwitcherSharp<TwitchGetChannelStreamScheduleOpt>
{
    private GodotObject _data;
    public string[] Id { get; set; }
    public string StartTime { get; set; }
    public string UtcOffset { get; set; }
    public int? First { get; set; }
    public string After { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetChannelStreamScheduleOpt object.
    /// </summary> 
    public static TwitchGetChannelStreamScheduleOpt FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchGetChannelStreamScheduleOpt
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
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_channel_stream_schedule.gd");
        var optClass = script.Get("Opt").AsGodotObject();
        var request = optClass.Call("new").AsGodotObject();
        if(Id != null) request.Set("id", Id);
        if(StartTime != null) request.Set("start_time", StartTime);
        if(UtcOffset != null) request.Set("utc_offset", UtcOffset);
        if(First.HasValue) request.Set("first", First.Value);
        if(After != null) request.Set("after", After);
        return request;
    }

}
