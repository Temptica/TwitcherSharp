using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Schedule;


/// <summary> 
/// All optional parameters for TwitchAPI.UpdateChannelStreamSchedule 
/// </summary>
public partial class TwitchUpdateChannelStreamScheduleOpt : RefCounted, ITwitcherSharp<TwitchUpdateChannelStreamScheduleOpt>
{
    private Variant _data;
    public bool? IsVacationEnabled { get; set; }
    public string? VacationStartTime { get; set; }
    public string? VacationEndTime { get; set; }
    public string? Timezone { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateChannelStreamScheduleOpt object.
    /// </summary> 
    public static TwitchUpdateChannelStreamScheduleOpt? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchUpdateChannelStreamScheduleOpt
        {
            IsVacationEnabled = data.ReadAsBool("is_vacation_enabled"),
            VacationStartTime = data.ReadAsString("vacation_start_time"),
            VacationEndTime = data.ReadAsString("vacation_end_time"),
            Timezone = data.ReadAsString("timezone"),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_update_channel_stream_schedule.gd", "Opt");
        if(IsVacationEnabled.HasValue) request.SetValue("is_vacation_enabled", IsVacationEnabled.Value);
        if(VacationStartTime != null) request.SetValue("vacation_start_time", VacationStartTime);
        if(VacationEndTime != null) request.SetValue("vacation_end_time", VacationEndTime);
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
