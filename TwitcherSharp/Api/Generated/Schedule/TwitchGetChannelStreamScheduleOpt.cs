using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Schedule;


/// <summary> 
/// All optional parameters for TwitchAPI.GetChannelStreamSchedule 
/// </summary>
public partial class TwitchGetChannelStreamScheduleOpt : RefCounted, ITwitcherSharp<TwitchGetChannelStreamScheduleOpt>
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
        var instance = new TwitchGetChannelStreamScheduleOpt
        {
            Id = data.Get("id").AsStringArray(),
            StartTime = data.Get("start_time").AsString(),
            UtcOffset = data.Get("utc_offset").AsString(),
            First = data.Get("first").AsInt32(),
            After = data.Get("after").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_channel_stream_schedule.gd");
        var optClass = script.Get("Opt").AsGodotObject();
        var request = optClass.Call("new").AsGodotObject();
        if(Id != null) request.Set("id", new Godot.Collections.Array<string>(Id));
        if(StartTime != null) request.Set("start_time", StartTime);
        if(UtcOffset != null) request.Set("utc_offset", UtcOffset);
        if(First.HasValue) request.Set("first", First.Value);
        if(After != null) request.Set("after", After);
        return request;
    }

}
