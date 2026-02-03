using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Schedule;
 
/// <summary> 
///  
/// </summary>
public partial class GetChannelStreamScheduleResponse : Resource, ITwitcherSharp<GetChannelStreamScheduleResponse>
{
    private GodotObject _data;
	public Data Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetChannelStreamScheduleResponse object.
    /// </summary> 
    public static GetChannelStreamScheduleResponse FromObject(GodotObject data)
    {
        return new GetChannelStreamScheduleResponse
        {

			Data = data.Get("data").As<Data>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_channel_stream_schedule_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
