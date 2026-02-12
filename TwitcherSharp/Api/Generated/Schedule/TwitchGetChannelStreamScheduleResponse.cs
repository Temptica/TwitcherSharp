using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Schedule;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchGetChannelStreamScheduleResponse : Resource, ITwitcherSharp<TwitchGetChannelStreamScheduleResponse>
{
    private GodotObject _data;
	public TwitchData Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetChannelStreamScheduleResponse object.
    /// </summary> 
    public static TwitchGetChannelStreamScheduleResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchGetChannelStreamScheduleResponse
		{
			Data = data.Get("data").As<TwitchData>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_channel_stream_schedule.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
