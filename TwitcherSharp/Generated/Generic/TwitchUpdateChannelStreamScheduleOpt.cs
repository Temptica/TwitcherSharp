using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// All optional parameters for TwitchAPI.UpdateChannelStreamSchedule 
/// </summary>
public partial class TwitchUpdateChannelStreamScheduleOpt : Resource, ITwitcherSharp<TwitchUpdateChannelStreamScheduleOpt>
{
    private GodotObject _data;
	public bool IsVacationEnabled { get; set; }
	public string VacationStartTime { get; set; }
	public string VacationEndTime { get; set; }
	public string Timezone { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateChannelStreamScheduleOpt object.
    /// </summary> 
    public static TwitchUpdateChannelStreamScheduleOpt FromObject(GodotObject data)
    {
		return new TwitchUpdateChannelStreamScheduleOpt
		{
			IsVacationEnabled = data.Get("is_vacation_enabled").AsBool(),
			VacationStartTime = data.Get("vacation_start_time").AsString(),
			VacationEndTime = data.Get("vacation_end_time").AsString(),
			Timezone = data.Get("timezone").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_channel_stream_schedule.gd");
		var optClass = script.Get("Opt").AsGodotObject();
		var request = optClass.Call("new").AsGodotObject();
		request.Set("is_vacation_enabled", IsVacationEnabled);
		request.Set("vacation_start_time", VacationStartTime);
		request.Set("vacation_end_time", VacationEndTime);
		request.Set("timezone", Timezone);
		return request;
	}
}
